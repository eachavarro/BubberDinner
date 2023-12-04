using System.Net;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;

namespace BuberDinner.Api.Filters;

public class ErrorHandlingFilterAttribute : ExceptionFilterAttribute
{
    public override void OnException(ExceptionContext context)
    {

        var exception = context.Exception;

        var problemDetails = new ProblemDetails{
            Title = "An error ocurred while processing your request",
            Status = (int) HttpStatusCode.InternalServerError,

            // Instance = context.HttpContext.Request.Path,
            
            // Detail = exception.Message
        };



        context.Result = new ObjectResult(problemDetails);
       
        context.ExceptionHandled  = true;
    }
}