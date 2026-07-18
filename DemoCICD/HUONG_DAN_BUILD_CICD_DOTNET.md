# Huong dan build project .NET Clean Architecture va chuan bi CI/CD
Tai lieu nay huong dan cach doc va cach tao source `DemoCICD` theo trinh tu hop ly cua Clean Architecture.
## CI/CD la gi?
- CI/CD la cach tu dong hoa qua trinh build, test va deploy phan mem.
    - CI la Continuous Integration: moi khi code duoc day len repository, he thong tu dong restore package, build project va chay test de phat hien loi som.
    - CD la Continuous Delivery/Continuous Deployment: sau khi CI thanh cong, he thong co the tu dong tao ban publish va day ung dung len moi truong deploy nhu IIS, server dev, staging hoac production.

- Muc tieu cua CI/CD:
    - Giam loi khi build/deploy thu cong.
    - Dam bao code moi khong lam hong kien truc hoac test hien co.
    - Giup qua trinh dua code tu may dev len server nhanh va on dinh hon.

## Nguyen tac trien khai:

```text
Domain
 -> Contract
 -> Application
 -> Persistence
 -> Presentation
 -> API
 -> Tests / Build / Deploy
```

Ly do di theo thu tu nay:

- `Domain` la loi nghiep vu, tao truoc.
- `Contract` dinh nghia request/response/validator de controller va handler dung chung.
- `Application` tao use case va handler, dung Domain va Contract.
- `Persistence` implement truy cap database cho abstraction cua Domain.
- `Presentation` tao controller, goi Application thong qua MediatR.
- `API` la project startup, luc nay moi ghep tat ca layer vao `Program.cs`.

## Buoc 1 - Trien khai Domain

Layer nay khong reference project nao khac.

### NuGet/packages dang dung trong Domain

`DemoCICD.Domain.csproj` dang dung:

- `Microsoft.AspNetCore.Identity.EntityFrameworkCore`: cung cap cac base class/type lien quan ASP.NET Core Identity. Trong source hien tai can package nay vi Domain co cac entity identity nhu `AppUser`, `AppRole`.

### Abstractions/Entities/DomainEntity

`DomainEntity` la base class cho cac entity.

Y nghia:

- Gom cac field chung cua cac entity (`Id`, audit field, soft delete field... ) de cac entity khac ke thua
- Repository generic co the rang buoc entity theo base type neu can.

### Entities/Product

`Product` la model nghiep vu cho san pham.

Dung de lam gi:

- Persistence map `Product` thanh table.
- Handler tao, doc, cap nhat, xoa product.
- AutoMapper map `Product` sang `Response.ProductResponse`.

### Entities/Identity

Thu muc `Entities/Identity` dang co:

- `AppUser`, `AppRole`, `Permission`, `Function`, `Action`, `ActionInFunction`

Dung de lam gi:

- Persistence se map cac entity nay thanh table identity/permission.
- Sau nay API co the them login, role, permission, authorize theo function/action.

### Abstractions/Repositories/IRepositoryBase

`IRepositoryBase<TEntity, TKey>` la abstraction cho thao tac truy cap data.

Hien tai interface co cac ham:

- `FindByIdAsync`, `FindSingleAsync`, `FindAll`, `Add`, `Update`, `Remove`, `RemoveMultiple`

Dung de lam gi:

- Persistence se tao class `RepositoryBase` implement interface nay.
- Handler trong Application sẽ gọi qua interface, khong phu thuoc truc tiep `DbContext`.

### Abstractions/IUnitOfWork

`IUnitOfWork` la abstraction cho viec commit thay doi xuong database.

Dung de lam gi:

- Persistence implement bang `EFUnitOfWork`.
- Khi create/update/delete product, handler thay doi entity qua repository.
- Sau do handler goi unit of work de luu thay doi Nhieu repository/action co the commit trong mot unit..

### Exceptions

Bao gồm:

- `DomainException`, `BadRequestException`, `NotFoundException`, `ProductException`,...

Dung de lam gi:

- Middleware bat exception va tra response loi thong nhat.

### AssemblyReference

Moi project co `AssemblyReference.cs`.

Y nghia:

- Lay assembly cua project hien tai mot cach ro rang.
- Dung cho MediatR, FluentValidation, AutoMapper hoac architecture test khi can scan assembly.

## Buoc 2 - Trien khai Contract

Sau Domain, tao `DemoCICD.Contract`.

Contract la hop dong giao tiep giua API/Presentation va Application. No dinh nghia input, output, result va validation rule.

Layer nay khong reference project nao khac.

### NuGet/packages dang dung trong Contract

`DemoCICD.Contract.csproj` dang dung:

- `MediatR`: de cac interface `ICommand`, `IQuery` boc lai request/handler cua MediatR.
- `FluentValidation`: de viet cac validator nhu `CreateProductValidator`, `UpdateProductValidator`.

### Abstractions/Message

Thu muc nay dang co:

- `ICommand`, `ICommandHandler`,  `IQuery`, `IQueryHandler`

Dung de lam gi:
- Boc lai MediatR theo ngon ngu CQRS.
- Handler trong Application implement `ICommandHandler` hoac `IQueryHandler`.

Noi ro hon:

