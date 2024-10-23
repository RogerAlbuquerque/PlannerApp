





namespace Planner.Application.UseCases.Trips.Register
{
    [Serializable]
    internal class ErrorOnValidationException : System.Exception
    {
        public ErrorOnValidationException()
        {
        }

        public ErrorOnValidationException(string? message) : base(message)
        {
        }

        public ErrorOnValidationException(string? message, System.Exception? innerException) : base(message, innerException)
        {
        }
    }
}