# Huong dan build project .NET Clean Architecture va chuan bi CI/CD

## CI/CD la gi?

CI/CD la cach tu dong hoa qua trinh build, test va deploy phan mem.

- `CI` la `Continuous Integration`: moi khi code duoc day len repository, he thong tu dong restore package, build project va chay test de phat hien loi som.
- `CD` la `Continuous Delivery/Continuous Deployment`: sau khi CI thanh cong, he thong co the tu dong tao ban publish va day ung dung len moi truong deploy nhu IIS, server dev, staging hoac production.

Muc tieu cua CI/CD:

- Giam loi khi build/deploy thu cong.
- Dam bao code moi khong lam hong kien truc hoac test hien co.
- Giup qua trinh dua code tu may dev len server nhanh va on dinh hon.

## 1. Tao cau truc thu muc solution

Tao 3 thu muc chinh:

- `solution items`
- `src`
- `tests`

Y nghia:

- `solution items`: chua cac file cau hinh chung cua solution.
- `src`: chua cac project source code.
- `tests`: chua cac project test.

## 2. Tao cac project trong src

### DemoCICD.Domain

Day la layer trong cung cua he thong.

Chua:

- Entity.
- Value object.
- Domain event.
- Enum.
- Interface thuan domain.
- Cac class shared nhu `Error`, `Result`, `Result<T>`.

Layer nay khong reference project nao khac.

### DemoCICD.Application

Day la layer chua use case cua he thong.

Chua:

- Command.
- Query.
- Handler.
- DTO/Response model.
- Validator.
- Interface service/repository can dung cho use case.

Layer nay reference `DemoCICD.Domain`.

### DemoCICD.Infrastructure

Day la layer chua cac implementation lien quan den ha tang ben ngoai.

Vi du:

- Email service.
- File storage.
- Cache.
- Date time provider.
- JWT/token service.
- Third-party service.

Layer nay co the reference `DemoCICD.Application`, `DemoCICD.Domain`, `DemoCICD.Persistence` tuy cach tach implementation.

### DemoCICD.Persistence

Day la layer lam viec voi database.

Chua:

- DbContext.
- Migration.
- Entity configuration.
- Repository implementation.

Layer nay dung de tach logic truy cap database ra khoi `Application`.

### DemoCICD.Presentation

Day la layer trinh bay API endpoint neu muon tach controller/endpoint ra khoi project `API`.

Chua:

- Controller.
- Endpoint.
- Route group.
- Mapping request/response.

Layer nay goi use case thong qua `Application`, thuong la qua MediatR.

### DemoCICD.API

Day la project startup chinh cua he thong.

Chua:

- `Program.cs`.
- Cau hinh Dependency Injection.
- Middleware.
- Swagger.
- Cau hinh MediatR.
- Cau hinh validation.

API khong nen chua business logic. API chi nhan request, goi use case va tra response.

### DemoCICD.Contract

Day la project chua cac class dung chung neu can chia se giua nhieu project.

Chua:

- Request DTO.
- Response DTO.
- Pagination model.
- Api response model.

Luu y: `Contract` chi nen chua object don gian, khong chua business logic.

## 3. Thiet lap project reference

Thiet lap reference theo chieu Clean Architecture:

- `Domain`: khong reference project nao.
- `Application`: reference `Domain`.
- `Infrastructure`: reference `Application`, `Domain`, co the reference `Persistence` neu can.
- `Persistence`: reference `Domain`, co the reference `Application` neu implement interface tu Application.
- `Presentation`: reference `Application`.
- `API`: reference `Application`, `Infrastructure`, `Persistence`, `Presentation`, `Contract` neu co.

Muc tieu:

- Layer ben trong khong phu thuoc layer ben ngoai.
- Business core khong phu thuoc vao API, database hay framework ha tang.
- Code de test va de thay doi implementation ve sau.

## 4. Tao file AssemblyReference.cs cho moi project

Tao file `AssemblyReference.cs` trong cac project:

- `DemoCICD.Domain`
- `DemoCICD.Application`
- `DemoCICD.Infrastructure`
- `DemoCICD.Persistence`
- `DemoCICD.Presentation`
- `DemoCICD.API`
- `DemoCICD.Contract`

