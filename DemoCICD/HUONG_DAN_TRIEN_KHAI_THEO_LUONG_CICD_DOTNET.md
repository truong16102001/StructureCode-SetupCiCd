# Huong dan trien khai DemoCICD theo tung luong

Tai lieu nay duoc sap xep lai tu `HUONG_DAN_BUILD_CICD_DOTNET.md`.

Muc tieu cua tai lieu nay khong phai mo ta tung project rieng le, ma mo ta cach build source tu mot solution trang theo tung luong chuc nang:

```text
Tao solution
 -> Tao shared result/error
 -> Tao exception handling
 -> Tao CQRS command/query
 -> Tao validation pipeline
 -> Tao domain/entity/repository abstraction
 -> Tao persistence/EF Core/database
 -> Tao CRUD Product
 -> Bo sung search/sort/paging
 -> Bo sung API versioning V1/V2
 -> Bo sung domain event/notification
 -> Bo sung Swagger, test, build, deploy
```

Moi luong se tra loi 4 cau hoi:

- Can cai NuGet gi?
- Tao file/class nao?
- File/class do la gi, co chuc nang gi?
- Sau khi xong thi request/code chay qua dau?

## Luong 1 - Tao solution va cac project

### Muc tieu

Tao khung solution Clean Architecture de cac layer phu thuoc dung chieu.

Thu tu project:

```text
Domain
 -> Contract
 -> Application
 -> Persistence
 -> Infrastructure
 -> Presentation
 -> API
 -> Tests
```

### Tao project

Tao cac project trong `src`:

- `DemoCICD.Domain`
- `DemoCICD.Contract`
- `DemoCICD.Application`
- `DemoCICD.Persistence`
- `DemoCICD.Insfrastructure`
- `DemoCICD.Presentation`
- `DemoCICD.API`

Tao project test trong `tests`:

- `DemoCICD.Infrastucture.Tests`

### Project nay dung de lam gi?

- `Domain`: chua entity, abstraction cot loi, domain exception.
- `Contract`: chua command/query/response/result/validator dung chung giua controller va handler.
- `Application`: chua use case, handler, pipeline behavior, AutoMapper profile.
- `Persistence`: implement database bang EF Core, repository, unit of work, migration.
- `Infrastructure`: de mo rong service ben ngoai nhu email, file, cache, token, message bus.
- `Presentation`: chua controller va base controller.
- `API`: startup project, ghep cac layer vao DI va middleware pipeline.
- `Tests`: chua unit test va architecture test.

### Tao AssemblyReference.cs

Tao `AssemblyReference.cs` trong moi project.

Class nay la gi:

- La class nho de lay assembly cua project hien tai.

Dung de lam gi:

- Application scan assembly de dang ky MediatR handler.
- Application/Contract scan assembly de dang ky validator.
- API load controller tu Presentation bang `AddApplicationPart`.
- Tests lay assembly de check architecture rules.

Vi du y tuong:

```text
Presentation.AssemblyReference.Assembly
 -> API dung de load controller trong Presentation
```

## Luong 2 - Thiet lap project references

### Muc tieu

Cho cac project nhin thay nhau dung theo chieu phu thuoc.

### References hien tai

`Domain`:

- Khong reference project nao khac.

`Contract`:

- Khong reference project nao khac.

`Application`:

- Reference `DemoCICD.Domain`.
- Reference `DemoCICD.Contract`.
- Source hien tai co reference them `DemoCICD.Persistence` vi dang dung `ApplicationDbContext` trong handler/pipeline theo strategy 1.

`Persistence`:

- Reference `DemoCICD.Domain`.

`Infrastructure`:

- Reference `DemoCICD.Application`.
- Reference `DemoCICD.Persistence`.

`Presentation`:

- Reference `DemoCICD.Application`.
- Reference `DemoCICD.Insfrastructure`.
- Reference `DemoCICD.Contract` vi controller tao command/query/response tu Contract.

`API`:

- Reference `DemoCICD.Application`.
- Reference `DemoCICD.Persistence`.
- Reference `DemoCICD.Presentation`.
- Reference `DemoCICD.Insfrastructure`.
- Reference `DemoCICD.Contract`.

`Tests`:

- Reference cac project can kiem tra architecture.

### Luu y

Huong Clean Architecture ly tuong:

```text
Domain khong phu thuoc ai
Application phu thuoc Domain/Contract
Persistence phu thuoc Domain
Presentation phu thuoc Application/Contract
API ghep tat ca layer
```

## Luong 3 - Tao shared Result/Error

### Muc tieu
 Trả về ket qua thong nhat cho handler va controller

```text
Result
Result<T>
ValidationResult
Error
```

### Tao file trong Contract

Tao trong `DemoCICD.Contract/Abstractions/Shared` hoac namespace shared hien tai cua source:

- `Error.cs`
- `Result.cs`
- `ResultT.cs`
- `IValidationResult.cs`
- `ValidationResult.cs`
- `ValidationResultT.cs`
- `PagedResult.cs`

### NuGet can co

Trong `DemoCICD.Contract`:

- `Microsoft.EntityFrameworkCore`: can cho `PagedResult.CreateAsync(...)` vi method nay dung `CountAsync`, `Skip`, `Take`, `ToListAsync` tren `IQueryable`.

### Cac class nay dung de lam gi?

- `Error`: mo ta loi bang `Code` va `Message`.
- `Result`: ket qua thanh cong/that bai khong co data, dung cho Create/Update/Delete.
- `Result<T>`: ket qua thanh cong/that bai co data, dung cho Get/List.
- `ValidationResult`, `ValidationResult<T>`: result dac biet cho loi validation.
- `IValidationResult`: danh dau result co danh sach validation errors de controller tao HTTP 400.
- `PagedResult<T>`: model tra ve danh sach co paging, gom `Items`, `PageIndex`, `PageSize`, `TotalCount`, `HasNextPage`, `HasPreviousPage`.

Vi du:

```text
CreateProductCommandHandler -> Result.Success()
GetProductsQueryHandler -> Result<PagedResult<ProductResponse>>
ValidationPipelineBehavior -> ValidationResult.WithErrors(errors)
```

