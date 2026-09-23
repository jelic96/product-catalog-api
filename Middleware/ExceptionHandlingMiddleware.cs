using System.Net;

namespace ProductCatalogApi.Middleware;

public class ExceptionHandlingMiddleware(RequestDelegate next, ILogger<ExceptionHandlingMiddleware> logger)
{
    public async Task InvokeAsync(HttpContext context)
    {
        try
        {
            await next(context);
        }
        catch (KeyNotFoundException exception)
        {
            logger.LogWarning(exception, "Requested resource was not found.");
            await WriteError(context, HttpStatusCode.NotFound, exception.Message);
        }
        catch (Exception exception)
        {
            logger.LogError(exception, "An unhandled exception occurred.");
            await WriteError(context, HttpStatusCode.InternalServerError, "An unexpected error occurred.");
        }
    }

    private static Task WriteError(HttpContext context, HttpStatusCode statusCode, string message)
    {
        context.Response.StatusCode = (int)statusCode;
        return context.Response.WriteAsJsonAsync(new { status = (int)statusCode, message });
    }
}
