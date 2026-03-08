# DapperExtensions

[![CI](https://github.com/ShahJe/DapperExtensions/actions/workflows/ci.yml/badge.svg)](https://github.com/ShahJe/DapperExtensions/actions/workflows/ci.yml)

Helper methods for Dapper: GetOne, GetMany, GetScalar, GetScalarBool, GetScalarDate, NonQuery, and their async counterparts.

NuGet package: [ShahJe.Sql.Dapper.Extensions](https://www.nuget.org/packages/ShahJe.Sql.Dapper.Extensions)

## Installation

```bash
dotnet add package ShahJe.Sql.Dapper.Extensions
```

## Quick Start

### Register in DI

```csharp
// Sync repository
services.AddScoped<IRepository>(_ => new Repository("your-connection-string"));

// Async repository
services.AddScoped<IAsyncRepository>(_ => new AsyncRepository("your-connection-string"));
```

### Usage

```csharp
public class MyService
{
    private readonly IAsyncRepository _repo;

    public MyService(IAsyncRepository repo) => _repo = repo;

    public async Task<IEnumerable<Customer>> GetCustomers()
    {
        var param = new DynamicParameters();
        param.Add("@Active", true);
        return await _repo.GetManyAsync<Customer>("GetActiveCustomers", param);
    }

    public async Task<Customer> GetCustomer(int id)
    {
        var param = new DynamicParameters();
        param.Add("@Id", id);
        return await _repo.GetOneAsync<Customer>("GetCustomerById", param);
    }
}
```

## Breaking Changes in v3.0.0

- **`System.Data.SqlClient` replaced with `Microsoft.Data.SqlClient`** — update any direct references
- **`Connection()` now returns `IDbConnection`** instead of `SqlConnection`
- **`ConnectionAsync()` now returns `Task<IDbConnection>`** instead of `Task<SqlConnection>`
- Target frameworks updated to `netstandard2.0`, `netstandard2.1`, and `net8.0`