### Assembly la gi?

Trong .NET, moi project khi build se tao ra mot assembly, thuong la file `.dll`.

Vi du:

- `DemoCICD.Domain` build ra `DemoCICD.Domain.dll`.
- `DemoCICD.Application` build ra `DemoCICD.Application.dll`.

Assembly co the hieu don gian la file da bien dich cua mot project. Ben trong assembly co cac class, interface, enum, handler, validator... cua project do.

### AssemblyReference la gi?

`AssemblyReference.cs` la mot class nho dung de lay ra assembly cua project hien tai.

Thay vi viet truc tiep ten assembly bang string, ta tao `AssemblyReference` de cac noi khac co the tro den assembly mot cach ro rang va an toan hon.

### Dung de lam gi?

`AssemblyReference` duoc dung trong 2 truong hop chinh:

- Architecture test: lay assembly cua tung layer de kiem tra dependency rule.
- MediatR/FluentValidation: scan assembly `Application` de tim handler va validator.

Vi du ve y tuong:

- Test muon kiem tra `Domain` co phu thuoc `Infrastructure` khong thi can lay assembly cua `Domain`.
- MediatR muon tim cac handler thi can scan assembly cua `Application`.
- FluentValidation muon tim cac validator thi can scan assembly cua `Application`.

Luu y:

- Moi project chi can tao mot file `AssemblyReference.cs`.
- Namespace trong file phai dung voi namespace project.
- Chi can tao class, chi tiet code xem truc tiep trong source.

## 5. Tao coding convention cho solution

Trong solution, them:

- `.editorconfig`
- `Directory.Build.props`
- `.gitignore`

### .editorconfig

Dung de thong nhat coding convention cho toan bo solution.

Vi du:

- Cach dat indent.
- Quy tac format code.
- Quy tac style C#.

### Directory.Build.props

Dung de cau hinh build va analyzer ap dung cho tat ca project.

Bo sung analyzer:

- `SonarAnalyzer.CSharp`: check code smell.
- `StyleCop.Analyzers`: check coding convention.

### .gitignore

Dung de khong day file rac len Git.

Vi du:

- `.vs`
- `bin`
- `obj`
- `TestResults`
- file `.user`
- file log/cache

## 6. Setup Domain

Trong `DemoCICD.Domain`, tao cac thu muc:

- `Abstractions`
- `Abstractions/Entities`
- `Abstractions/Repositories`
- `Entities`
- `Enumerations`
- `Shared`

Y nghia:

- `Abstractions/Entities`: chua base entity/interface cho entity.
- `Abstractions/Repositories`: chua repository interface.
- `Entities`: chua entity chinh cua he thong.
- `Enumerations`: chua enum dung trong domain.
- `Shared`: chua cac class dung chung cua domain.

Trong `Shared`, tao:

- `Error`
- `Result`
- `Result<T>`
- `IValidationResult`
- `ValidationResult`
- `ValidationResult<T>`

Y nghia:

- `Error`: mo ta loi bang code va message.
- `Result`: ket qua thanh cong/that bai khong tra data.
- `Result<T>`: ket qua thanh cong/that bai co tra data.
- `IValidationResult`: danh dau ket qua loi validation.
- `ValidationResult`: ket qua loi validation khong tra data.
- `ValidationResult<T>`: ket qua loi validation co kieu tra ve.

## 7. Setup Application

Trong `DemoCICD.Application`, tao cac thu muc:

- `Abstractions`
- `Abstractions/Message`
- `Behaviors`
- `DependencyInjection`
- `UseCases`

### Cai MediatR

Cai package:

- `MediatR`

MediatR dung de gui command/query den dung handler.

### Tao CQRS abstraction

Trong `Abstractions/Message`, tao:

- `ICommand`
- `ICommand<TResponse>`
- `ICommandHandler<TCommand>`
- `ICommandHandler<TCommand, TResponse>`
- `IQuery<TResponse>`
- `IQueryHandler<TQuery, TResponse>`

Y nghia:

- `Command`: yeu cau lam thay doi du lieu.
- `Query`: yeu cau doc du lieu.
- `Handler`: noi xu ly command/query.

