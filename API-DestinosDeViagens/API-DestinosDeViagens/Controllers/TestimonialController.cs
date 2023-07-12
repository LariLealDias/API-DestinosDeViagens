using API_DestinosDeViagens.Data;
using API_DestinosDeViagens.Data.Dtos.DtoTestimonial;
using API_DestinosDeViagens.Models;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;

namespace API_DestinosDeViagens.Controllers;

[ApiController]
[Route("[controller]")]
public class TestimonialController : ControllerBase
{
    public IMapper _mapper { get; set; }
    public DestinosdeViagensContext _context { get; set; }

    public TestimonialController(IMapper mapper, DestinosdeViagensContext contex)
    {
        _mapper = mapper;
        _context = contex;
    }

    [HttpPost]
    public IActionResult CreateTestimonial([FromBody] CreateTestimonialDto testimonialDto)
    {
        TestimonialModel testimonial = _mapper.Map<TestimonialModel>(testimonialDto);
        _context.Testimonials.Add(testimonial);
        _context.SaveChanges();
        return CreatedAtAction(nameof(GetTestimonialById), new { id = testimonial.Id }, testimonial);
    }

    [HttpGet("{id}")]
    public IActionResult GetTestimonialById(int id)
    {
        var testimonial = _context.Testimonials.FirstOrDefault(testi => testi.Id == id);
        if (testimonial == null) return NotFound();
        return Ok(testimonial);
    }
}
