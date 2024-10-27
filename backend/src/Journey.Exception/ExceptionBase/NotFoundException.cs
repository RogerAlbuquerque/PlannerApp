using System.Net;

namespace Planner.Exception.ExceptionBase;

public class NotFoundException(string message) : PlannerException(message)
{
    //public NotFoundException(string message) : base(message)
    //{
    //}

    public override IList<string> GetErrorMessages()
    {
        return new List<string>()
        {
            Message
        };
    }

    public override HttpStatusCode GetStatusCode()
    {
        return HttpStatusCode.NotFound;
    }
}
