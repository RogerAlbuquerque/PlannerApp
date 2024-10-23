namespace Planner.Exception.ExceptionBase;

public class ErrorOnValidationException : PlannerException
{
    public ErrorOnValidationException(string message) : base(message)
    {
    }
}
