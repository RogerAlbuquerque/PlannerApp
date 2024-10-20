using Planner.Communication.Responses;
using Planner.Infrastructure;

namespace Planner.Application.UseCases.Trips.GetById;

public class GetTripByIdUseCase
{
    public ResponseTripJson Execute(Guid id)
    {
        var dbContext = new PlannerDbContext();

        var trip = dbContext.Trips.FirstOrDefault(trip => trip.Id == id);

        return new ResponseTripJson
        {
            Id = trip.Id,
            Name = trip.Name,
            StartDate = trip.StartDate,
            EndDate = trip.EndDate,
            Activities = trip.Activities.Select(activity => new ResponseActivityJson
            {
                Id = activity.Id,
                Name = activity.Name,
                Date = activity.Date,
                Status = (Communication.Enums.ActivityStatus)activity.Status
            }).ToList(),
        };
    }
}