- MediatR la thu vien giup gui mot request den dung handler ma controller khong can `new` handler truc tiep.
- CQRS tach request thanh 2 nhom: `Command` cho thao tac lam thay doi du lieu, `Query` cho thao tac doc du lieu.
- "Boc lai MediatR" nghia la minh tao interface rieng cua project nhu `ICommand`, `IQuery`, `ICommandHandler`, `IQueryHandler`, ben trong chung van dua tren MediatR.
- Loi ich la code doc theo ngon ngu nghiep vu cua project. Thay vi nhin dau dau cung la `IRequest`, minh nhin vao la biet request nay la command hay query.

Vi du de hieu:

```text
CreateProduct la Command vi no tao moi du lieu.
GetProducts la Query vi no chi doc danh sach san pham.
CreateProductCommandHandler xu ly CreateProduct.
GetProductsQueryHandler xu ly GetProducts.
```

Neu khong boc lai, code van co the dung truc tiep MediatR:

```text
CreateProduct : IRequest<Result>
```

Khi boc lai theo CQRS, code doc ro hon:

```text
CreateProduct : ICommand<Result>
```

Flow:

```text
Controller tao Command/Query
 -> Sender.Send(...)
 -> MediatR tim Handler tuong ung
```

### Abstractions/Shared

Thu muc nay dang co:

- `Error`
- `Result`
- `Result<T>`
- `IValidationResult`
- `ValidationResult`
- `ValidationResult<T>`

Y nghia:

- Thong nhat cach tra ket qua thanh cong/that bai.
- Handler co the tra loi nghiep vu bang `Result` thay vi nem exception cho moi truong hop.
- Controller doc `IsSuccess`, `IsFailure`, `Error` de quyet dinh HTTP response.

Dung de lam gi:

- Create thanh cong: tra `Result.Success`.
- Get list thanh cong: tra `Result<List<ProductResponse>>`.
- Loi validation: tra `ValidationResult`.
- Loi nghiep vu: tra `Result.Failure(error)`.

### Abstractions/Services/Product/Command

`Command.cs` chua cac request ghi du lieu cua Product.

Vi du:

- `CreateProduct`
- `UpdateProduct`
- `DeleteProduct`

Y nghia:

- Dinh nghia input cho cac thao tac lam thay doi product.
- Presentation va Application dung chung mot contract.
- Controller khong can tao class request rieng neu contract da du.

Dung de lam gi:

- `ProductsController.CreateProduct` nhan body va tao `Command.CreateProduct`.
- Application handler nhan command nay va xu ly tao product.

### Abstractions/Services/Product/Query

`Query.cs` chua cac request doc du lieu cua Product.

Vi du:

- `GetProducts`
- `GetProductById`

Y nghia:

- Dinh nghia input cho cac thao tac doc product.
- Tach ro query va command.

Dung de lam gi:

- `ProductsController.GetProducts` tao `Query.GetProducts`.
- `ProductsController.GetProductById` tao `Query.GetProductById`.
- Application handler nhan query va tra response.

### Abstractions/Services/Product/Response

`Response.cs` chua DTO tra ve cho client.

Y nghia:

- Khong tra truc tiep entity `Product` ra API, chi expose field can thiet
- Neu entity thay doi, API response khong nhat thiet bi thay doi theo.

Dung de lam gi:

- Handler map entity `Product` sang `Response.ProductResponse`.
- Controller tra response nay cho client.

### Product Validators

Thu muc validators dang co:

- `CreateProductValidator`
- `UpdateProductValidator`
- `DeleteProductValidator`
- `GetProductByIdValidator`

Y nghia:

- Kiem tra input truoc khi vao handler.
- Rule validation nam gan voi command/query.
- Controller khong can viet `if` validation lap lai.

Dung de lam gi:

- Validate ten product, gia, id...
- Neu input sai, `ValidationPipelineBehavior` trong Application chan request truoc handler.

### Bo sung Search, Sort nhieu dieu kien va Paging trong Contract

Phan filter/list product duoc dat contract o `DemoCICD.Contract` de Presentation va Application dung chung mot kieu request/response.

#### Ardalis.SmartEnum

Contract cai them:

- `Ardalis.SmartEnum`

Dung de tao `SortOrder` ro nghia hon so voi viec truyen string thu cong.

`SortOrder` hien co:

- `Ascending`: sort tang dan.
- `Descending`: sort giam dan.

Y nghia:

- Client co the gui `ASC` hoac `DESC`.
- Controller convert input thanh `SortOrder`.
- Handler chi lam viec voi kieu `SortOrder`, khong phai xu ly string lung tung.

#### Contract.Enumerations.SortOrder

`SortOrder` la enumeration dai dien cho chieu sap xep.

Dung de lam gi:

- Chuan hoa sort tang/giam trong toan bo flow.
- Giam typo khi dung `"ASC"`/`"DESC"`.
- De mo rong neu sau nay can them logic cho sort.

#### Contract.Extensions.SortOrderExtension

`SortOrderExtension` dung de convert query string thanh du lieu sort ma Application co the xu ly.

Dang ho tro:

- Sort mot cot: `sortColumn=name&sortOrder=ASC`.
- Sort nhieu cot: `sortColumnAndOrder=name-ASC,price-DESC`.

Voi sort nhieu cot, extension convert chuoi thanh dictionary:

```text
Name  -> Ascending
Price -> Descending
```

Y nghia:

- Controller khong can parse logic sort phuc tap.
- Handler nhan du lieu sort da duoc chuan hoa.
- Neu format sai, extension co the bao loi format.

#### Contract.Extensions.ProductExtension

