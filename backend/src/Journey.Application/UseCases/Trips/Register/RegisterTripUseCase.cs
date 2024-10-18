using Journey.Communication.Requests;
using Journey.Exception.ExceptionBase;

namespace Journey.Application.UseCases.Trips.Register;

public class RegisterTripUseCase
{
    public void Execute(RequestRegisterTripJson request)
    {
        Validate(request);
    }

    private void Validate(RequestRegisterTripJson request)
    {
        if (string.IsNullOrWhiteSpace(request.Name))
        {
            throw new PlannerException("Name cannot be empty");
        }

        if (request.StartDate.Date < DateTime.UtcNow.Date)
        {
            throw new PlannerException("Trip cannot be booked for a past date");
        }

        if (request.EndDate.Date <= request.StartDate.Date)
        {
            throw new PlannerException("The trip must end after the start date");
        }
    }

}