## Luong 4 - Tao exception handling

### Muc tieu

Bat exception tap trung, khong try-catch lap lai trong controller/handler.

### Tao exception trong Domain

Tao trong `DemoCICD.Domain/Exceptions`:

- `DomainException`
- `BadRequestException`
- `NotFoundException`
- `ProductException`

Y nghia:

- `DomainException`: base exception cho loi nghiep vu.
- `BadRequestException`: loi request sai ve nghiep vu.
- `NotFoundException`: loi khong tim thay resource.
- `ProductException`: nhom loi rieng cua Product, vi du product not found.

Khi handler/repository/domain throw cac exception nay, `ExceptionHandlingMiddleware` se bat va map sang HTTP status code phu hop.

### Tao middleware trong API

Tao file:

```text
DemoCICD.API/Middleware/ExceptionHandlingMiddleware.cs
```

Middleware nay la gi:

- La middleware ASP.NET Core.
- Boc quanh HTTP request bang `try-catch`.

Chuc nang:

- Goi `next(context)` de request chay xuong controller/handler.
- Neu ben duoi throw exception, middleware catch.
- Log exception.
- Map exception sang status code.
- Tra JSON loi.

### Dang ky trong Program.cs

Can them:

```text
builder.Services.AddTransient<ExceptionHandlingMiddleware>();
app.UseMiddleware<ExceptionHandlingMiddleware>();
```

### Flow exception

```text
Client
 -> ExceptionHandlingMiddleware
 -> Controller
 -> Handler
 -> Repository/DbContext
 -> throw exception
 -> ExceptionHandlingMiddleware catch
 -> JSON error response
```

### Luu y

Validation fail trong source hien tai khong di qua middleware vi `ValidationPipelineBehavior` return `ValidationResult`, khong throw.

Co 2 cach xu ly validation:

- Return `ValidationResult`: controller xu ly qua `HandlerFailure`.
- Throw `ValidationException`: middleware bat va tra loi.

Source hien tai dang theo cach return result.

## Luong 5 - Tao Domain entity va abstraction data

### Muc tieu

Tao model nghiep vu va abstraction truy cap data de Application khong phu thuoc truc tiep database.

### NuGet trong Domain

`DemoCICD.Domain` dang dung:

- `Microsoft.AspNetCore.Identity.EntityFrameworkCore`: can cho cac entity identity nhu `AppUser`, `AppRole`.

### Tao DomainEntity

Tao Base class cho entity:

```text
DemoCICD.Domain/Abstractions/Entities/DomainEntity.cs
```

Chuc nang:

- Gom cac field chung nhu `Id`, audit field, soft delete field neu co.

Loi ich:

- Entity khac ke thua de thong nhat cau truc.
- Repository generic co the rang buoc entity theo base type.

### Tao Product entity

Tao file:

```text
DemoCICD.Domain/Entities/Product.cs
```

Class nay la gi:

- Model nghiep vu cua Product.

Chuc nang:

- Chua data product: `Id`, `Name`, `Price`, `Description`.
- Co factory method `Create`.
- Co method `Update`.

Loi ich:

- Neu theo DDD, entity khong chi la object chua data ma con co hanh vi.
- Code tao/cap nhat product co the gom trong entity thay vi rai rac o handler.

### Tao Identity entities

Tao trong:

```text
DemoCICD.Domain/Entities/Identity
```

Bao gom:

- `AppUser`
- `AppRole`
- `Permission`
- `Function`
- `Action`
- `ActionInFunction`

Dung de lam gi:

- Chuan bi cho authentication/authorization.
- Persistence map cac entity nay thanh table identity/permission.

### Tao IRepositoryBase

Tao file:

```text
DemoCICD.Domain/Abstractions/Repositories/IRepositoryBase.cs
```

Interface nay la gi:

- Abstraction cho thao tac truy cap data.

Chuc nang:

- `FindByIdAsync`
- `FindSingleAsync`
- `FindAll`
- `Add`
- `Update`
- `Remove`
- `RemoveMultiple`

Loi ich:

- Handler trong Application goi interface.
- Handler khong biet ben duoi dung EF Core, Dapper hay cong nghe khac.

### Tao IUnitOfWork

Tao file:

```text
DemoCICD.Domain/Abstractions/IUnitOfWork.cs
```

Interface nay la gi:

- Abstraction cho viec commit thay doi.

Chuc nang:

- Luu thay doi xuong database.
- Gom nhieu thao tac repository vao mot unit.

Flow:

```text
Handler
 -> repository.Add(product)
 -> unitOfWork.SaveChangesAsync()
 -> Persistence commit bang EF Core
```

## Luong 6 - Tao CQRS command/query bang MediatR

### Muc tieu

Tach request ghi va request doc.

```text
Command = thao tac thay doi data
Query = thao tac doc data
```

### NuGet

Trong `DemoCICD.Contract`:

- `MediatR`: de dung `IRequest`, `IRequestHandler`.

Trong `DemoCICD.Application`:

- `MediatR`: de dang ky va chay handler.

### Tao abstraction trong Contract

Tao trong:

```text
DemoCICD.Contract/Abstractions/Message
```

Bao gom:

- `ICommand`
- `ICommand<TResponse>`
- `ICommandHandler<TCommand>`
- `ICommandHandler<TCommand, TResponse>`
- `IQuery<TResponse>`
- `IQueryHandler<TQuery, TResponse>`

### ICommand la gi?

`ICommand` la request ghi du lieu.

Trong source:

```text
ICommand -> IRequest<Result>
```

Dung cho: Create/Update/Delete action

### IQuery la gi?

`IQuery<TResponse>` la request doc du lieu.

Trong source:

```text
IQuery<TResponse> -> IRequest<Result<TResponse>>
```

Dung cho:

- Get products.
- Get product by id.

### ICommandHandler/IQueryHandler la gi?

La wrapper quanh MediatR handler.

Dung de lam gi:

- Handler implement interface co y nghia nghiep vu hon.
- MediatR van nhan ra handler vi interface nay ke thua `IRequestHandler`.

