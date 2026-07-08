# Huong dan build project .NET Clean Architecture va chuan bi CI/CD bang Visual Studio

Tai lieu nay huong dan tung buoc tren Visual Studio de tao solution `DemoCICD`, sap xep project theo Clean Architecture, them coding convention chung, viet architecture test va tranh day file rac len Git.

Luu y: day la huong dan thao tac tren Visual Studio, khong phai VS Code va khong uu tien command line.

## 1. Cau truc mong muon

```text
DemoCICD/
+-- .editorconfig
+-- .gitignore
+-- Directory.Build.props
+-- DemoCICD.sln
+-- solution items/
+-- src/
|   +-- DemoCICD.API/
|   +-- DemoCICD.Application/
|   +-- DemoCICD.Domain/
|   +-- DemoCICD.Infrastructure/
|   +-- DemoCICD.Persistence/
|   +-- DemoCICD.Presentation/
+-- tests/
    +-- DemoCICD.Infrastructure.Tests/
```

Ghi chu trong repo hien tai: dang co mot so ten bi sai chinh ta nhu `Insfrastructure`, `Infrastucture`, `Infrastruction`. Nen thong nhat thanh `Infrastructure` de de doc code, de viet test va tranh loi reference ve sau.

## 2. Tao solution tren Visual Studio

1. Mo Visual Studio.
2. Chon `Create a new project`.
3. Tim template `Blank Solution`.
4. Chon `Next`.
5. Dat ten solution la `DemoCICD`.
6. Chon location la thu muc ban muon luu project.
7. Chon `Create`.

Sau buoc nay, Visual Studio se tao file:

```text
DemoCICD.sln
```

## 3. Tao 3 Solution Folder

Trong `Solution Explorer`:

1. Click chuot phai vao solution `DemoCICD`.
2. Chon `Add` -> `New Solution Folder`.
3. Dat ten folder la `solution items`.
4. Lap lai thao tac tren de tao them:
   - `src`
   - `tests`

Ket qua trong `Solution Explorer` se co:

```text
Solution 'DemoCICD'
+-- solution items
+-- src
+-- tests
```

## 4. Tao cac project trong folder src

Tat ca project source code nen nam trong solution folder `src`.

### 4.1. Tao project Domain

1. Click chuot phai vao solution folder `src`.
2. Chon `Add` -> `New Project`.
3. Tim template `Class Library`.
4. Chon ngon ngu `C#`.
5. Dat project name la `DemoCICD.Domain`.
6. O phan `Location`, chon thu muc `DemoCICD/src`.
7. Chon framework, vi du `.NET 8.0`.
8. Chon `Create`.

`Domain` la layer trong cung, chua entity, value object, domain event, interface thuan domain. Layer nay khong reference project nao khac.

### 4.2. Tao project Application

1. Click chuot phai vao solution folder `src`.
2. Chon `Add` -> `New Project`.
3. Chon template `Class Library`.
4. Dat project name la `DemoCICD.Application`.
5. Location: `DemoCICD/src`.
6. Framework: cung version voi project Domain.
7. Chon `Create`.

`Application` chua use case, command, query, DTO, validator, service interface. Layer nay duoc reference `Domain`.

### 4.3. Tao project Infrastructure

1. Click chuot phai vao solution folder `src`.
2. Chon `Add` -> `New Project`.
3. Chon template `Class Library`.
4. Dat project name la `DemoCICD.Infrastructure`.
5. Location: `DemoCICD/src`.
6. Chon `Create`.

`Infrastructure` chua implementation cho cac service ben ngoai, vi du email, file storage, message broker, cache, third-party client.

### 4.4. Tao project Persistence

1. Click chuot phai vao solution folder `src`.
2. Chon `Add` -> `New Project`.
3. Chon template `Class Library`.
4. Dat project name la `DemoCICD.Persistence`.
5. Location: `DemoCICD/src`.
6. Chon `Create`.

`Persistence` chua database context, migration, repository implementation, entity configuration.

### 4.5. Tao project Presentation

1. Click chuot phai vao solution folder `src`.
2. Chon `Add` -> `New Project`.
3. Chon template `Class Library`.
4. Dat project name la `DemoCICD.Presentation`.
5. Location: `DemoCICD/src`.
6. Chon `Create`.

`Presentation` co the chua endpoint grouping, request/response model, controller helper hoac UI-facing logic tuy cach ban tach layer.

### 4.6. Tao project API

1. Click chuot phai vao solution folder `src`.
2. Chon `Add` -> `New Project`.
3. Tim template `ASP.NET Core Web API`.
4. Dat project name la `DemoCICD.API`.
5. Location: `DemoCICD/src`.
6. Chon framework cung version voi cac project con lai.
7. Chon `Create`.

