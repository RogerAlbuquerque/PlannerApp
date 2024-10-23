using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using Planner.Exception.ExceptionBase;

namespace Planner.Api.Filters;

public class ExceptionFilter : IExceptionFilter
{
    public void OnException(ExceptionContext context)
    {
        if(context.Exception is PlannerException)
        {
            var plannerException = (PlannerException)context.Exception;
            context.HttpContext.Response.StatusCode = (int)plannerException.GetStatusCode();
            context.Result = new ObjectResult(context.Exception.Message);
        }
        else
        {
            context.HttpContext.Response.StatusCode = StatusCodes.Status500InternalServerError;
            context.Result = new ObjectResult("Unknow error");
        }
    }
}