### Flow CQRS

```text
Controller
 -> Sender.Send(command/query)
 -> MediatR tim handler co request type tuong ung
 -> Handler xu ly
 -> Result/Result<T>
```

### Luu y

MediatR khong tim handler theo ten file hay folder. MediatR tim theo type request.

Vi du:

```text
Contract.Services.V1.Product.Query.GetProductsQuery
 -> Application.Usercases.V1.Queries.Product.GetProductsQueryHandler
```

Handler match vi generic type la cung request type.

## Luong 7 - Tao validation bang FluentValidation va PipelineBehavior

### Muc tieu

Tu dong validate command/query truoc khi vao handler.

### NuGet

Trong `DemoCICD.Contract`:

- `FluentValidation`: de viet validator.

Trong `DemoCICD.Application`:

- `FluentValidation`
- `FluentValidation.DependencyInjectionExtensions`
- `MediatR`

### Chuan bi noi dat validators

Validator la class chua rule validate input va gan voi mot command/query cu the.

O buoc nay chi can cai `FluentValidation` va tao pipeline. Cac validator Product nhu `CreateProductValidator`, `UpdateProductValidator`, `DeleteProductValidator`, `GetProductByIdValidator` se tao sau trong luong CRUD Product, vi luc do moi co `Command`/`Query` Product de validator reference toi.

### Tao ValidationPipelineBehavior trong Application

Tao file:

```text
DemoCICD.Application/Behavious/ValidationPipelineBehaviour.cs
```

Class nay la gi:

- MediatR pipeline behavior.
- Chay truoc handler.

Chuc nang:

- Lay tat ca `IValidator<TRequest>`.
- Chay validate request.
- Neu sai thi tra `ValidationResult`.
- Neu dung thi goi handler tiep.

### Dang ky validator va pipeline

Trong:

```text
DemoCICD.Application/DependencyInjection/Extensions/ServiceCollectionExtensions.cs
```

Tao method:

```text
AddConfigureMediatR
```

Method nay lam gi:

- Register MediatR handlers tu Application assembly.
- Register `ValidationPipelineBehavior`.
- Scan validators tu Contract assembly.

### Flow validation

```text
POST /api/v1/Products
 -> Controller tao CreateProductCommand
 -> Sender.Send(command)
 -> ValidationPipelineBehavior
 -> CreateProductValidator da tao trong luong CRUD Product
 -> neu fail: return ValidationResult
 -> neu pass: CreateProductCommandHandler
```

### Luu y

Source hien tai return validation error, khong throw.

Vi vay:

```text
Validation fail
 -> Handler khong chay
 -> ExceptionHandlingMiddleware khong chay
 -> Controller HandlerFailure tra HTTP 400
```

## Luong 8 - Tao AutoMapper mapping

### Muc tieu

Map entity Domain sang DTO/Response cua Contract.

### NuGet

Trong `DemoCICD.Application`:

- `AutoMapper`
- `AutoMapper.Extensions.Microsoft.DependencyInjection`

### Tao ServiceProfile

Tao file:

```text
DemoCICD.Application/Mapper/ServiceProfile.cs
```

Class nay la gi:

- AutoMapper profile.

Chuc nang:

- La noi tap trung cau hinh mapping.
- O buoc nay co the tao class/profile truoc.
- Mapping cu the `Product` -> `ProductResponse` se them trong luong CRUD Product, sau khi `Response.ProductResponse` da ton tai.
- Mapping V2 se them trong luong API versioning V1/V2, sau khi contract V2 da ton tai.

Dung de lam gi:

- Handler khong phai map tung property thu cong.

Flow:

```text
Product entity + Response.ProductResponse
 -> cau hinh trong ServiceProfile
 -> Handler dung IMapper de map response
```

### Dang ky AutoMapper

Trong Application DI extension tao:

```text
AddConfigurationAutoMapper
```

Method nay lam gi:

- Dang ky AutoMapper voi `ServiceProfile`.

Sau do API se goi method nay trong `Program.cs`.

## Luong 9 - Tao Persistence bang EF Core

### Muc tieu

Implement database cho entity va repository abstraction.

### NuGet

Trong `DemoCICD.Persistence`:

- `Microsoft.EntityFrameworkCore`
- `Microsoft.EntityFrameworkCore.SqlServer`
- `Microsoft.EntityFrameworkCore.Proxies`
- `Microsoft.Extensions.DependencyInjection`
- `Microsoft.Extensions.Hosting`
- `Microsoft.Extensions.Options.ConfigurationExtensions`
- `Microsoft.Extensions.Options.DataAnnotations`

Trong `DemoCICD.API`:

- `Microsoft.EntityFrameworkCore.Tools`: de chay PMC migration.

### Tao TableNames

Tao file:

```text
DemoCICD.Persistence/Constants/TableNames.cs
```

Class nay la gi:

- Noi gom ten table.

Chuc nang:

- Tranh hard-code ten table rai rac.
- Doi ten table o mot noi.

### Tao entity configurations

Tao trong:

```text
DemoCICD.Persistence/Configurations
```

Bao gom:

- `ProductConfiguration`
- `AppUserConfiguration`
- `AppRoleConfiguration`
- `PermissionConfiguration`
- `FunctionConfiguration`
- `ActionConfiguration`
- `ActionInFunctionConfiguration`
- `IdentityConfiguration`

Class configuration la gi:

- EF Core mapping cho entity.

Chuc nang:

- Map entity sang table.
- Cau hinh key.
- Cau hinh relationship.
- Cau hinh column/constraint.

### Tao ApplicationDbContext

Tao file:

```text
DemoCICD.Persistence/ApplicationDbContext.cs
```

Class nay la gi:

- DbContext cua EF Core.

Chuc nang:

- Quan ly entity model.
- Apply configurations.
- Cung cap DbSet/query cho EF Core.
- Dung de tao migration.

### Tao RepositoryBase

Tao file:

```text
DemoCICD.Persistence/Repositories/RepositoryBase.cs
```

Class nay la gi:

- Implementation cua `IRepositoryBase`.

