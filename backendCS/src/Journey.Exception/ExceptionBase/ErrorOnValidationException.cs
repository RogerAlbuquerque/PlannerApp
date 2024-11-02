using Planner.Exception.ExceptionBase;
using System.Net;

namespace Planner.Exception.ExceptionsBase;

public class ErrorOnValidationException(IList<string> errors) : PlannerException(string.Empty)
{
    private readonly IList<string> _errors = errors;

    public override IList<string> GetErrorMessages()
    {
        return _errors;
    }
    public override HttpStatusCode GetStatusCode()
    {
        return HttpStatusCode.BadRequest;
    }

}