`API` la project startup, chua `Program.cs`, config DI, middleware, swagger, controller hoac minimal API.

## 5. Thiet lap Project Reference tren Visual Studio

Nguyen tac reference nen theo chieu tu ngoai vao trong:

```text
Domain: khong reference project nao
Application: reference Domain
Infrastructure: reference Application, Domain
Persistence: reference Application, Domain
Presentation: reference Application
API: reference Application, Infrastructure, Persistence, Presentation
Test project: reference tat ca project can kiem tra architecture
```

### 5.1. Them reference cho Application

1. Trong `Solution Explorer`, mo project `DemoCICD.Application`.
2. Click chuot phai vao `Dependencies`.
3. Chon `Add Project Reference`.
4. Tick `DemoCICD.Domain`.
5. Chon `OK`.

### 5.2. Them reference cho Infrastructure

1. Mo project `DemoCICD.Infrastructure`.
2. Click chuot phai `Dependencies`.
3. Chon `Add Project Reference`.
4. Tick:
   - `DemoCICD.Application`
   - `DemoCICD.Domain`
5. Chon `OK`.

### 5.3. Them reference cho Persistence

1. Mo project `DemoCICD.Persistence`.
2. Click chuot phai `Dependencies`.
3. Chon `Add Project Reference`.
4. Tick:
   - `DemoCICD.Application`
   - `DemoCICD.Domain`
5. Chon `OK`.

### 5.4. Them reference cho Presentation

1. Mo project `DemoCICD.Presentation`.
2. Click chuot phai `Dependencies`.
3. Chon `Add Project Reference`.
4. Tick `DemoCICD.Application`.
5. Chon `OK`.

### 5.5. Them reference cho API

1. Mo project `DemoCICD.API`.
2. Click chuot phai `Dependencies`.
3. Chon `Add Project Reference`.
4. Tick:
   - `DemoCICD.Application`
   - `DemoCICD.Infrastructure`
   - `DemoCICD.Persistence`
   - `DemoCICD.Presentation`
5. Chon `OK`.

## 6. Tao file AssemblyReference cho moi project

File `AssemblyReference.cs` giup architecture test lay dung assembly cua tung layer.

Vi du voi project `DemoCICD.Domain`:

1. Click chuot phai vao project `DemoCICD.Domain`.
2. Chon `Add` -> `Class`.
3. Dat ten file la `AssemblyReference.cs`.
4. Thay noi dung file bang:

```csharp
using System.Reflection;

namespace DemoCICD.Domain;

public static class AssemblyReference
{
    public static readonly Assembly Assembly = typeof(AssemblyReference).Assembly;
}
```

Lap lai cho cac project khac, chi thay namespace cho dung:

```text
DemoCICD.Application
DemoCICD.Infrastructure
DemoCICD.Persistence
DemoCICD.Presentation
DemoCICD.API
```

## 7. Tao project test trong folder tests

1. Click chuot phai vao solution folder `tests`.
2. Chon `Add` -> `New Project`.
3. Tim template `xUnit Test Project`.
4. Dat project name la `DemoCICD.Infrastructure.Tests`.
5. Location: `DemoCICD/tests`.
6. Chon framework cung version voi solution, vi du `.NET 8.0`.
7. Chon `Create`.

Neu Visual Studio tao file test mac dinh nhu `UnitTest1.cs`, ban co the doi ten thanh `ArchitectureTests.cs`.

## 8. Cai NuGet package cho test project

Can cai them:

```text
FluentAssertions
NetArchTest.Rules
```

Cach cai tren Visual Studio:

1. Click chuot phai vao project `DemoCICD.Infrastructure.Tests`.
2. Chon `Manage NuGet Packages`.
3. Chon tab `Browse`.
4. Tim `FluentAssertions`.
5. Chon package `FluentAssertions`.
6. Chon version on dinh moi phu hop voi project.
7. Chon `Install`.
8. Lap lai voi package `NetArchTest.Rules`.
9. Neu Visual Studio hien hop thoai license, chon `I Accept`.

Sau khi cai xong, file `.csproj` cua test project se co cac `PackageReference` tuong ung.

## 9. Reference test project toi cac project can kiem tra

1. Mo project `DemoCICD.Infrastructure.Tests`.
2. Click chuot phai vao `Dependencies`.
3. Chon `Add Project Reference`.
4. Tick tat ca project:
   - `DemoCICD.API`
   - `DemoCICD.Application`
   - `DemoCICD.Domain`
   - `DemoCICD.Infrastructure`
   - `DemoCICD.Persistence`
   - `DemoCICD.Presentation`
