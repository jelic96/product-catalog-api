# Product Catalog API

A REST API for managing product catalog data. It demonstrates controller-based ASP.NET Core API design, a service layer, dependency injection, OpenAPI documentation, validation, and custom middleware.

## Technology

- ASP.NET Core / C# (.NET 10)
- Controller-based REST API
- OpenAPI documentation
- In-memory data store for a simple, self-contained demo

## Run the project

1. Open the `ProductCatalogApi.csproj` file in Visual Studio or VS Code.
2. Run `dotnet run` from this folder.
3. Open Swagger UI at the URL printed in the console followed by `/swagger` (for example, `http://localhost:5023/swagger`).

## Endpoints

| Method | Endpoint | Purpose |
| --- | --- | --- |
| GET | `/api/products` | List products |
| GET | `/api/products/{id}` | Get one product |
| POST | `/api/products` | Create a product |
| PUT | `/api/products/{id}` | Update a product |
| DELETE | `/api/products/{id}` | Delete a product |

### Example request body

```json
{
  "name": "Mechanical Keyboard",
  "description": "Compact mechanical keyboard with backlight.",
  "price": 89.99,
  "category": "Electronics",
  "stockQuantity": 15
}
```

## Architecture

- `Controllers` handles HTTP requests and responses.
- `Services` contains product business operations and can be unit-tested independently through `IProductService`.
- `Storage` contains the in-memory product store.
- `Middleware` provides global exception handling and request-duration logging.

`ProductService` is registered as scoped, so a service instance is created per HTTP request. The in-memory store is singleton so example products persist for the duration of the application.