Chuc nang:

- Dung EF Core de query/add/update/remove entity.

Loi ich:

- Application chi goi `IRepositoryBase`.
- EF Core chi nam trong Persistence.

### Tao EFUnitOfWork

Tao file:

```text
DemoCICD.Persistence/EFUnitOfWork.cs
```

Class nay la gi:

- Implementation cua `IUnitOfWork`.

Chuc nang:

- Goi `ApplicationDbContext.SaveChangesAsync`.

### Tao SqlServerRetryOptions

Tao file:

```text
DemoCICD.Persistence/DependencyInjection/Options/SqlServerRetryOptions.cs
```

Class nay la gi:

- Options class bind tu appsettings.

Chuc nang:

- Cau hinh `MaxRetryCount`.
- Cau hinh `MaxRetryDelay`.
- Cau hinh `ErrorNumbersToAdd`.

Dung de lam gi:

- EF Core retry khi SQL Server gap transient error.

### Tao Persistence DI extensions

Tao file:

```text
DemoCICD.Persistence/DependencyInjection/Extensions/ServiceCollectionExtensions.cs
```

Bao gom:

- `ConfigureSqlServerRetryOptions`
- `AddSqlConfiguration`
- `AddRepositoryBaseConfiguration`

`ConfigureSqlServerRetryOptions`:

- Bind config tu `appsettings`.
- Validate option khi app start.

`AddSqlConfiguration`:

- Dang ky DbContext voi SQL Server.
- Bat lazy loading proxies.
- Cau hinh retry strategy.
- Cau hinh migration assembly.
- Dang ky Identity Core.

`AddRepositoryBaseConfiguration`:

- Dang ky `IRepositoryBase<,>` -> `RepositoryBase<,>`.
- Dang ky `IUnitOfWork` -> `EFUnitOfWork`.

### Lazy loading proxies la gi?

Lazy loading la co che EF Core tu load navigation property khi minh truy cap property do.

Vi du:

```text
user.UserRoles
```

Neu `UserRoles` la navigation property va du dieu kien, EF Core co the tu query data lien quan.

Luu y:

- Navigation property can `virtual`.
- DbContext phai con song.
- Co the gay N+1 query neu dung khong can than.

### Tao migration bang PMC

Migration nam trong Persistence, startup project la API.

```powershell
Add-Migration InitialMigration -Project DemoCICD.Persistence -StartupProject DemoCICD.API -Context ApplicationDbContext
Update-Database -Project DemoCICD.Persistence -StartupProject DemoCICD.API -Context ApplicationDbContext
```

Khi them Product table:

```powershell
Add-Migration AddProductTable -Project DemoCICD.Persistence -StartupProject DemoCICD.API -Context ApplicationDbContext
Update-Database -Project DemoCICD.Persistence -StartupProject DemoCICD.API -Context ApplicationDbContext
```

## Luong 10 - Tao CRUD Product V1

### Muc tieu

Tao API CRUD Product theo flow:

```text
Controller
 -> Contract Command/Query
 -> MediatR
 -> Application Handler
 -> Repository/DbContext
 -> Database
 -> Result
```

### Tao Contract Product V1

Tao trong:

```text
DemoCICD.Contract/Services/V1/Product
```

Bao gom:

- `Command.cs`
- `Query.cs`
- `Response.cs`
- `DomainEvent.cs` neu co event.
- `Validators/*`

`Command.cs`:

- Chua `CreateProductCommand`.
- Chua `UpdateProductCommand`.
- Chua `DeleteProductCommand`.
- La input cho cac thao tac ghi data.

`Query.cs`:

- Chua `GetProductsQuery`.
- Chua `GetProductByIdQuery`.
- La input cho cac thao tac doc data.

`Response.cs`:

- Chua `ProductResponse`.
- La DTO tra ve cho client.
- Tranh tra truc tiep entity ra API.

`Validators`:

- Tao `CreateProductValidator`, `UpdateProductValidator`, `DeleteProductValidator`, `GetProductByIdValidator`.
- Moi validator gan voi command/query V1 tuong ung.
- Validation pipeline se tu scan va chay cac validator nay truoc handler.

### Update AutoMapper ServiceProfile

Sau khi da co `Response.ProductResponse`, update:

```text
DemoCICD.Application/Mapper/ServiceProfile.cs
```

Them mapping:

- `Product` -> `Contract.Services.V1.Product.Response.ProductResponse`.
- `PagedResult<Product>` -> `PagedResult<ProductResponse>` neu GetProducts tra paging.

Y nghia:

- Query handler co the dung `IMapper` de map entity/domain result sang response DTO.

### Tao Application Product V1 handlers

Tao trong:

```text
DemoCICD.Application/Usercases/V1/Commands/Product
DemoCICD.Application/Usercases/V1/Queries/Product
```

Bao gom:

- `CreateProductCommandHandler`
- `UpdateProductCommandHandler`
- `DeleteProductCommandHandler`
- `GetProductsQueryHandler`
- `GetProductByIdQueryHandler`

Handler la gi:

- Class xu ly use case.
- Implement `ICommandHandler` hoac `IQueryHandler`.

Chuc nang:

- Nhan command/query.
- Goi repository/DbContext.
- Goi unit of work/save changes neu ghi data.
- Map entity sang response neu doc data.
- Tra `Result`/`Result<T>`.

### Tao ApiController base

Tao file:

```text
DemoCICD.Presentation/Abstractions/ApiController.cs
```

Class nay la gi:

- Base controller cho cac controller API.

Chuc nang:

- Gan `[ApiController]`.
- Dinh nghia route chung `api/v{version:apiVersion}/[controller]`.
- Chua `ISender`.
- Chua `HandlerFailure` de convert `Result` loi thanh HTTP response.

### Tao Presentation Product V1 controller

Tao file:

```text
DemoCICD.Presentation/Controllers/V1/ProductsController.cs
```

Controller nay la gi:

- Endpoint HTTP cho Product V1.

Chuc nang:

- Ke thua `ApiController`.
- Nhan HTTP request.
- Bind route/body/query string.
- Tao command/query tu Contract V1.
- Goi `Sender.Send`.
- Tra HTTP response.

