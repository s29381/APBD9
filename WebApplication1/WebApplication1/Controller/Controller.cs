using Microsoft.AspNetCore.Mvc;
using WebApplication1.Service;

namespace WebApplication1.Controller;

[ApiController]
[Route("api")]
public class Controller
{
    private readonly IService _service;
    public Controller(IService service)
    {
        _service = service;
    }

    [HttpDelete]
    [Route("/api/clients/{idClient}")]
    public async Task<IActionResult> Delete([FromRoute] int idClient)
    {
        try
        {
            if (await _service.Delete(idClient) != -1)
            {
                return NoContent();
            }
            return Conflict("Cannot delete client");
        }
        catch (NotFoundException e)
        {
            return NotFound(e.Message);
        }
    }

    [HttpGet]
    [Route("/api/trips/all")]
    public async Task<IActionResult> GetAll()
    {
        var trips = await _service.GetAll();
        return Ok(trips);
    }
    
    [HttpGet]
    [Route("/api/trips/date")]
    public async Task<IActionResult> GetByDate([FromQuery] DateTime dateTime)
    {
        var trips = await _service.GetByStartDate(dateTime);
        return Ok(trips);
    }

    [HttpPost]
    [Route("/api/trips/{idTrip}/clients")]
    public async Task<IActionResult> AddToTrip([FromBody] ClientDTO clientDto, [FromRoute] int idTrip)
    {
        try
        {
            if (await _service.AddToTrip(idTrip, clientDto))
            {
                return Created();
            }
            return BadRequest("Couldn't add client to trip");
        }
        catch (NotFoundException e)
        {
            return NotFound(e.Message);
        }
    }
}