`ProductExtension` dung de map ten cot client gui len sang property that cua `Product`.

Vi du:

- `name` -> `Name`
- `price` -> `Price`
- `description` -> `Description`
- mac dinh -> `Id`

Y nghia:

- Gioi han cac cot duoc phep sort.
- Tranh client truyen ten cot tuy y.
- Giu mapping sort cua Product o mot noi.

#### Update Query.GetProducts

`GetProducts` trong `Contract.Abstractions.Services.Product.Query` duoc update de nhan:

- `SearchTerm`: tu khoa tim kiem.
- `SortColumn`: cot sort don.
- `SortOrder`: chieu sort don.
- `SortColumnAndOrder`: danh sach sort nhieu cot.
- `PageIndex`: trang hien tai.
- `PageSize`: so item moi trang.

Ket qua tra ve:

- `PagedResult<ProductResponse>`

Y nghia:

- Query contract mo ta day du input can cho search/sort/paging.
- Handler trong Application khong phai doc truc tiep HTTP query string.
- API response tra ve ca data va thong tin phan trang.

#### Abstractions/Shared/PagedResult

`PagedResult<T>` la model tra ve ket qua da phan trang.

Chua:

- `Items`: danh sach item cua trang hien tai.
- `PageIndex`: trang hien tai.
- `PageSize`: so item moi trang.
- `TotalCount`: tong so item.
- `HasNextPage`: co trang tiep theo hay khong.
- `HasPreviousPage`: co trang truoc hay khong.

Gia tri mac dinh:

- `DefaultPageIndex = 1`
- `DefaultPageSize = 10`
- `UpperPageSize = 100`

Paging dung de lam gi:

- Khong tra ve toan bo du lieu trong mot request.
- Giam tai cho database va API.
- Giup UI/client hien thi du lieu theo tung trang.

Cong thuc paging:

```text
Skip = (PageIndex - 1) * PageSize
Take = PageSize
```

Vi du:

- `pageIndex=1&pageSize=10`: lay 10 item dau.
- `pageIndex=2&pageSize=10`: bo qua 10 item dau, lay 10 item tiep theo.
- `pageIndex=3&pageSize=10`: bo qua 20 item dau, lay 10 item tiep theo.

## Buoc 3 - Trien khai Application

Sau khi co Domain va Contract, tao `DemoCICD.Application`.

Application chua use case cua he thong. No xu ly business flow, goi repository abstraction, map response, validate request thong qua pipeline.

Layer nay reference project `DemoCICD.Domain`, `DemoCICD.Contract`, `DemoCICD.Persistence`

### NuGet/packages dang dung trong Application

`DemoCICD.Application.csproj` dang dung:

- `MediatR`: de dang ky va chay command/query handler.
- `FluentValidation`: de lam viec voi validator.
- `FluentValidation.DependencyInjectionExtensions`: cung cap `AddValidatorsFromAssembly` de scan va dang ky validator vao DI.
- `AutoMapper`: de map entity sang response DTO.
- `AutoMapper.Extensions.Microsoft.DependencyInjection`: cung cap `AddAutoMapper` de dang ky AutoMapper vao DI.

### Usercases/V1/Commands/Product

Dang co:

- `CreateProductCommand.cs`
- `CreateProductCommandHandler.cs`

Y nghia:

- Chua use case tao product.
- Handler nhan command tu Contract.
- Handler thao tac voi repository/unit of work cua Domain.

Dung de lam gi: 

```text
Command.CreateProduct
 -> CreateProductCommandHandler
 -> IRepositoryBase.Add(product)
 -> IUnitOfWork.SaveChangesAsync(...)
 -> Result
```

### Usercases/V1/Queries/Product

Dang co:

- `GetProductsQueryHandler.cs`
- `GetProductByIdQueryHandler.cs`

Y nghia:

- Chua use case doc product.
- Handler goi repository de lay data.
- Handler map entity sang response DTO.

Dung de lam gi:

```text
Query.GetProducts
 -> GetProductsQueryHandler
 -> IRepositoryBase.FindAll(...)
 -> AutoMapper map Product -> ProductResponse
 -> Result<List<ProductResponse>>
```

Sau khi bo sung search/sort/paging, `GetProductsQueryHandler` xu ly them:

- Search theo `Name` hoac `Description`.
- Sort mot cot bang LINQ.
- Sort nhieu cot bang raw SQL.
- Paging bang `PagedResult`.
- Map `PagedResult<Product>` sang `PagedResult<ProductResponse>`.

#### Search

`SearchTerm` dung de loc danh sach product theo tu khoa.

Y nghia:

- Neu `SearchTerm` rong thi lay danh sach product binh thuong.
- Neu co `SearchTerm` thi loc product co `Name` hoac `Description` chua tu khoa do.

Flow:

```text
SearchTerm
 -> FindAll(predicate)
 -> Name.Contains(...) hoac Description.Contains(...)
```

#### Sort mot cot

Khi request khong co `SortColumnAndOrder`, handler sort mot cot.

Input vi du:

```text
sortColumn=name
sortOrder=ASC
```

Y nghia:

- `SortColumn` quyet dinh cot can sap xep.
- `SortOrder` quyet dinh tang dan/giam dan.

Handler dung `GetSortProperty` de map cot sort:

- `name` -> `Product.Name`
- `price` -> `Product.Price`
- `description` -> `Product.Description`
- mac dinh -> `Product.Id`

