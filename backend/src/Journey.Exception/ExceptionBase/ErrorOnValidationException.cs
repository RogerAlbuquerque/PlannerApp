using Planner.Exception.ExceptionBase;
using System.Net;

namespace Planner.Application.UseCases.Trips.Register;

public class ErrorOnValidationException : PlannerException
{


    public ErrorOnValidationException(string message) : base(message)
    {
    }

    public override HttpStatusCode GetStatusCode()
    {
        return HttpStatusCode.BadRequest;
    }
}