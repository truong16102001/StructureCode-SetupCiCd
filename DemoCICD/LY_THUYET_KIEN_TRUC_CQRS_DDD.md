# Ly thuyet kien truc, CQRS, DDD va luong request

File nay dung de doc nhanh ly thuyet nen tang. Khi can code tung buoc, doc `HUONG_DAN_TRIEN_KHAI_THEO_LUONG_CICD_DOTNET.md`.

## 1. Luong request tong quat

Khi client goi API:

```text
HTTP request
 -> Program.cs middleware pipeline
 -> ExceptionHandlingMiddleware
 -> Controller
 -> ISender.Send(command/query)
 -> MediatR PipelineBehavior
 -> CommandHandler/QueryHandler
 -> Repository/DbContext
 -> Database
 -> Result/Response
```

`ExceptionHandlingMiddleware` la lop `try-catch` ngoai cung cho HTTP request. Neu controller, handler, repository hoac DbContext `throw`, middleware bat loi va tra JSON error.

Validation hien tai khong `throw`. `ValidationPipelineBehavior` return `ValidationResult`, controller goi `HandlerFailure(result)` de tra HTTP 400.

## 2. Command, Query va MediatR

Trong code:

```text
ICommand -> IRequest<Result>
IQuery<T> -> IRequest<Result<T>>
```

`ICommand` va `IQuery` khong lam MediatR manh hon, chung lam code ro nghia hon:

- `Command`: thao tac ghi/thay doi du lieu, vi du create/update/delete product.
- `Query`: thao tac doc du lieu, vi du get product/get list product.

Flow:

```text
ProductsController
 -> Sender.Send(new CreateProductCommand(...))
 -> MediatR tim CreateProductCommandHandler
 -> Handler xu ly
 -> Result
```

MediatR tim handler theo type request, khong tim theo ten folder. V1 va V2 khac nhau vi namespace request khac nhau:

```text
Contract.Services.V1.Product.Query.GetProductsQuery
Contract.Services.V2.Product.Query.GetProductsQuery
```

## 3. Send va Publish khac nhau

MediatR co 2 luong chinh:

```text
ISender.Send(...)       -> Command/Query -> 1 handler chinh -> co response
IPublisher.Publish(...) -> Notification/Event -> nhieu handler phu -> thuong khong tra response ra client
```

Vi du command:

```text
CreateProductCommand
 -> CreateProductCommandHandler
 -> tra Result.Success()
```

Vi du domain event:

```text
DomainEvent.ProductCreated
 -> SendEmailWhenWriteProductEventHandler
 -> SendSMSWhenWriteProductEventHandler
```

Command/query la luong chinh cua API. Domain event la luong phu de xu ly viec sau nghiep vu chinh.

## 4. PipelineBehavior

PipelineBehavior giong middleware, nhung chi boc quanh MediatR handler, khong boc toan bo HTTP request.

Flow:

```text
Controller
 -> Sender.Send
 -> ValidationPipelineBehavior
 -> PerformancePipelineBehavior
 -> TransactionPipelineBehavior
 -> Handler
```

- `ValidationPipelineBehavior`: validate request truoc handler.
- `PerformancePipelineBehavior`: do thoi gian xu ly, lau thi log warning.
- `TransactionPipelineBehavior`: neu request la command thi mo transaction, chay handler, save/commit.

Luu y: thu tu dang ky `IPipelineBehavior<,>` anh huong thu tu request di qua cac behavior.

## 5. DomainEvent hien tai va RabbitMQ

Trong code hien tai:

```text
IDomainEvent : INotification
IDomainEventHandler<T> : INotificationHandler<T>
```

Nghia la `DomainEvent` dang chay noi bo trong app bang MediatR in-memory. No chua di ra RabbitMQ/Kafka.

Muon ban su kien ra he thong khac, dung `IntegrationEvent` + message bus:

```text
IntegrationEvent
 -> MassTransit/Rebus/NServiceBus
 -> RabbitMQ/Kafka
 -> Consumer/Subscriber
```

## 6. Gui email/SMS sau khi tao product

