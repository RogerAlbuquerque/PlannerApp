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

    }

}