5. Chon `OK`.

Ly do test project reference tat ca project: architecture test can doc assembly cua cac layer de kiem tra dependency rule.

## 10. Viet architecture test dau tien

Trong project `DemoCICD.Infrastructure.Tests`:

1. Doi ten file test thanh `ArchitectureTests.cs`.
2. Mo file do.
3. Thay noi dung bang:

```csharp
using FluentAssertions;
using NetArchTest.Rules;

namespace DemoCICD.Infrastructure.Tests;

public class ArchitectureTests
{
    private const string ApplicationNamespace = "DemoCICD.Application";
    private const string InfrastructureNamespace = "DemoCICD.Infrastructure";
    private const string PersistenceNamespace = "DemoCICD.Persistence";
    private const string APINamespace = "DemoCICD.API";
    private const string PresentationNamespace = "DemoCICD.Presentation";

    [Fact]
    public void Domain_Should_Not_HaveDependencyOnOtherProjects()
    {
        var otherProjects = new[]
        {
            ApplicationNamespace,
            InfrastructureNamespace,
            PersistenceNamespace,
            APINamespace,
            PresentationNamespace
        };

        var result = Types
            .InAssembly(DemoCICD.Domain.AssemblyReference.Assembly)
            .ShouldNot()
            .HaveDependencyOnAny(otherProjects)
            .GetResult();

        result.IsSuccessful.Should().BeTrue();
    }
}
```

Test nay dam bao layer `Domain` khong phu thuoc vao `Application`, `Infrastructure`, `Persistence`, `API`, `Presentation`.

## 11. Chay test bang Test Explorer

1. Tren thanh menu Visual Studio, chon `Test`.
2. Chon `Test Explorer`.
3. Neu chua thay test, chon `Build` -> `Build Solution`.
4. Trong cua so `Test Explorer`, chon `Run All`.
5. Kiem tra ket qua:
   - Mau xanh: test pass.
   - Mau do: test fail, can doc message loi de sua dependency hoac namespace.

## 12. Them .editorconfig vao solution

File `.editorconfig` dung de thong nhat coding convention cho toan bo solution.

Cach them tren Visual Studio:

1. Click chuot phai vao solution `DemoCICD`.
2. Chon `Add` -> `New Item`.
3. Tim `EditorConfig File`.
4. Dat ten file la `.editorconfig`.
5. Chon `Add`.

Neu Visual Studio khong hien template `.editorconfig`:

1. Click chuot phai vao solution.
2. Chon `Add` -> `New Item`.
3. Chon `Text File`.
4. Dat ten file la `.editorconfig`.
5. Chon `Add`.

Sau do them file vao solution folder `solution items`:

1. Click chuot phai vao solution folder `solution items`.
2. Chon `Add` -> `Existing Item`.
3. Chon file `.editorconfig`.
4. Chon `Add`.

## 13. Them Directory.Build.props cho analyzer va smell code

File `Directory.Build.props` dat cung cap voi file `.sln`. MSBuild tu dong ap dung file nay cho cac project con.

Cach tao tren Visual Studio:

1. Click chuot phai vao solution.
2. Chon `Add` -> `New Item`.
3. Chon `Text File`.
4. Dat ten file la `Directory.Build.props`.
5. Chon `Add`.
6. Dan noi dung sau vao file:

```xml
<Project>
  <PropertyGroup>
    <AnalysisLevel>latest</AnalysisLevel>
    <AnalysisMode>All</AnalysisMode>
    <TreatWarningsAsErrors>false</TreatWarningsAsErrors>
    <CodeAnalysisTreatWarningsAsErrors>false</CodeAnalysisTreatWarningsAsErrors>
    <EnforceCodeStyleInBuild>true</EnforceCodeStyleInBuild>
  </PropertyGroup>

  <ItemGroup>
    <PackageReference Include="StyleCop.Analyzers" Version="1.1.118" PrivateAssets="all" Condition="$(MSBuildProjectExtension) == '.csproj'" />
    <PackageReference Include="SonarAnalyzer.CSharp" Version="9.7.0.75501" PrivateAssets="all" Condition="$(MSBuildProjectExtension) == '.csproj'" />
  </ItemGroup>
</Project>
```

Them file nay vao solution folder `solution items`:

1. Click chuot phai vao `solution items`.
2. Chon `Add` -> `Existing Item`.
3. Chon `Directory.Build.props`.
4. Chon `Add`.

Sau khi them file nay, moi lan build Visual Studio se restore analyzer package va hien warning ve code style, smell code, rule cua SonarAnalyzer.

## 14. Tao .gitignore de khong day file rac len Git

