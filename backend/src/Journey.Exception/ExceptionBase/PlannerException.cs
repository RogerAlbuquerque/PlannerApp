namespace Planner.Exception.ExceptionBase;

public abstract class PlannerException : SystemException
{
    public PlannerException(string message) : base(message)
    {
    
    }

}