Day la lop boc lai MediatR de code doc ro hon theo CQRS.

### Tao UseCases

Trong `UseCases`, chia theo version va nghiep vu.

Vi du:

- `UseCases/V1/Commands/Product/CreateProductCommand`
- `UseCases/V1/Commands/Product/CreateProductCommandHandler`
- `UseCases/V1/Commands/Product/CreateProductCommandValidator`
- `UseCases/V1/Queries/Product/GetProductsQuery`
- `UseCases/V1/Queries/Product/GetProductsQueryHandler`
- `UseCases/V1/Queries/Product/GetProductsResponse`

Quy uoc:

- Mot command/query dai dien cho mot use case.
- Mot command/query co mot handler rieng.
- Neu can validate thi tao validator rieng cho command/query do.

## 8. Bo sung validation trong Application

Validation dung de kiem tra du lieu dau vao truoc khi handler xu ly nghiep vu.

Vi du:

- Tao product thi ten khong duoc rong.
- Update product thi id phai hop le.
- Query danh sach thi page size phai nam trong gioi han cho phep.

### Cai FluentValidation

Trong `Application`, cai package:

- `FluentValidation`

Package nay dung de viet rule validate cho command/query.

### Tao validator

Voi moi command/query can validate, tao mot validator tuong ung.

Vi du:

- `CreateProductCommand`
- `CreateProductCommandValidator`

Validator chua cac rule nhu:

- Required.
- Max length.
- Min/max value.
- Format.
- Business rule don gian cho input.

### Tao ValidationPipelineBehavior

Trong `Behaviors`, tao:

- `ValidationPipelineBehavior<TRequest, TResponse>`

Y nghia:

- La pipeline chay truoc handler.
- Tu dong tim validator cua request hien tai.
- Neu input sai thi tra `ValidationResult`.
- Neu input dung thi request moi di tiep vao handler.

Luong xu ly:

- API goi `mediator.Send`.
- Request di qua `ValidationPipelineBehavior`.
- Pipeline chay validator.
- Neu hop le thi goi handler.
- Neu khong hop le thi tra loi validation.

## 9. Setup API

Trong `DemoCICD.API`, cau hinh:

- `AddControllers`
- `AddSwaggerGen`
- `AddMediatR`
- `AddValidatorsFromAssembly`
- `IPipelineBehavior<,>` map voi `ValidationPipelineBehavior<,>`
- `MapControllers`

### Cai package validation registration

Trong `API`, cai package:

- `FluentValidation.DependencyInjectionExtensions`

Package nay cung cap `AddValidatorsFromAssembly`.

Y nghia:

- Scan `Application` assembly.
- Tim cac validator.
- Dang ky validator vao DI container.

Luu y:

- `FluentValidation` chi dung de viet validator.
- `FluentValidation.DependencyInjectionExtensions` dung de dang ky validator vao DI.
- Neu thieu package nay thi `AddValidatorsFromAssembly` se bao loi.

## 10. Setup Infrastructure

Trong `DemoCICD.Infrastructure`, implement cac service ha tang.

Vi du:

- Email service.
- File service.
- Cache service.
- Token service.
- Date time provider.

Nen tao extension method:

- `AddInfrastructure`

Muc dich la gom DI registration cua Infrastructure vao mot noi.

## 11. Setup Persistence

Trong `DemoCICD.Persistence`, tao cac thanh phan lien quan database.

Vi du:

- `ApplicationDbContext`
- Entity configuration.
- Repository implementation.
- Migration.

Neu dung Entity Framework Core thi cai package EF Core phu hop voi database dang dung.

Nen tao extension method:

- `AddPersistence`

Muc dich la dang ky DbContext va repository vao DI container.

## 12. Setup Presentation

Trong `DemoCICD.Presentation`, dat cac thanh phan lien quan den presentation/API endpoint neu muon tach khoi project `API`.

Vi du:

- Controller.
- Endpoint.
- Route group.
- Request/response mapping.

Presentation nen goi use case thong qua `Application`, khong chua business logic.

## 13. Setup Contract

Trong `DemoCICD.Contract`, dat cac DTO dung chung.

Vi du:

