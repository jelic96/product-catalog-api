using ProductCatalogApi.Middleware;
using ProductCatalogApi.Services;
using ProductCatalogApi.Storage;

var builder = WebApplication.CreateBuilder(args);

// Keep local development logging portable; production can add its preferred providers.
builder.Logging.ClearProviders();
builder.Logging.AddConsole();

builder.Services.AddControllers();
builder.Services.AddOpenApi();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// The store owns the in-memory data for the lifetime of the application.
builder.Services.AddSingleton<ProductStore>();
// Business services are created once per HTTP request.
builder.Services.AddScoped<IProductService, ProductService>();

var app = builder.Build();

app.UseMiddleware<ExceptionHandlingMiddleware>();
app.UseHttpsRedirection();
app.UseMiddleware<RequestTimingMiddleware>();

app.UseSwagger();
app.UseSwaggerUI();

app.UseAuthorization();

app.MapOpenApi();
app.MapControllers();

app.Run();