Sau do dung:

- `OrderBy` neu sort tang dan.
- `OrderByDescending` neu sort giam dan.

#### Sort nhieu cot

Khi request co `SortColumnAndOrder`, handler xu ly sort nhieu dieu kien.

Input vi du:

```text
sortColumnAndOrder=name-ASC,price-DESC
```

Y nghia:

- Sort truoc theo `Name` tang dan.
- Neu cung `Name`, tiep tuc sort theo `Price` giam dan.

Flow:

```text
SortColumnAndOrder
 -> SortOrderExtension parse thanh dictionary
 -> Handler tao ORDER BY nhieu cot
 -> Query database
```

Trong code hien tai, sort nhieu cot dang dung raw SQL vi LINQ dynamic sort nhieu cot phuc tap hon sort mot cot.

Luu y can cai thien ve sau:

- Raw SQL hien co ghep chuoi voi `SearchTerm`, nen can can than SQL Injection.
- Nen chuyen sang parameterized SQL hoac dynamic LINQ/specification de an toan hon.
- `TotalCount` khi search nen dem theo query da filter, khong nen luon dem toan bo product.

#### Paging trong handler

Sau khi search va sort, handler moi paging.

Y nghia:

- Search quyet dinh tap du lieu can lay.
- Sort quyet dinh thu tu du lieu.
- Paging quyet dinh lay doan nao trong tap du lieu da sort.

Thu tu dung:

```text
Search -> Sort -> Paging
```

Neu paging truoc sort hoac search, ket qua co the sai vi moi trang se duoc tinh tren tap du lieu chua loc/chua sap xep.

Voi LINQ, `PagedResult.CreateAsync` se:

- Dem tong so item.
- Chuan hoa `PageIndex`, `PageSize`.
- Dung `Skip`/`Take` de lay dung trang.

Voi raw SQL sort nhieu cot, handler tu tao:

```text
OFFSET ... ROWS FETCH NEXT ... ROWS ONLY
```

Day la paging cua SQL Server.

### Behavious/ValidationPipelineBehaviour

`ValidationPipelineBehavior<TRequest, TResponse>` la pipeline cua MediatR.

Y nghia:

- Chay validation truoc handler.
- Tu dong tim validator cua request hien tai.
- Neu input sai thi tra validation error hoac nem validation exception theo implementation.
- Neu input dung thi moi goi handler.

Dung de lam gi:

```text
Sender.Send(request)
 -> ValidationPipelineBehavior
 -> FluentValidation validator trong Contract
 -> Handler
```

### Exceptions/ValidationException

`ValidationException` bieu dien loi validation o application layer.

Y nghia:

- Co type rieng cho loi validation.
- Middleware co the bat va tra response dung format.
- Tach loi validation khoi loi system.

Khac gi voi `ValidationPipelineBehavior`:

- `ValidationPipelineBehavior` la nguoi thuc thi validation. No nam tren duong di cua MediatR, chay truoc handler, lay validator ra de kiem tra request.
- `ValidationException` la ket qua loi duoc bieu dien bang exception khi validation fail. No khong tu chay validation, no chi mang thong tin loi.

Vi du de hieu:

```text
CreateProduct request di vao
 -> ValidationPipelineBehavior chay CreateProductValidator
 -> Neu Name rong/Gia sai
 -> Tao hoac nem ValidationException
 -> ExceptionHandlingMiddleware bat loi
 -> Tra ve HTTP 400 kem danh sach loi
```

Co the hieu ngan gon:

```text
ValidationPipelineBehavior = noi kiem tra
ValidationException = loi duoc nem/tra ra khi kiem tra that bai
```

### Mapper/ServiceProfile

`ServiceProfile` la AutoMapper profile.

Y nghia:

- Cau hinh map giua entity va response DTO.
- Giam mapping thu cong trong handler.

### DependencyInjection/Extensions/ServiceCollectionExtensions

Sau khi da co handler, pipeline, validator, mapper thi moi tao extension DI cho Application.

Dang co 2 method:

- `AddConfigureMediatR`
- `AddConfigurationAutoMapper`

`AddConfigureMediatR` lam gi:

- Scan Application assembly de dang ky MediatR handlers.
- Dang ky `ValidationPipelineBehavior`.
- Scan Contract assembly de dang ky FluentValidation validators.

`AddConfigurationAutoMapper` lam gi:

- Dang ky AutoMapper voi `ServiceProfile`.

Y nghia:

- Gom cau hinh Application vao mot noi.
- API sau nay chi can goi `builder.Services.AddConfigureMediatR()`.
- Khong viet tung handler, tung validator, tung pipeline trong `Program.cs`.

Luu y ve trinh tu:

- Khong cau hinh `AddConfigureMediatR` o API truoc khi tao handler/pipeline.
- Khong cau hinh `AddConfigurationAutoMapper` truoc khi tao `ServiceProfile`.
- `Program.cs` chi goi cac extension nay o buoc cuoi.

## Buoc 4 - Trien khai Persistence

Sau khi Domain co entity/repository abstraction va Application co handler can data, tao `DemoCICD.Persistence`.

Persistence la noi implement database bang EF Core.

### NuGet/packages dang dung trong Persistence

`DemoCICD.Persistence.csproj` dang dung:

