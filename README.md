# Product Catalog API

REST API for managing product catalog data.

## Technologies
- ASP.NET Core
- C#
- Entity Framework Core
- Swagger / OpenAPI

## Run the project
1. Clone the repository
2. Open the project in Visual Studio or VS Code
3. Run:
   dotnet run
4. Open Swagger using the URL shown in the console.

## Main endpoints
- GET /api/products
- GET /api/products/{id}
- POST /api/products
- PUT /api/products/{id}
- DELETE /api/products/{id}

## Middleware
The API uses exception handling, HTTPS redirection, authentication, and authorization middleware.
