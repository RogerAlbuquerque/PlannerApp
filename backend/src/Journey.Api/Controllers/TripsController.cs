using Planner.Application.UseCases.Trips.Register;
using Planner.Communication.Requests;
using Planner.Exception.ExceptionBase;
using Microsoft.AspNetCore.Mvc;

namespace Planner.Api.Controllers;

[Route("api/[controller]")]
[ApiController]
public class TripsController : ControllerBase
{
    [HttpPost]
    public IActionResult Register([FromBody] RequestRegisterTripJson request)
    {
        try 
        {
            var useCase = new RegisterTripUseCase();

            useCase.Execute(request);

            return Created();
        }

        catch (PlannerException ex)
        {
            return BadRequest(ex.Message);
        }
    }
}