Flow code hien tai:

```text
CreateProductCommandHandler
 -> luu product
 -> await _publisher.Publish(ProductCreated)
 -> SendEmail handler chay
 -> SendSMS handler chay
 -> xong het moi return Result.Success
```

Vi dang `await Publish`, API van cho event handler chay xong. Neu email/SMS handler throw exception, request co the loi va di vao `ExceptionHandlingMiddleware`.

Neu publish event nam trong transaction, event handler throw truoc khi commit thi transaction co the rollback. Vi vay khong the noi chac "product luu thanh cong, email loi khong anh huong" voi flow hien tai.

## 7. Outbox pattern

Muon dung nghia "product luu thanh cong, email/SMS loi khong lam chet request", nen dung outbox/background job/message bus.

Flow:

```text
Create product
 -> save Product
 -> save OutboxMessage(ProductCreated)
 -> commit database
 -> tra response thanh cong
 -> BackgroundService doc OutboxMessage
 -> publish RabbitMQ / gui email / gui SMS
 -> loi thi retry sau
```

Loi ich:

- Product va outbox message commit cung transaction.
- Email/SMS loi khong rollback product.
- Co the retry viec gui email/SMS.
- Co the publish ra RabbitMQ/Kafka cho service khac xu ly.

## 8. Task.WhenAll trong publish event

Code:

```csharp
await Task.WhenAll(
    _publisher.Publish(new DomainEvent.ProductCreated(id), cancellationToken),
    _publisher.Publish(new DomainEvent.ProductDeleted(id), cancellationToken));
```

Nghia la publish 2 event cung luc:

```text
ProductCreated
ProductDeleted
```

Moi event co the co nhieu handler:

```text
ProductCreated -> SendEmail + SendSMS
ProductDeleted -> SendEmail + SendSMS
```

Tong cong co 4 xu ly phu. `Task.WhenAll` chay song song, nen khong dam bao thu tu hoan thanh.

## 9. EF Core ghi, Dapper doc

Trong CQRS, co the tach cong nghe doc/ghi:

```text
CommandHandler -> EF Core Repository -> SQL Server
QueryHandler   -> Dapper Repository  -> SQL Server
```

EF Core phu hop write side:

- Tracking entity.
- Relationship.
- Transaction.
- Unit of Work.

Dapper phu hop read side:

- Query nhanh.
- Chu dong SQL.
- Map truc tiep DTO.
- Khong can tracking entity.

Loi ich: ghi du lieu van giu domain/entity/unit of work, doc du lieu nhe va nhanh hon.

## 10. DDD va Data Driven Design

Data Driven Design thuong bat dau tu database/table:

```text
Co table Product
 -> tao Product entity giong table
 -> service/handler CRUD quanh table
```

Dac diem:

- Entity thuong chi chua data.
- Logic hay nam o service/controller/handler.
- De co code set property tuy tien.

DDD bat dau tu nghiep vu:

```text
Product co hanh vi Create/Update/ChangePrice/Delete
Product tu bao ve rule cua no
```

Vi du DDD hon:

```csharp
var product = Product.Create(id, name, price, description);
product.Update(name, price, description);
```

Thay vi Data Driven:

```csharp
product.Name = name;
product.Price = -100;
```

Loi ich cua DDD:

- Nghiep vu nam gan entity.
- Entity khong bi bien thanh "tui chua data".
- Rule quan trong duoc bao ve trong domain model.

## 11. Tom tat nhanh

```text
HTTP Middleware: boc toan bo request.
MediatR PipelineBehavior: boc quanh command/query handler.
ISender.Send: gui command/query den 1 handler chinh.
IPublisher.Publish: publish notification/domain event den nhieu handler phu.
DomainEvent hien tai: in-memory trong app.
IntegrationEvent: event di ra ngoai qua RabbitMQ/Kafka.
Outbox: cach an toan de publish event sau khi DB commit.
CQRS: tach write command va read query.
DDD: thiet ke theo nghiep vu, entity co hanh vi va rule.
Data Driven: thiet ke xoay quanh table/data, entity de thanh object chua data.
```
