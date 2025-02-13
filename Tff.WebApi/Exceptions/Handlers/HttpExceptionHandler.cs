using System.Text.Json;
using Tff.WebApi.Exceptions.HttpProblemDetails;
using Tff.WebApi.Exceptions.Types;

namespace Tff.WebApi.Exceptions.Handlers;

public class HttpExceptionHandler : ExceptionHandler
{

    public HttpResponse Response { get; set; }

    protected override Task HandleException(BusinessException businessException)
    {
        Response.StatusCode = StatusCodes.Status400BadRequest;
        BusinessProblemDetails details = new BusinessProblemDetails(businessException.Message);
        string json = JsonSerializer.Serialize(details);
        return Response.WriteAsync(json);
    }

    protected override Task HandleException(NotFoundException notFoundException)
    {
        Response.StatusCode = StatusCodes.Status404NotFound;
        NotFoundProblemDetails details = new NotFoundProblemDetails(notFoundException.Message);
        string json = JsonSerializer.Serialize(details);
        return Response.WriteAsync(json);
    }

    protected override Task HandleException(Exception exception)
    {
        Response.StatusCode = StatusCodes.Status404NotFound;
        InternalServerProblemDetails details = new InternalServerProblemDetails();
        string json = JsonSerializer.Serialize(details);
        return Response.WriteAsync(json);
    }
}
