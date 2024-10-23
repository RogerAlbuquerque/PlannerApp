namespace Planner.Exception.ExceptionBase;

internal class ErrorOnValidationException : PlannerException
{
    public ErrorOnValidationException(string message) : base(message)
    {
    }
}