Action can co:

- `GET /api/v1/Products`
- `GET /api/v1/Products/{productId}`
- `POST /api/v1/Products`
- `PUT /api/v1/Products/{productId}`
- `DELETE /api/v1/Products/{productId}`

### Flow CreateProduct V1

```text
POST /api/v1/Products
 -> ProductsController.CreateProducts
 -> Command.CreateProductCommand cua V1
 -> Sender.Send(command)
 -> ValidationPipelineBehavior
 -> TransactionPipelineBehavior
 -> CreateProductCommandHandler V1
 -> Product.Create(...)
 -> IRepositoryBase.Add(product)
 -> SaveChanges/UnitOfWork
 -> Result.Success
 -> Controller Ok(result)
```

### Flow GetProducts V1

```text
GET /api/v1/Products
 -> ProductsController.GetProducts
 -> Query.GetProductsQuery cua V1
 -> Sender.Send(query)
 -> ValidationPipelineBehavior
 -> GetProductsQueryHandler V1
 -> Repository FindAll
 -> AutoMapper Product -> ProductResponse
 -> Result<PagedResult<ProductResponse>>
 -> Controller Ok(result)
```

## Luong 11 - Bo sung search, sort, paging

### Muc tieu

Cho API list product ho tro:

- Search theo keyword.
- Sort mot cot.
- Sort nhieu cot.
- Paging.

### NuGet

Trong `DemoCICD.Contract`:

- `Ardalis.SmartEnum`: dung de tao `SortOrder` ro nghia hon string.

### Tao SortOrder

Tao file:

```text
DemoCICD.Contract/Enumerations/SortOrder.cs
```

Class nay la gi:

- Enumeration cho chieu sap xep.

Chuc nang:

- `Ascending`.
- `Descending`.

Loi ich:

- Tranh truyen string lung tung.
- Handler lam viec voi type ro nghia.

### Tao SortOrderExtension

Tao file:

```text
DemoCICD.Contract/Extensions/SortOrderExtension.cs
```

Class nay la gi:

- Helper convert query string sang sort model.

Chuc nang:

- Convert `ASC`/`DESC` sang `SortOrder`.
- Convert `name-ASC,price-DESC` sang dictionary.

### Tao ProductExtension

Tao file:

```text
DemoCICD.Contract/Extensions/ProductExtension.cs
```

Class nay la gi:

- Helper map cot client gui len sang property product.

Chuc nang:

- `name` -> `Name`.
- `price` -> `Price`.
- `description` -> `Description`.
- Mac dinh -> `Id`.

Loi ich:

- Gioi han cot duoc phep sort.
- Tranh client sort theo cot tuy y.

### Update GetProductsQuery

Them input:

- `SearchTerm`
- `SortColumn`
- `SortOrder`
- `SortColumnAndOrder`
- `PageIndex`
- `PageSize`

Ket qua:

- `PagedResult<ProductResponse>`

### Update ProductsController.GetProducts

Controller nhan query params:

```text
searchTerm
sortColumn
sortOrder
sortColumnAndOrder
pageIndex
pageSize
```

Controller lam gi:

- Convert sort string.
- Tao `Query.GetProductsQuery`.
- Goi `Sender.Send`.

### Update GetProductsQueryHandler

Handler xu ly:

- Search theo `Name`/`Description`.
- Sort mot cot bang LINQ.
- Sort nhieu cot bang raw SQL.
- Paging bang `PagedResult`.

Thu tu dung:

```text
Search -> Sort -> Paging
```

### Luu y

Raw SQL ghep chuoi voi `SearchTerm` co rui ro SQL Injection. Khi production nen dung parameterized SQL, Dapper parameter, EF parameter, hoac dynamic LINQ an toan hon.

## Luong 12 - Bo sung transaction pipeline

### Muc tieu

Bao quanh command handler bang transaction.

### Tao TransactionPipelineBehavior

Tao file:

```text
DemoCICD.Application/Behavious/TransactionPipelineBehaviour.cs
```

Class nay la gi:

- MediatR pipeline behavior.

Chuc nang:

- Neu request la command thi mo transaction.
- Chay handler.
- Save changes.
- Commit neu thanh cong.
- Rollback neu loi.
- Neu request la query thi bo qua transaction.

### Flow transaction

```text
Command
 -> TransactionPipelineBehavior
 -> BeginTransaction
 -> Handler
 -> SaveChanges
 -> Commit
```

Neu loi:

```text
Command
 -> BeginTransaction
 -> Handler throw
 -> Rollback
 -> ExceptionHandlingMiddleware
```

### SaveChanges khac Commit

- `SaveChanges`: day thay doi trong DbContext xuong database trong transaction.
- `Commit`: xac nhan transaction thanh cong.
- `Rollback`: huy transaction.

Neu da `SaveChanges` nhung chua `Commit`, transaction van co the rollback.

### Hai strategy transaction trong source

- `SQL-SERVER-STRATEGY-1`: dung `ApplicationDbContext` truc tiep, tao execution strategy bang EF Core SQL Server retry, mo transaction bang `BeginTransactionAsync`, phu hop khi muon retry loi transient cua SQL Server. Doi lai, Application bi phu thuoc vao Persistence/EF Core.
- `SQL-SERVER-STRATEGY-2`: dung `IUnitOfWork` va `TransactionScope`, sach hon theo Clean Architecture vi handler/pipeline lam viec voi abstraction, nhung can can than khi ket hop voi EF Core retry strategy.

Trong source hien tai, transaction pipeline dang uu tien strategy 1 de dung `SqlServerRetryingExecutionStrategy`.

## Luong 13 - Bo sung performance/tracing pipeline

### Muc tieu

Theo doi request MediatR chay lau hay log thong tin request.

### Tao PerformancePipelineBehavior

Tao file:

```text
DemoCICD.Application/Behavious/PerformancePipelineBehavior.cs
```

Class nay la gi:

- Pipeline behavior do thoi gian xu ly request.

Chuc nang:

