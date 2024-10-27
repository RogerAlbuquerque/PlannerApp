using System.Net;

namespace Planner.Exception.ExceptionBase;

public abstract class PlannerException(string message) : SystemException(message)
{

    public abstract HttpStatusCode GetStatusCode();
    public abstract IList<string> GetErrorMessages();

}
