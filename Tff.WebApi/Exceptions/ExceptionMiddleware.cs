using Tff.WebApi.Exceptions.Handlers;

namespace Tff.WebApi.Exceptions;

public class ExceptionMiddleware
{

    private readonly RequestDelegate _next;
    private readonly HttpExceptionHandler _httpExceptionHandler;

    public ExceptionMiddleware(RequestDelegate next)
    {
        _next = next;
        _httpExceptionHandler = new HttpExceptionHandler();
    }



    public async Task Invoke(HttpContext httpContext)
    {
        try
        {

            await _next(httpContext);

        }catch(Exception exception)
        {
            httpContext.Response.ContentType = "application/json";
            _httpExceptionHandler.Response = httpContext.Response;

            await _httpExceptionHandler.HandleExceptionAsync(exception);
        }
    }

   
}
