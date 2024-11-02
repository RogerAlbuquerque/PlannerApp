using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using Planner.Exception.ExceptionBase;
using Planner.Communication.Responses;

namespace Planner.Api.Filters;

public class ExceptionFilter : IExceptionFilter
{
    public void OnException(ExceptionContext context)
    {
        if(context.Exception is PlannerException)
        {
            var plannerException = (PlannerException)context.Exception;

            context.HttpContext.Response.StatusCode = (int)plannerException.GetStatusCode();
            
            var responseJson = new ResponseErrorsJson(plannerException.GetErrorMessages());
            
            context.Result = new ObjectResult(responseJson);
        }
        else
        {
            context.HttpContext.Response.StatusCode = StatusCodes.Status500InternalServerError;

            //var list = new List<string>();
            //list.Add("Unknow error");

            var responseJson = new ResponseErrorsJson(new List<string> {"Unknow error"});
            context.Result = new ObjectResult(responseJson);
        }
    }
}
