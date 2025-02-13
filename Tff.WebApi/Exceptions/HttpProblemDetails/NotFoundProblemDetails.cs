using Microsoft.AspNetCore.Mvc;

namespace Tff.WebApi.Exceptions.HttpProblemDetails;

public sealed class NotFoundProblemDetails : ProblemDetails
{
    public NotFoundProblemDetails(string detail)
    {
        Title = "Not Found Rules";
        Detail = detail;
        Status = StatusCodes.Status404NotFound;
        Type = "Not Found Exception";
    }
}
