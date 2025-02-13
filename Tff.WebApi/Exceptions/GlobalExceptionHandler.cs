using Microsoft.AspNetCore.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using System.Text.Json;
using Tff.WebApi.Exceptions.Types;

namespace Tff.WebApi.Exceptions;

public class GlobalExceptionHandler : IExceptionHandler
{
    public async ValueTask<bool> TryHandleAsync(HttpContext httpContext, Exception exception, CancellationToken cancellationToken)
    {
        if(exception is NotFoundException notFoundException)
        {
            httpContext.Response.StatusCode = 404;
            object problemDetails = new
            {
                Title = "Notfound Exception",
                Detail = notFoundException.Message,
                Status = 404
            };
            string jsonA = JsonSerializer.Serialize(problemDetails);

            await httpContext.Response.WriteAsync(jsonA);

            return false;

        }


        if (exception is BusinessException businessException)
        {
            httpContext.Response.StatusCode = 400;
            ProblemDetails problemDetails1 = new ProblemDetails
            {
                Title = "Business Exception",
                Detail = businessException.Message,
                Status = 400
            };
            string jsonA = JsonSerializer.Serialize(problemDetails1);

            await httpContext.Response.WriteAsync(jsonA);

            return false;

        }

        return true;
    }
}
