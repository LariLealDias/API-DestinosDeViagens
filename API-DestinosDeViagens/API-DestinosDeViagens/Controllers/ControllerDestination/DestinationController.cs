using API_DestinosDeViagens.Data.Dtos.DtoDestination;
using API_DestinosDeViagens.Models;
using API_DestinosDeViagens.Services;
using Microsoft.AspNetCore.JsonPatch;
using Microsoft.AspNetCore.Mvc;

namespace API_DestinosDeViagens.Controllers.ControllerDestination;

[ApiController]
[Route("[Controller]")]
public class DestinationController : ControllerBase
{
    private DestinationService _destinationService;
    private RoadTripService _roadTripService;
    public DestinationController(DestinationService destinationService, RoadTripService roadTripService)
    {
        _destinationService = destinationService;
        _roadTripService = roadTripService; 
    }

    [HttpPost]
    public IActionResult CreateDestintation([FromBody] CreateDestinationDto destinationDto)
    {
        try
        {


            DestinationModel destination = _destinationService.Add(destinationDto);

            //send a location  
            var controllerName = ControllerContext.ActionDescriptor.ControllerName;
            var localhostAddress = HttpContext.Request.Host.ToUriComponent();
            var resourceUrl = $"https://{localhostAddress}/{controllerName}/{destination.Id}";

            //response
            var response = new
            {
                Id = destination.Id,
                PhotoPath = destination.PhotoPath,
                Title = destination.Title,
                Price = destination.Price
            };

            return Created(resourceUrl, response);

        }
        catch (Exception e)
        {
            return BadRequest(e.Message);
        }
    }


    [HttpGet]
    public IActionResult GetDestination([FromQuery] int skip = 0, [FromQuery] int take = 6)
    {
        try
        {
            IEnumerable<ReadDestinationDto> destination = _destinationService.GetPaging(skip, take);

            if (destination != null && destination.Any())
            {
                return Ok(destination);
            }
            return NoContent();

        } catch (Exception e)
        {
            return BadRequest(e.Message);
        }
    }


    [HttpGet("{id}")]
    public IActionResult GetDestinationById(int id)
    {
        try
        {
            var destination = _destinationService.GetById(id);

            if (destination != null)
            {
                var mappingDto = _destinationService.GetMappingById(id);
                return Ok(mappingDto);
            }

            return NotFound();

        }
        catch (Exception e)
        {
            return BadRequest(e.Message);
        }
    }

    
    [HttpGet("title/{title}")] //outra forma de fazer busca 
    public IActionResult GetDestinationByTitle(string title)
    {
        try
        {
            var titleDestination = _destinationService.GetByTitle(title);


            if (titleDestination != null && titleDestination.Any())
            {
                return Ok(titleDestination);
            }


            var response = new
            {
                message = "Nenhum destino foi encontrado"
            };

            return Ok(response);

        }
        catch (Exception e)
        {
            return BadRequest(e.Message);
        }
    }


    [HttpPatch("{id}")]
    public IActionResult UpdateDestination(int id, JsonPatchDocument<UpdateDestinationDto> patch)
    {
        try
        {
            var idDestination = _destinationService.GetById(id);

            if (idDestination != null)
            {
                var destinationToUpdate = _destinationService.PrepareDestinationForUpdate(id);
                patch.ApplyTo(destinationToUpdate, ModelState);

                if (!TryValidateModel(destinationToUpdate))
                {
                    return ValidationProblem(ModelState);
                }

                _destinationService.ApplyUpdateValues(destinationToUpdate, idDestination);
                var readDto = _destinationService.GetMappingById(id);
                return Ok(readDto);
            }

            return NotFound();

        }
        catch (Exception e)
        {
            return BadRequest(e.Message);
        }
    }


    [HttpDelete("{id}")]
    public IActionResult DeleteDestination(int id)
    {
        try
        {
            var idDestination = _destinationService.GetById(id);
            if (idDestination != null)
            {
                _destinationService.DeleteById(idDestination);
                return NoContent();
            }

            return NotFound();

        }
        catch (Exception e)
        {
            return BadRequest(e.Message);
        }
    }
}
