namespace Planner.Exception.ExceptionBase;

public class NotFoundException : PlannerException
{
    public NotFoundException(string message) : base(message)
    {
    }
}
