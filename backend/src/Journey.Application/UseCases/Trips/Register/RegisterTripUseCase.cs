using Planner.Communication.Requests;
using Planner.Exception;
using Planner.Exception.ExceptionBase;
using System.Reflection;

namespace Planner.Application.UseCases.Trips.Register;

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
            throw new PlannerException(ResourceErrorMessages.NAME_EMPTY);
        }

        if (request.StartDate.Date < DateTime.UtcNow.Date)
        {
            throw new PlannerException(ResourceErrorMessages.DATE_TRIP_MUST_BE_LATER_THAN_TODAY);
        }

        if (request.EndDate.Date <= request.StartDate.Date)
        {
            throw new PlannerException(ResourceErrorMessages.END_DATE_TRIP_MUST_BE_LATER_START_DATE);
        }
    }

}