- Bat stopwatch truoc handler.
- Dung stopwatch sau handler.
- Neu qua nguong thi log warning.

### Tao TracingPipelineBehavior

Tao file:

```text
DemoCICD.Application/Behavious/TracingPipelineBehavior.cs
```

Class nay la gi:

- Pipeline behavior log thong tin request.

Chuc nang:

- Log request name.
- Log elapsed time.
- Log request data.

### Dang ky trong AddConfigureMediatR

Them vao Application DI:

```text
AddTransient(IPipelineBehavior<,>, ValidationPipelineBehavior<,>)
AddTransient(IPipelineBehavior<,>, PerformancePipelineBehavior<,>)
AddTransient(IPipelineBehavior<,>, TransactionPipelineBehavior<,>)
```

Luu y:

- Thu tu dang ky pipeline anh huong thu tu wrap handler.
- Pipeline la middleware cua MediatR, khong phai middleware cua ASP.NET Core.

## Luong 14 - Bo sung DomainEvent/Notification

### Muc tieu

Sau khi command chinh xu ly xong, ban ra cac su kien noi bo de cac handler phu xu ly viec phu nhu email/SMS/job.

### NuGet

Dung MediatR da cai o `Contract` va `Application`.

### Tao abstraction event trong Contract

Tao trong:

```text
DemoCICD.Contract/Abstractions/Message
```

Bao gom:

- `IDomainEvent`
- `IDomainEventHandler<TEvent>`

`IDomainEvent` la gi:

- Event noi bo cua domain/application.
- Ke thua `INotification` cua MediatR.

`IDomainEventHandler<TEvent>` la gi:

- Handler xu ly domain event.
- Ke thua `INotificationHandler<TEvent>`.

### Tao Product DomainEvent

Tao trong:

```text
DemoCICD.Contract/Services/V1/Product/DomainEvent.cs
DemoCICD.Contract/Services/V2/Product/DomainEvent.cs
```

Bao gom:

- `ProductCreated`
- `ProductUpdated`
- `ProductDeleted`

Class/record nay la gi:

- Message noi bo bao rang product da duoc create/update/delete.

### Inject IPublisher vao command handler

Trong command handler, inject:

```text
IPublisher
```

`IPublisher` la gi:

- Interface cua MediatR de publish notification/event.

Dung de lam gi:

- Ban domain event cho cac event handler noi bo.

Flow:

```text
CreateProductCommandHandler
 -> luu product
 -> _publisher.Publish(new ProductCreated(id))
 -> cac ProductCreated handler chay
```

### Tao event handlers trong Application

Tao trong:

```text
DemoCICD.Application/Usercases/V1/Events
DemoCICD.Application/Usercases/V2/Events
```

Bao gom:

- `SendEmailWhenWriteProductEventHandler`
- `SendSMSWhenWriteProductEventHandler`

Class nay la gi:

- Handler phu xu ly domain event.

Chuc nang:

- Khi `ProductCreated`, `ProductUpdated`, `ProductDeleted` duoc publish thi handler chay.
- Hien tai source dang gia lap send email/SMS bang `Task.Delay`.

### Send va Publish khac nhau

`ISender.Send`:

- Dung cho command/query.
- Mot request co mot handler chinh.
- Co ket qua tra ve client.

`IPublisher.Publish`:

- Dung cho notification/domain event.
- Mot event co the co nhieu handler.
- Thuong xu ly viec phu.

Flow:

```text
Send(command/query)
 -> 1 command/query handler

Publish(domain event)
 -> many event handlers
```

### Luu y quan trong

DomainEvent trong source hien tai la in-memory MediatR event.

No chua phai RabbitMQ/Kafka.

Neu muon ban event ra ngoai system:

```text
IntegrationEvent
 -> Message bus
 -> RabbitMQ/Kafka
 -> Consumer/Subscriber
```

Luc do nen dung:

- MassTransit
- Rebus
- NServiceBus

### Task.WhenAll trong event publish

Source hien tai co doan publish nhieu event:

```text
Task.WhenAll(
  Publish(ProductCreated),
  Publish(ProductDeleted)
)
```

Y nghia:

- Publish 2 event gan nhu cung luc.
- Moi event co the duoc nhieu handler bat.

Khong nen khang dinh thu tu handler chay theo dung thu tu code, vi `Task.WhenAll` chay song song va thu tu hoan thanh khong dam bao.

## Luong 15 - Bo sung API versioning V1/V2

### Muc tieu

Cho phep ton tai nhieu version API song song.

```text
/api/v1/Products
/api/v2/Products
```

### NuGet

Trong `DemoCICD.API`:

- `Asp.Versioning.Http`
- `Asp.Versioning.Mvc.ApiExplorer`

Trong `DemoCICD.Presentation`:

- `Asp.Versioning.Mvc.ApiExplorer`

### Cau hinh route base

Trong:

```text
DemoCICD.Presentation/Abstractions/ApiController.cs
```

Dung route:

```text
api/v{version:apiVersion}/[controller]
```

Y nghia:

- URL co version.
- Version tu URL duoc API versioning doc.

### Tao controller V1

```text
DemoCICD.Presentation/Controllers/V1/ProductsController.cs
```

Gan:

```text
[ApiVersion(1)]
```

Controller V1 dung contract V1:

```text
DemoCICD.Contract.Services.V1.Product
```

### Tao controller V2

```text
DemoCICD.Presentation/Controllers/V2/ProductsController.cs
```

Gan:

```text
[ApiVersion(2)]
```

Controller V2 dung contract V2:

```text
DemoCICD.Contract.Services.V2.Product
```

### Tao Contract V2

Tao:

```text
DemoCICD.Contract/Services/V2/Product
```

Bao gom:

- `Command.cs`
- `Query.cs`
- `Response.cs`
- `DomainEvent.cs`
- `Validators/*`

### Tao Application handler V2

Tao:

```text
DemoCICD.Application/Usercases/V2/Commands/Product
DemoCICD.Application/Usercases/V2/Queries/Product
```

Bao gom handler tuong ung V2.

### Lam sao biet controller V2 goi dung handler V2?