Trong project .NET, khong nen day cac file sau len Git:

```text
.vs/
bin/
obj/
TestResults/
coverage/
*.user
*.suo
*.log
```

Cach tao `.gitignore` tren Visual Studio:

1. Click chuot phai vao solution.
2. Chon `Add` -> `New Item`.
3. Chon `Text File`.
4. Dat ten file la `.gitignore`.
5. Chon `Add`.
6. Dan noi dung co ban:

```gitignore
[Bb]in/
[Oo]bj/
.vs/
TestResults/
coverage/
coverage.*
*.coverage
*.trx
*.user
*.suo
*.log
*.tmp
*.cache
.DS_Store
Thumbs.db
Desktop.ini
```

Trong repo hien tai da co file `.gitignore`, nen Visual Studio Git Changes se khong hien `bin/`, `obj/`, `.vs/` de commit nua.

## 15. Loai bo file rac dang bi hien trong Git Changes

Neu trong `Git Changes` van thay file rac:

1. Kiem tra file do co nam trong `.gitignore` chua.
2. Neu la `.vs`, `bin`, `obj`, `TestResults`, khong commit.
3. Dong Visual Studio neu can xoa thu muc `.vs` vi thu muc nay hay bi Visual Studio lock.
4. Mo lai Visual Studio.
5. Kiem tra lai `Git Changes`.

Neu file rac da tung bi add/tracked truoc do, `.gitignore` khong tu go no ra khoi Git. Khi hoc CI/CD, cach de hieu don gian la:

```text
.gitignore chi chan file chua tracked.
File da tracked thi phai remove khoi tracking truoc, sau do .gitignore moi co tac dung.
```

Co the xu ly bang Visual Studio:

1. Mo `Git Changes`.
2. Neu thay file rac, click chuot phai vao file.
3. Chon `Delete` neu do la output build co the tao lai.
4. Commit thay doi xoa file rac cung voi `.gitignore`.

## 16. Build solution tren Visual Studio

1. Tren thanh menu, chon `Build`.
2. Chon `Build Solution`.
3. Mo cua so `Output`.
4. Chon output tu `Build`.
5. Kiem tra:
   - Khong co compile error.
   - Analyzer warning co the xuat hien do `Directory.Build.props`.
   - Neu warning qua nhieu, sua dan theo rule.

## 17. Chay API de kiem tra nhanh

1. Click chuot phai vao project `DemoCICD.API`.
2. Chon `Set as Startup Project`.
3. Nhan nut Run mau xanh tren Visual Studio.
4. Chon profile HTTPS neu co.
5. Neu Swagger duoc bat, trinh duyet se mo trang swagger cua API.

## 18. Kiem tra truoc khi commit

Truoc khi commit:

1. Chon `Build` -> `Build Solution`.
2. Chon `Test` -> `Test Explorer` -> `Run All`.
3. Mo `Git Changes`.
4. Kiem tra danh sach file thay doi.
5. Chi commit:
   - Source code `.cs`.
   - Project file `.csproj`.
   - Solution file `.sln`.
   - `.editorconfig`.
   - `Directory.Build.props`.
   - `.gitignore`.
   - File test.
   - File huong dan `.md`.
6. Khong commit:
   - `.vs/`
   - `bin/`
   - `obj/`
   - `TestResults/`
   - file `.user`
   - file log/cache.

## 19. Goi y sua repo hien tai

Repo hien tai nen sua tiep cac diem sau:

- Doi ten `DemoCICD.Insfrastructure` thanh `DemoCICD.Infrastructure`.
- Doi ten `DemoCICD.Infrastucture.Tests` thanh `DemoCICD.Infrastructure.Tests`.
- Doi namespace `DemoCICD.Infrastruction` trong test thanh `DemoCICD.Infrastructure`.
- Dua `DemoCICD.Persistence` vao trong `src/` de dung cau truc `src`.
- Sau khi doi ten, mo file `.sln` bang Visual Studio va kiem tra lai project reference.

## 20. Thu tu lam bai de de nho

1. Tao blank solution.
2. Tao solution folder `solution items`, `src`, `tests`.
3. Tao cac project trong `src`.
4. Them project reference dung chieu Clean Architecture.
5. Tao `AssemblyReference.cs` cho tung project.
6. Tao xUnit test project trong `tests`.
7. Cai `FluentAssertions` va `NetArchTest.Rules`.
8. Viet architecture test.
9. Them `.editorconfig`.
10. Them `Directory.Build.props`.
11. Them `.gitignore`.
12. Build solution.
13. Run all tests.
14. Kiem tra `Git Changes`.
15. Commit source code, khong commit file rac.
