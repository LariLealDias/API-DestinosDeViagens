using API_DestinosDeViagens.Data.Dtos.DtoTestimonial;
using API_DestinosDeViagens.Services;
using Microsoft.AspNetCore.Mvc;

namespace API_DestinosDeViagens.Controllers.ControllerTestimonial;

[ApiController]
[Route("testimonial-home")]
public class TestimonialHomeController : ControllerBase
{
    private TestimonialService _testimonialService;
    public TestimonialHomeController(TestimonialService testimonialService)
    {
        _testimonialService = testimonialService;
    }

    [HttpGet]
    public IActionResult GetThreeRandomTestimonials()
    {
        try
        {
            IEnumerable<ReadTestimonialDto> randomTestimonials = _testimonialService.GetThreeRandom();

            if(randomTestimonials != null)
            {
                return Ok(randomTestimonials);
            }
            
            return NotFound();

        }catch(Exception e)
        {
            return BadRequest(e.Message);

        }
    }
}