Co 2 lop routing:

1. ASP.NET API Versioning chon controller theo URL va `[ApiVersion]`.
2. MediatR chon handler theo type request.

Flow:

```text
GET /api/v2/Products
 -> ProductsController trong namespace Controllers.V2
 -> controller tao Contract.Services.V2.Product.Query.GetProductsQuery
 -> Sender.Send(query V2)
 -> MediatR tim handler implement IQueryHandler<V2 Query.GetProductsQuery, ...>
 -> Application.Usercases.V2.Queries.Product.GetProductsQueryHandler
```

MediatR khong can biet folder V2. No chi can request type la V2.

V1 va V2 co the trung ten class nhung khac namespace:

```text
DemoCICD.Contract.Services.V1.Product.Query.GetProductsQuery
DemoCICD.Contract.Services.V2.Product.Query.GetProductsQuery
```

Do do day la 2 type khac nhau.

### Cau hinh API versioning trong Program.cs

Can:

```text
AddApiVersioning(...)
AddApiExplorer(...)
```

`AddApiExplorer` giup Swagger nhin thay cac version.

## Luong 16 - Bo sung Swagger theo version

### Muc tieu

Swagger hien dropdown `v1`, `v2` va sinh document rieng cho tung version.

### NuGet

Trong `DemoCICD.API`:

- `Swashbuckle.AspNetCore`
- `Swashbuckle.AspNetCore.Newtonsoft`
- `MicroElements.Swashbuckle.FluentValidation`
- `Asp.Versioning.Mvc.ApiExplorer`

### Tao ConfigureSwaggerOptions

Tao file:

```text
DemoCICD.API/DependencyInjection/Options/ConfigureSwaggerOptions.cs
```

Class nay la gi:

- Options config cho SwaggerGen.

Chuc nang:

- Doc danh sach version tu `IApiVersionDescriptionProvider`.
- Tao SwaggerDoc cho tung version.
- Cau hinh schema id.
- Cau hinh type dac biet nhu `DateOnly`.

### Tao SwaggerExtensions

Tao file:

```text
DemoCICD.API/DependencyInjection/Extensions/SwaggerExtensions.cs
```

Bao gom:

- `AddSwagger`
- `ConfigureSwagger`

`AddSwagger`:

- Goi `AddSwaggerGen`.
- Dang ky `ConfigureSwaggerOptions`.

`ConfigureSwagger`:

- Goi `UseSwagger`.
- Goi `UseSwaggerUI`.
- Tao endpoint `/swagger/v1/swagger.json`, `/swagger/v2/swagger.json`.
- Redirect `/` sang Swagger neu can.

### Program.cs dung extension

Dung:

```text
builder.Services.AddSwagger();
app.ConfigureSwagger();
```

Khong chi dung:

```text
builder.Services.AddSwaggerGen();
app.UseSwaggerUI();
```

vi cach do khong dung options da tao de sinh multi-version docs.

## Luong 17 - Ghep tat ca trong API/Program.cs

### Muc tieu

API la startup project, ghep tat ca layer vao DI va middleware pipeline.

### NuGet trong API

`DemoCICD.API` dang dung:

- `Asp.Versioning.Http`
- `Asp.Versioning.Mvc.ApiExplorer`
- `Swashbuckle.AspNetCore`
- `Swashbuckle.AspNetCore.Newtonsoft`
- `MicroElements.Swashbuckle.FluentValidation`
- `Serilog.AspNetCore`
- `Microsoft.EntityFrameworkCore.Tools`
- `MediatR`
- `AutoMapper`
- `FluentValidation.DependencyInjectionExtensions`

### Tao appsettings

Tao/sua trong `DemoCICD.API`:

- `appsettings.json`: config chung cho Serilog, retry options, setting runtime.
- `appsettings.Development.json`: config local/dev, thuong de connection string local.

Y nghia:

- `Program.cs` doc config tu `builder.Configuration`.
- Persistence bind `SqlServerRetryOptions` tu appsettings.
- `ApplicationDbContext` lay connection string khi dang ky SQL Server.
- Khi deploy IIS/staging/production co the override config bang file rieng hoac environment variable.

### Program.cs cau hinh service

Thu tu:

```text
Tao builder
 -> Cau hinh Serilog
 -> AddSwagger
 -> AddApiVersioning/AddApiExplorer
 -> AddConfigureMediatR
 -> Add ExceptionHandlingMiddleware
 -> ConfigureSqlServerRetryOptions
 -> AddSqlConfiguration
 -> AddRepositoryBaseConfiguration
 -> AddConfigurationAutoMapper
 -> AddControllers().AddApplicationPart(Presentation.Assembly)
```

### Program.cs cau hinh pipeline

Thu tu:

```text
Build app
 -> UseMiddleware<ExceptionHandlingMiddleware>
 -> ConfigureSwagger
 -> UseHttpsRedirection
 -> UseAuthorization
 -> MapControllers
 -> RunAsync
```

### Flow full request

```text
Client
 -> API Program.cs middleware pipeline
 -> ExceptionHandlingMiddleware
 -> Presentation ProductsController
 -> Contract Command/Query
 -> MediatR ISender.Send
 -> ValidationPipelineBehavior
 -> PerformancePipelineBehavior
 -> TransactionPipelineBehavior neu la Command
 -> Application Handler
 -> Domain Repository/UnitOfWork abstraction
 -> Persistence RepositoryBase/ApplicationDbContext
 -> SQL Server
 -> AutoMapper
 -> Result/Result<T>
 -> Controller
 -> HTTP response
```

## Luong 18 - Bo sung Infrastructure

### Muc tieu

Chuan bi layer cho service ben ngoai.

### NuGet

`DemoCICD.Infrastructure` hien dang co:

- `AutoMapper`

### Tao/su dung Infrastructure

Project nay hien chua nhieu logic.

Dung de them ve sau:

- Email service.
- SMS service.
- File storage.
- Cache.
- Token/JWT service.
- Message bus publisher.
- Third-party API client.

Flow mo rong:

