using Journey.Communication.Requests;

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
            throw new ArgumentException("Name cannot be empty");
        }

        if (request.StartDate < DateTime.UtcNow.Date)
        {
            throw new ArgumentException("Trip cannot be booked for a past date");
        }

        if (request.EndDate.Date <= request.StartDate.Date)
        {
            throw new ArgumentException("The trip must end after the start date");
        }
    }

}
