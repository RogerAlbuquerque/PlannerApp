using Microsoft.AspNetCore.Mvc;
using Planner.Application.UseCases.Trips.GetAll;
using Planner.Application.UseCases.Trips.GetById;
using Planner.Application.UseCases.Trips.Register;
using Planner.Communication.Requests;
using Planner.Communication.Responses;
using Planner.Exception.ExceptionBase;

namespace Planner.Api.Controllers;

[Route("api/[controller]")]
[ApiController]
public class TripsController : ControllerBase
{
    [HttpPost]
    [ProducesResponseType(typeof(ResponseShortTripJson), StatusCodes.Status201Created)]
    [ProducesResponseType(typeof(string), StatusCodes.Status400BadRequest)]
    public IActionResult Register([FromBody] RequestRegisterTripJson request)
    {
        try
        {
            var useCase = new RegisterTripUseCase();

            var response = useCase.Execute(request);

            return Created(string.Empty, response);
        }

        catch (PlannerException ex)
        {
            return BadRequest(ex.Message);
        }
        catch
        {
            return StatusCode(StatusCodes.Status500InternalServerError, "Unknown error");
        }
    }

    [HttpGet]
    [ProducesResponseType(typeof(ResponseTripJson), StatusCodes.Status200OK)]
    public IActionResult GetAll()
    {
        var userCase = new GetAllTripsUseCase();
        var response = userCase.Execute();
        return Ok(response);
    }

    [HttpGet]
    [Route("{id}")]
    [ProducesResponseType(typeof(ResponseTripJson), StatusCodes.Status200OK)]
    public IActionResult GetById([FromRoute] Guid id) 
    {
        var useCase = new GetTripByIdUseCase();

        var response = useCase.Execute(id);
        return Ok(response);
    }
}