```text
Application khai bao interface
 -> Infrastructure implement interface
 -> API dang ky DI
 -> Handler goi interface
```

Luu y:

- DomainEvent handler hien tai dang gia lap email/SMS trong Application.
- Neu lam that, co the dua implementation send email/SMS sang Infrastructure.

## Luong 19 - Tao Tests

### Muc tieu

Kiem tra code va kiem tra architecture rule.

### NuGet

Trong `DemoCICD.Infrastructure.Tests`:

- `xunit`
- `xunit.runner.visualstudio`
- `Microsoft.NET.Test.Sdk`
- `FluentAssertions`
- `NetArchTest.Rules`
- `coverlet.collector`
- `AutoMapper`
- `Newtonsoft.Json`

### Tao ArchitectureTests

Tao file:

```text
tests/DemoCICD.Infrastucture.Tests/ArchitectureTests.cs
```

Class nay la gi:

- Test class kiem tra rule phu thuoc giua cac layer.

Chuc nang:

- Domain khong phu thuoc API/Persistence.
- Cac layer khong reference nguoc.
- Handler co naming convention neu project quy uoc.

### Flow test

```text
dotnet test
 -> test project load assemblies
 -> NetArchTest kiem tra dependency
 -> pass/fail
```

## Luong 20 - Build, migration, publish va deploy

### Muc tieu CI/CD

CI/CD la tu dong hoa restore, build, test, publish va deploy.

- `CI`: moi lan day code len repository thi he thong restore package, build solution va chay test.
- `CD`: sau khi CI thanh cong thi tao ban publish va day len moi truong deploy nhu IIS/dev/staging/production.

Loi ich:

- Giam loi build/deploy thu cong.
- Phat hien loi som khi code moi pha test/build.
- Tao quy trinh dua code len server on dinh hon.

### Build local

```powershell
dotnet restore
dotnet build DemoCICD.sln
dotnet test
```

Neu build bi lock DLL:

- Stop app dang chay trong Visual Studio.
- Kill process `DemoCICD.API` neu can.
- Build lai.

### Migration bang PMC

Migration o Persistence, startup project la API.

```powershell
Add-Migration TenMigration -Project DemoCICD.Persistence -StartupProject DemoCICD.API -Context ApplicationDbContext
Update-Database -Project DemoCICD.Persistence -StartupProject DemoCICD.API -Context ApplicationDbContext
```

Remove migration moi nhat:

```powershell
Remove-Migration -Project DemoCICD.Persistence -StartupProject DemoCICD.API -Context ApplicationDbContext
```

Rollback database:

```powershell
Update-Database InitialMigration -Project DemoCICD.Persistence -StartupProject DemoCICD.API -Context ApplicationDbContext
```

### Publish API

```powershell
dotnet publish src/DemoCICD.API/DemoCICD.API.csproj -c Release -o publish
```

Folder publish can co:

- `DemoCICD.API.dll`
- `DemoCICD.API.deps.json`
- `DemoCICD.API.runtimeconfig.json`
- `appsettings.json`
- `web.config`

### Deploy IIS

IIS la web server cua Windows.

Voi ASP.NET Core:

- IIS nhan request.
- ASP.NET Core Module chuyen request vao app.
- Can cai .NET Hosting Bundle.

Thu tu:

1. Cai .NET Hosting Bundle dung version.
2. Publish project API.
3. Copy folder publish sang server, vi du `C:\WWW\DemoCICD\BE\DEV`.
4. Tao website tren IIS.
5. Tro physical path toi folder publish.
6. Cau hinh binding host/port/protocol.
7. Cau hinh App Pool `No Managed Code`.
8. Cap quyen read/execute cho App Pool.
9. Restart IIS hoac recycle App Pool.
10. Truy cap Swagger.

Neu dung domain local:

```text
127.0.0.1    democicd.dev.com
```

Them vao:

```text
C:\Windows\System32\drivers\etc\hosts
```

Truy cap:

```text
http://democicd.dev.com/swagger
```

Neu gap HTTP 500:

- Kiem tra Hosting Bundle.
- Kiem tra `web.config`.
- Kiem tra App Pool.
- Kiem tra connection string.
- Xem log Serilog.
- Bat stdout log neu IIS chi tra 500 chung chung.

## Phu luc ly thuyet nen doc rieng

File nay la tai lieu trien khai theo luong. De nam khung ly thuyet truoc khi code, doc them:

```text
LY_THUYET_KIEN_TRUC_CQRS_DDD.md
```

File ly thuyet giai thich ngan gon:

- Luong request tu API vao controller, MediatR, handler, repository, database.
- `ISender.Send` cho command/query va `IPublisher.Publish` cho notification/domain event.
- `PipelineBehavior` khac `ExceptionHandlingMiddleware` nhu the nao.
- DomainEvent hien tai la MediatR in-memory, chua phai RabbitMQ/Kafka.
- Vi sao gui email/SMS trong handler hien tai van co the lam request loi.
- Outbox/background worker/message bus dung khi muon product commit thanh cong nhung email/SMS loi khong rollback.
- EF Core ghi, Dapper doc trong CQRS.
- DDD khac Data Driven Design o dau.

## Tong ket thu tu implement de nho

```text
1. Tao solution/project/reference/AssemblyReference
2. Tao Result/Error/PagedResult
3. Tao Domain exception va ExceptionHandlingMiddleware
4. Tao DomainEntity/Product/IRepositoryBase/IUnitOfWork
5. Tao CQRS abstraction ICommand/IQuery
6. Tao validator va ValidationPipelineBehavior
7. Tao AutoMapper ServiceProfile
8. Tao Persistence DbContext/Configurations/Repository/UnitOfWork/Migration
9. Tao Contract Product command/query/response
10. Tao Application Product handlers
11. Tao Presentation ApiController/ProductsController
12. Cau hinh Program.cs de ghep tat ca
13. Bo sung search/sort/paging
14. Bo sung transaction/performance/tracing pipeline
15. Bo sung domain event/notification
16. Bo sung API versioning V1/V2
17. Bo sung Swagger multi-version
18. Bo sung tests
19. Build, migration, publish, deploy
```
