using API_DestinosDeViagens.Data.Dtos.DtoCustomer;
using API_DestinosDeViagens.Data.Dtos.DtoTestimonial;
using API_DestinosDeViagens.Models;
using API_DestinosDeViagens.Services;
using Microsoft.AspNetCore.JsonPatch;
using Microsoft.AspNetCore.Mvc;

namespace API_DestinosDeViagens.Controllers.ControllerTestimonial;

[ApiController]
[Route("[controller]")]
public class TestimonialController : ControllerBase
{
    private TestimonialService _testimonialService;
    public TestimonialController(TestimonialService testimonialService)
    {
        _testimonialService = testimonialService;
    }

    [HttpPost]
    public IActionResult CreateTestimonial([FromBody] CreateTestimonialDto testimonialDto)
    {
        try
        {
            if (testimonialDto.Title == null)
            {

            }


            TestimonialModel testimonial = _testimonialService.Add(testimonialDto);

            //send a location  
            var controllerName = ControllerContext.ActionDescriptor.ControllerName;
            var localhostAddress = HttpContext.Request.Host.ToUriComponent();
            var resourceUrl = $"https://{localhostAddress}/{controllerName}/{testimonial.Id}";

            //send the object created
            var response = new 
            {
                id = testimonial.Id,
                title = testimonial.Title,
                text = testimonial.Text,
                CustomerModelId = testimonial.CustomerModel
            };

            return Created(resourceUrl, response);
        }
        catch (Exception e)
        {
            return BadRequest(e.Message);
        }
    }


    [HttpGet]
    public IActionResult GetTestimonial([FromQuery] int skip = 0, [FromQuery] int take = 3)
    {
        try
        {
            IEnumerable<ReadTestimonialDto> testimonials = _testimonialService.GetPaging(skip, take);

            if (testimonials != null && testimonials.Any())
            {
                return Ok(testimonials);
            }

            return NoContent();

        }
        catch (Exception e)
        {
            return BadRequest(e.Message);
        }
    }


    [HttpGet("{id}")]
    public IActionResult GetTestimonialById(int id)
    {
        try
        {
            var testimonialId = _testimonialService.GetById(id);

            if (testimonialId != null)
            {
                var testimonial = _testimonialService.GetMappingById(id);
                return Ok(testimonial);
            }

            return NotFound();

        }
        catch (Exception e)
        {
            return BadRequest(e.Message);
        }
    }


    [HttpPatch("{id}")]
    public IActionResult UpdateTestimonial(int id, JsonPatchDocument<UpdateTestimonialDto> patch)
    {
        try
        {
            var idTestimonial = _testimonialService.GetById(id);

            if (idTestimonial != null)
            {
                var testimonialToUpdate = _testimonialService.PrepareTestimonialForUpdate(id);
                patch.ApplyTo(testimonialToUpdate, ModelState);

                if (!TryValidateModel(testimonialToUpdate))
                {
                    return ValidationProblem(ModelState);
                }

                _testimonialService.ApplyUpdateValues(testimonialToUpdate, idTestimonial);
                var readTestimonialDto = _testimonialService.GetMappingById(id);
                return Ok(readTestimonialDto);

            }

            return NotFound();
        }
        catch (Exception e)
        {
            return BadRequest(e.Message);
        }
    }


    [HttpDelete("{id}")]
    public IActionResult Delete(int id)
    {
        try
        {
            var idTestimonial = _testimonialService.GetById(id);
            if (idTestimonial != null)
            {
                _testimonialService.DeleteById(idTestimonial);
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
