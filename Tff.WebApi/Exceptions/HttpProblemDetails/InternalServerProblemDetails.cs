using Microsoft.AspNetCore.Mvc;

namespace Tff.WebApi.Exceptions.HttpProblemDetails;

public sealed class InternalServerProblemDetails : ProblemDetails
{
    public InternalServerProblemDetails()
    {
        Title = "Internal Server Error";
        Detail = "Internal Server Error";
        Status = StatusCodes.Status500InternalServerError;
        Type = "Internal Server Error";
    }
}