- `Microsoft.EntityFrameworkCore`: core API cua EF Core, gom `DbContext`, `DbSet`, tracking, LINQ query.
- `Microsoft.EntityFrameworkCore.SqlServer`: provider de EF Core ket noi SQL Server.
- `Microsoft.EntityFrameworkCore.Proxies`: ho tro lazy loading proxies qua `UseLazyLoadingProxies`.
- `Microsoft.Extensions.DependencyInjection`: ho tro dang ky service vao DI container.
- `Microsoft.Extensions.Hosting`: ho tro cac abstraction lien quan host/runtime.
- `Microsoft.Extensions.Options.ConfigurationExtensions`: bind config tu `appsettings` vao options class.
- `Microsoft.Extensions.Options.DataAnnotations`: validate options bang data annotations.

### Constants/TableNames

`TableNames.cs` gom ten table vao mot noi.

Y nghia:

- Khong hard-code ten table rai rac trong nhieu file configuration.
- Doi ten table thi sua o mot noi.
- Giam typo khi mapping.

Dung de lam gi:

- `ProductConfiguration` dung `TableNames.Product`.
- Identity configurations dung cac ten table identity/permission.

### Configurations

Thu muc `Configurations` dang co:

- `ProductConfiguration`
- `AppUserConfiguration`
- `AppRoleConfiguration`
- `PermissionConfiguration`
- `FunctionConfiguration`
- `ActionConfiguration`
- `ActionInFunctionConfiguration`
- `IdentityConfiguration`

Y nghia:

- Cau hinh EF Core mapping cho entity.
- Dinh nghia table, key, relationship, column, constraint.

### ApplicationDbContext

`ApplicationDbContext` la DbContext cua EF Core.

Y nghia:

- La cau noi giua entity Domain va database.
- Quan ly model EF Core.
- Dung de tao migration va update database.
- Apply entity configurations.

### Repositories/RepositoryBase

`RepositoryBase` implement `IRepositoryBase`.

Y nghia:

- Chuyen abstraction trong Domain thanh implementation dung EF Core.
- Handler tiep tuc phu thuoc `IRepositoryBase`, khong phu thuoc `RepositoryBase`.
- Neu sau nay thay EF Core bang cong nghe khac, Application it bi anh huong.

Noi ro hon:

- Application handler chi biet interface `IRepositoryBase`, vi du `FindAll`, `Add`, `Remove`.
- Handler khong biet ben duoi dang dung `DbContext`, `DbSet`, SQL Server hay MongoDB.
- EF Core chi nam trong `RepositoryBase` cua Persistence.
- Neu sau nay doi cach truy cap data, minh tao implementation moi cho `IRepositoryBase`, con handler co the giu nguyen neu method contract khong doi.

Vi du:

```text
Hien tai:
CreateProductCommandHandler -> IRepositoryBase -> RepositoryBase -> EF Core -> SQL Server

Sau nay neu doi:
CreateProductCommandHandler -> IRepositoryBase -> DapperProductRepository -> Dapper -> SQL Server
```

Trong ca hai truong hop, handler van goi interface:

```text
repository.Add(product)
```

Handler khong can goi truc tiep:

```text
dbContext.Set<Product>().Add(product)
```

### EFUnitOfWork

`EFUnitOfWork` implement `IUnitOfWork`.

Y nghia:

- Dong goi thao tac save changes cua EF Core.
- Handler khong can goi truc tiep `ApplicationDbContext`.
- Giu Application tach khoi EF Core.

Noi ro hon:

- Neu handler goi `ApplicationDbContext.SaveChangesAsync()` thi Application phai reference Persistence/EF Core.
- Khi do Application biet qua nhieu ve database, lam sai huong phu thuoc cua Clean Architecture.
- Thay vao do handler chi goi `IUnitOfWork.SaveChangesAsync(...)`.
- Persistence quyet dinh save bang EF Core nhu the nao.

Vi du flow:

```text
Handler:
repository.Add(product)
unitOfWork.SaveChangesAsync()

Persistence:
EFUnitOfWork.SaveChangesAsync()
 -> ApplicationDbContext.SaveChangesAsync()
```

Nhin tu Application, no chi thay:

```text
IRepositoryBase
IUnitOfWork
```

Nhin tu Persistence, no moi thay:

```text
ApplicationDbContext
DbSet
SaveChangesAsync
```

### DependencyInjection/Options/SqlServerRetryOptions

`SqlServerRetryOptions` chua cau hinh retry SQL Server.

Y nghia:

- Dinh nghia `MaxRetryCount`, `MaxRetryDelay`, `ErrorNumbersToAdd`.
- Cho phep config retry tu `appsettings`.
- Tang do on dinh khi SQL Server gap loi tam thoi.

Dung de lam gi:

- `AddSqlConfiguration` doc option nay de tao execution strategy cho SQL Server.

### DependencyInjection/Extensions/ServiceCollectionExtensions

Sau khi co DbContext, repository, unit of work, options thi moi tao extension DI cho Persistence.

Dang co 3 method:

- `ConfigureSqlServerRetryOptions`
- `AddSqlConfiguration`
- `AddRepositoryBaseConfiguration`

`ConfigureSqlServerRetryOptions` lam gi:

- Bind section config trong `appsettings` vao `SqlServerRetryOptions`.
- Validate option khi app start.

`AddSqlConfiguration` lam gi:

- Dang ky `ApplicationDbContext` voi SQL Server.
- Bat lazy loading proxies.
- Cau hinh retry strategy.
- Cau hinh migrations assembly.
- Dang ky Identity Core voi `AppUser`, `AppRole`.
- Cau hinh password/lockout cho Identity.

Noi ro hon ve lazy loading proxies:

- Lazy loading la co che tu dong load du lieu lien quan khi minh truy cap navigation property.
- Proxy la object dac biet EF Core tao ra de chen logic load du lieu vao luc truy cap property.
- Trong source dang goi `UseLazyLoadingProxies(true)`, nen EF Core co the tu load navigation property neu entity du dieu kien.

Vi du de hieu:

```csharp
var user = await dbContext.Set<AppUser>().FirstAsync();
var roles = user.UserRoles;
```

Neu lazy loading hoat dong, luc truy cap `user.UserRoles`, EF Core co the tu query them du lieu roles ma ban chua `Include`.

Dieu kien quan trong:

- Navigation property can la `virtual`.
- Entity khong bi detach khoi DbContext.
- DbContext van con song khi truy cap navigation property.

Mat loi:

- Code ngan hon khi can lay du lieu lien quan.
- Khong phai luc nao cung viet `.Include(...)`.

Mat can than:

- De bi sinh nhieu query am tham, goi la N+1 query.
- Khi serialize response, neu dua entity ra API truc tiep co the vo tinh load them nhieu quan he.
- Voi API, thuong nen map sang DTO/Response va chu dong `.Include(...)` cho cac query quan trong.

`AddRepositoryBaseConfiguration` lam gi:

- Dang ky `IUnitOfWork` -> `EFUnitOfWork`.
- Dang ky `IRepositoryBase<,>` -> `RepositoryBase<,>`.

Y nghia:

- Gom cau hinh Persistence vao mot noi.
- API sau nay chi can goi cac extension nay.
- `Program.cs` khong can biet chi tiet DbContext/repository duoc tao nhu the nao.

### Migrations

Thu muc `Migrations` dang co:

- `InitialMigration`
- `AddProductTable`
- `ApplicationDbContextModelSnapshot`

Y nghia:

- Ghi lai lich su thay doi schema database.
- EF Core dung migration de tao/update database.
- CI/CD co the tao SQL script tu migration.

### Dung PMC de apply migration
- Apply vào Persistence:
- Add-Migration [MigrationName]
- Update-Database
- Truong hop update schema / add new table --> add-migration [new MigrationName] --> update-database
- Xóa migration moi nhat: Remove-Migration
- Rollback DB ve migration cu: Update-Database [InitialMigration] 

Luu y:

- `-Project DemoCICD.Persistence` vi migration va DbContext nam o Persistence.
- `-StartupProject DemoCICD.API` vi API co appsettings, DI va runtime config.

## Buoc 5 - Trien khai Infrastructure

Sau Domain/Application/Persistence, co the tao `DemoCICD.Insfrastructure`.

Hien tai project nay chua nhieu logic, chu yeu la noi de mo rong service ha tang ve sau.

### NuGet/packages dang dung trong Infrastructure

`DemoCICD.Infrastructure.csproj` dang dung:

- `AutoMapper`: hien dang co trong project, co the dung khi service ha tang can mapping object.

Project nay dang reference:

- `DemoCICD.Application`
- `DemoCICD.Persistence`

Y nghia:

- Chua implementation cho cac service ben ngoai.
- Vi du email, cache, file storage, token, third-party API.
- Giu Application khong phu thuoc truc tiep vao service ben ngoai.

Flow khi mo rong:

```text
Application khai bao interface
 -> Infrastructure implement interface
 -> Infrastructure dang ky DI
 -> API goi extension cua Infrastructure
 -> Handler dung interface
```

## Buoc 6 - Trien khai Presentation

Sau khi da co Contract va Application handler, moi tao `DemoCICD.Presentation`.

Presentation la noi nhan HTTP request, bind route/body, tao command/query va goi MediatR.

### NuGet/packages dang dung trong Presentation

`DemoCICD.Presentation.csproj` dang dung:

- `Microsoft.AspNetCore.Mvc.Core`: cung cap controller, action result, attribute API controller.
- `Asp.Versioning.Mvc.ApiExplorer`: ho tro API versioning va API explorer cho Swagger.
- `AutoMapper`: co san neu Presentation can map model, nhung flow hien tai mapping chinh nam o Application.
- `Newtonsoft.Json`: ho tro JSON serialization/deserialization neu can tuy bien JSON.

Project nay dang reference:

- `DemoCICD.Application`
- `DemoCICD.Insfrastructure`

### Abstractions/ApiController

`ApiController` la base controller.

Dang cung cap:

- Attribute `[ApiController]`.
- Route base `api/v{version:apiVersion}/[controller]`.
- Field/property `Sender` de dung MediatR.
- Method `HandlerFailure` de chuyen `Result` loi thanh HTTP response.
- Tao `ProblemDetails` cho response loi.

Y nghia:

- Cac controller con khong lap lai route va MediatR sender.
- Format loi thong nhat.
- Tat ca API version dung chung base route.

Dung de lam gi:

- `ProductsController` ke thua `ApiController`.
- Action goi `Sender.Send(...)`.
- Neu result fail thi goi `HandlerFailure(result)`.

### Controllers/V1/ProductsController

`ProductsController` la endpoint cho product version 1.

Dang expose:

- `GetProducts`
- `GetProductById`
- `CreateProduct`
- `UpdateProduct`
- `DeleteProduct`

