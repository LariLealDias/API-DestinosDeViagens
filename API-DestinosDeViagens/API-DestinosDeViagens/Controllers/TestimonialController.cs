using API_DestinosDeViagens.Data.Dtos.DtoTestimonial;
using API_DestinosDeViagens.Models;
using API_DestinosDeViagens.Services;
using Microsoft.AspNetCore.Mvc;

namespace API_DestinosDeViagens.Controllers;

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
                CustomerModelId = testimonial.CustomerModel,
            };

            return Created(resourceUrl, response);
        }
        catch (Exception e)
        {
            return BadRequest(e.Message);
        }
    }

    [HttpGet("{id}")]
    public IActionResult GetTestimonialById(int id)
    {
        var testimonialId = _testimonialService.GetById(id);
        if(testimonialId == null)
        {
            return NotFound();
        }
        var testimonial = _testimonialService.GetMappingById(id);

        return Ok(testimonial);
    }
}