- `ApiResponse`
- `PaginationRequest`
- `PaginationResponse`
- `CreateProductRequest`
- `ProductResponse`

Contract chi nen chua object don gian, khong chua business logic.

## 14. Tao project test trong tests

Tao project:

- `DemoCICD.Infrastructure.Tests`

Template:

- `xUnit Test Project`

Muc dich:

- Viet unit test.
- Viet architecture test.
- Kiem tra dependency giua cac layer.

## 15. Cai package cho test project

Cai NuGet package:

- `FluentAssertions`
- `NetArchTest.Rules`

Y nghia:

- `FluentAssertions`: giup viet assert de doc hon.
- `NetArchTest.Rules`: giup viet architecture test de kiem tra dependency rule.

## 16. Reference test project toi cac project can kiem tra

`DemoCICD.Infrastructure.Tests` reference:

- `DemoCICD.API`
- `DemoCICD.Application`
- `DemoCICD.Domain`
- `DemoCICD.Infrastructure`
- `DemoCICD.Persistence`
- `DemoCICD.Presentation`
- `DemoCICD.Contract`

Ly do:

- Test project can doc assembly cua cac project nay.
- Architecture test se dua vao do de kiem tra layer nao duoc phep phu thuoc layer nao.

## 17. Viet architecture test trong ArchitectureTests.cs

Trong project `DemoCICD.Infrastructure.Tests`, tao file:

- `ArchitectureTests.cs`

## 18. Publish API

Publish project:

- `DemoCICD.API`

Folder publish can co:

- `DemoCICD.API.dll`
- `DemoCICD.API.deps.json`
- `DemoCICD.API.runtimeconfig.json`
- `appsettings.json`
- `web.config`

Luu y:

- `web.config` can thiet khi deploy len IIS.
- Khong nen copy source code truc tiep len IIS, nen deploy folder publish.

## 19. Deploy len IIS

IIS la `Internet Information Services`, web server cua Windows. No dung de host website/API va nhan request tu trinh duyet hoac client.

Deploy len IIS nghia la dua ban publish cua project `DemoCICD.API` len mot thu muc tren may Windows, sau do cau hinh IIS tro website vao thu muc do de nguoi dung co the truy cap API bang domain, localhost hoac IP.

Voi ASP.NET Core, IIS khong chay truc tiep code C# nhu ASP.NET Framework cu. IIS dong vai tro nhan request, sau do chuyen request vao ung dung ASP.NET Core thong qua `ASP.NET Core Module`. Vi vay can:

- Cai `.NET Hosting Bundle` de IIS biet cach chay ASP.NET Core app.
- Publish project API de tao file chay duoc tren server.
- Cau hinh website, binding, App Pool va quyen truy cap thu muc deploy.

Thu tu:

1. Cai .NET Hosting Bundle dung version voi project.
2. Publish project API.
3. Copy folder publish sang thu muc deploy, vi du:
   C:\WWW\DemoCICD\BE\DEV
4. Them host vao file:
   C:\Windows\System32\drivers\etc\hosts

   Vi du:
   127.0.0.1    democicd.dev.com

5. Tao website tren IIS.
6. Tro physical path toi folder publish/deploy.
7. Cau hinh binding:
   Host name: democicd.dev.com
   Port: 80
   Protocol: http

8. Cau hinh App Pool:
   .NET CLR version: No Managed Code
   Managed pipeline mode: Integrated

9. Cap quyen read/execute cho App Pool vao folder deploy.
10. Restart IIS hoac recycle App Pool.
11. Truy cap:
    http://democicd.dev.com/swagger

Neu chi truy cap bang `localhost` hoac IP thi khong can sua file `hosts`.

Vi du:

- `http://localhost`
- `http://127.0.0.1`

Neu dung domain tu dat nhu `http://democicd.dev.com`, may tinh can biet domain do tro ve dau. Voi local dev, them vao file `hosts`:

```text
127.0.0.1    democicd.dev.com
```

Neu gap HTTP 500, can kiem tra:

- Da cai Hosting Bundle chua.
- Folder publish co `web.config` chua.
- App Pool da de `No Managed Code` chua.
- App co loi start khong.
- Can bat stdout log de xem loi chi tiet neu IIS chi tra 500 chung chung.