Y nghia:

- Nhan HTTP request cua product.
- Khong tu query database.
- Khong chua business logic.
- Chi tao command/query va goi Application thong qua MediatR.

Flow mot action:

```text
HTTP request
 -> ProductsController action
 -> tao Command/Query trong Contract
 -> Sender.Send(...)
 -> Application handler
 -> tra IActionResult
```

#### GetProducts voi search/sort/paging

Action `GetProducts` hien nhan cac query params:

- `searchTerm`: tu khoa tim product.
- `sortColumn`: cot sort don.
- `sortOrder`: chieu sort don, vi du `ASC` hoac `DESC`.
- `sortColumnAndOrder`: sort nhieu cot, vi du `name-ASC,price-DESC`.
- `pageIndex`: trang can lay.
- `pageSize`: so item moi trang.

Controller khong tu xu ly search/sort/paging. Controller chi:

- Nhan query string tu HTTP request.
- Convert `sortOrder` sang `SortOrder`.
- Convert `sortColumnAndOrder` sang dictionary sort nhieu cot.
- Tao `Query.GetProducts`.
- Goi `Sender.Send(...)` de dua request vao Application.

Vi du request:

```text
GET /api/v1/Products?searchTerm=phone&sortColumn=name&sortOrder=ASC&pageIndex=1&pageSize=10
```

Y nghia:

- Tim product co tu khoa `phone`.
- Sort theo `Name` tang dan.
- Lay trang 1, moi trang 10 item.

Vi du sort nhieu cot:

```text
GET /api/v1/Products?sortColumnAndOrder=name-ASC,price-DESC&pageIndex=1&pageSize=20
```

Y nghia:

- Sort theo `Name` tang dan.
- Neu trung `Name`, sort tiep theo `Price` giam dan.
- Lay trang 1, moi trang 20 item.

### API versioning trong Presentation

`ProductsController` gan version bang `ApiVersion(1)`.

`ApiController` co route:

```text
api/v{version:apiVersion}/[controller]
```

Nen endpoint co dang:

```text
GET /api/v1/Products
GET /api/v1/Products/{productId}
```

Y nghia:

- Co the ton tai V1, V2 song song.
- Khi them version moi, tao controller trong `Controllers/V2`.
- Swagger co the group endpoint theo version.

### Controllers/V2/OrdersController

`OrdersController` trong V2 la vi du cho version/controller moi.

Y nghia:

- Cho thay Presentation co the tach endpoint theo version.
- Khi co nghiep vu Order that, se tao Contract/Application handler tuong ung roi controller goi vao.

## Buoc 7 - Trien khai API

Sau khi Domain, Contract, Application, Persistence, Presentation da co, luc nay moi cau hinh `DemoCICD.API`.

API la project startup. No khong xu ly business logic, chi ghep cac layer va cau hinh pipeline.

### NuGet/packages dang dung trong API

`DemoCICD.API.csproj` dang dung:

- `Asp.Versioning.Http`: core package cho API versioning.
- `Asp.Versioning.Mvc.ApiExplorer`: giup Swagger/API Explorer nhin thay cac API version.
- `Swashbuckle.AspNetCore`: tao Swagger/OpenAPI UI.
- `Swashbuckle.AspNetCore.Newtonsoft`: ho tro Newtonsoft.Json trong Swagger.
- `MicroElements.Swashbuckle.FluentValidation`: dua rule FluentValidation len Swagger schema.
- `Serilog.AspNetCore`: logging cho ASP.NET Core.
- `Microsoft.EntityFrameworkCore.Tools`: cung cap lenh PMC/EF tools nhu `Add-Migration`, `Update-Database`.
- `MediatR`: can khi API/DI runtime lam viec voi MediatR.
- `AutoMapper`: can khi runtime resolve AutoMapper.
- `FluentValidation.DependencyInjectionExtensions`: ho tro dang ky validator vao DI neu can goi o startup.

Project nay dang reference:

- `DemoCICD.Application`
- `DemoCICD.Insfrastructure`
- `DemoCICD.Persistence`
- `DemoCICD.Presentation`
- `DemoCICD.Contract`

### appsettings.json va appsettings.Development.json

Dung de chua config runtime.

Dang dung cho:

- Serilog.
- Connection string.
- SqlServerRetryOptions.
- Config theo moi truong.

Y nghia:

- Local/dev/staging/production co config rieng.
- Connection string khong hard-code trong code.
- Deploy IIS/CI/CD co the override bang environment variable hoac file config rieng.

### Middleware/ExceptionHandlingMiddleware

`ExceptionHandlingMiddleware` bat loi tap trung.

Y nghia:

- Controller khong can try/catch lap lai.
- Exception domain/application duoc map thanh HTTP response.
- Response loi co format thong nhat.

Flow:

```text
Request vao middleware
 -> goi next(context)
 -> neu controller/handler nem exception
 -> middleware catch
 -> log loi
 -> tra JSON error response
```

### SwaggerExtensions va ConfigureSwaggerOptions

`SwaggerExtensions` gom cau hinh Swagger vao extension method.

`ConfigureSwaggerOptions` cau hinh Swagger theo API version.

Y nghia:

- `Program.cs` gon hon.
- Khi co `v1`, `v2`, Swagger tao document theo version.
- De mo rong JWT, security schema, description...

### Program.cs

Sau khi cac layer da san sang, `Program.cs` moi goi DI extension.

