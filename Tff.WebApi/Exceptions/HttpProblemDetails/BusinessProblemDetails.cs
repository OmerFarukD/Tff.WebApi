using Microsoft.AspNetCore.Mvc;

namespace Tff.WebApi.Exceptions.HttpProblemDetails;

public sealed class BusinessProblemDetails : ProblemDetails
{


    public BusinessProblemDetails(string detail)
    {
        Title = "Business Rules";
        Detail = detail;
        Status = StatusCodes.Status400BadRequest;
        Type = "Business Exception";
    }
}
