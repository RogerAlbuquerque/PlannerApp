using Planner.Communication.Requests;
using Planner.Communication.Responses;
using Planner.Exception;
using Planner.Exception.ExceptionBase;
using Planner.Infrastructure;
using Planner.Infrastructure.Entities;

namespace Planner.Application.UseCases.Trips.Register;

public class RegisterTripUseCase
{
    public ResponseShortTripJson Execute(RequestRegisterTripJson request)
    {
        Validate(request);

        var dbContext = new PlannerDbContext();

        var entity = new Trip
        {
            Name = request.Name,
            StartDate = request.StartDate,
            EndDate = request.EndDate,
        };

        dbContext.Trips.Add(entity);

        dbContext.SaveChanges();

        return new ResponseShortTripJson
        {
            EndDate = entity.EndDate,
            StartDate = entity.StartDate,
            Name = entity.Name,
            Id = entity.Id

        };

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