Hien tai `Program.cs` lam cac viec theo thu tu:

1. Tao builder.
2. Cau hinh Serilog.
3. Dang ky Swagger.
4. Dang ky API versioning.
5. Goi `AddConfigureMediatR` cua Application.
6. Goi `ConfigureSqlServerRetryOptions` cua Persistence.
7. Goi `AddSqlConfiguration` cua Persistence.
8. Goi `AddRepositoryBaseConfiguration` cua Persistence.
9. Goi `AddConfigurationAutoMapper` cua Application.
10. Dang ky controller tu Presentation bang `AddApplicationPart`.
11. Build app.
12. Cau hinh middleware pipeline.
13. Map controllers.
14. Run app.

Y nghia:

- API la composition root.
- API ghep Application, Persistence, Presentation lai voi nhau.
- API khong can biet chi tiet handler/repository/validator duoc implement nhu the nao.

## Flow request sau khi hoan thanh

Vi du request:

```text
GET /api/v1/Products
```

Flow chi tiet:

```text
Client
 -> DemoCICD.API middleware pipeline
 -> DemoCICD.Presentation ProductsController
 -> tao Query.GetProducts trong Contract
 -> MediatR ISender.Send(...)
 -> Application ValidationPipelineBehavior
 -> Contract validator neu co
 -> Application GetProductsQueryHandler
 -> Domain IRepositoryBase abstraction
 -> Persistence RepositoryBase implementation
 -> Persistence ApplicationDbContext
 -> Database
 -> AutoMapper map Product -> ProductResponse
 -> Result<T>
 -> Controller tra HTTP response
```

Y nghia:

- Controller khong dung truc tiep `DbContext`.
- Handler khong biet SQL Server/EF Core chi tiet.
- Contract quy dinh input/output.
- Persistence chiu trach nhiem database.
- API chi cau hinh va host app.

## Test project

`DemoCICD.Infrastructure.Tests` dung de chua:

- Unit test.
- Architecture test.

Dang dung:

- `xunit`
- `FluentAssertions`
- `NetArchTest.Rules`
- `coverlet.collector`

### NuGet/packages dang dung trong Tests

`DemoCICD.Infrastructure.Tests.csproj` dang dung:

- `xunit`: framework viet test.
- `xunit.runner.visualstudio`: cho Visual Studio/Test Explorer chay xUnit test.
- `Microsoft.NET.Test.Sdk`: SDK de dotnet test/Test Explorer nhan dien test project.
- `FluentAssertions`: viet assert de doc hon.
- `NetArchTest.Rules`: viet architecture test, kiem tra dependency giua cac layer.
- `coverlet.collector`: thu thap code coverage khi chay test.
- `AutoMapper`: ho tro test lien quan mapping neu can.
- `Newtonsoft.Json`: ho tro test lien quan JSON neu can.

`ArchitectureTests.cs` dung de check dependency rule giua cac layer.

Y nghia:

- Dam bao Domain khong phu thuoc API/Persistence.
- Dam bao cac layer khong bi reference nguoc.
- Dam bao convention cua project khong bi pha khi them code moi.

## Publish va deploy IIS

IIS la Internet Information Services, web server cua Windows. No dung de host website/API va nhan request tu trinh duyet hoac client.

Deploy len IIS nghia la dua ban publish cua project DemoCICD.API len mot thu muc tren may Windows, sau do cau hinh IIS tro website vao thu muc do de nguoi dung co the truy cap API bang domain, localhost hoac IP.

Voi ASP.NET Core, IIS khong chay truc tiep code C# nhu ASP.NET Framework cu. IIS dong vai tro nhan request, sau do chuyen request vao ung dung ASP.NET Core thong qua ASP.NET Core Module. Vi vay can:

Cai .NET Hosting Bundle de IIS biet cach chay ASP.NET Core app.
Publish project API de tao file chay duoc tren server.
Cau hinh website, binding, App Pool va quyen truy cap thu muc deploy.

Thu tu:
1. Cai .NET Hosting Bundle dung version voi project.

2. Publish project API.

3. Copy folder publish sang thu muc deploy, vi du: C:\WWW\DemoCICD\BE\DEV

4. Them host vao file: C:\Windows\System32\drivers\etc\hosts
    Vi du: 127.0.0.1 democicd.dev.com

5. Tao website tren IIS.
    - Tro physical path toi folder publish/deploy.
    - Cau hinh binding: Host name: democicd.dev.com Port: 80 Protocol: http
    - Cau hinh App Pool: .NET CLR version: No Managed Code Managed pipeline mode: Integrated
    - Cap quyen read/execute cho App Pool vao folder deploy.
    - Restart IIS hoac recycle App Pool.

6. Truy cap: http://democicd.dev.com/swagger
Neu chi truy cap bang localhost hoac IP thi khong can sua file hosts.

    Vi du:
        http://localhost
        http://127.0.0.1
Neu dung domain tu dat nhu http://democicd.dev.com, may tinh can biet domain do tro ve dau. Voi local dev, them vao file hosts:
    127.0.0.1    democicd.dev.com

7. Neu gap HTTP 500, can kiem tra:
    Da cai Hosting Bundle chua.
    Folder publish co web.config chua.
    App Pool da de No Managed Code chua.
    App co loi start khong.
    Can bat stdout log de xem loi chi tiet neu IIS chi tra 500 chung chung.
