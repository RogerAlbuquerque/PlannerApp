using Planner.Exception;
using Planner.Exception.ExceptionBase;
using Planner.Infrastructure;
using Planner.Infrastructure.Enums;

namespace Planner.Application.UseCases.Trips.Activities.Complete;

public class CompleteActivityForTripUseCase
{
    public void Execute(Guid tripId, Guid activityId)
    {
        var dbContext = new PlannerDbContext();
        var activity = dbContext
            .Activities
            .FirstOrDefault(activity => activity.Id == activityId && activity.TripId == tripId);

        if (activity is null)
        {
            throw new NotFoundException(ResourceErrorMessages.ACTIVITY_NOT_FOUND);
        }

        activity.Status = ActivityStatus.Done;
        
        dbContext.Activities.Update(activity);
        dbContext.SaveChanges();
    }
}