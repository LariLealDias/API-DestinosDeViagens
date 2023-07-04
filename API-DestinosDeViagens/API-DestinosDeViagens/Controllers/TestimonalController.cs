using Microsoft.AspNetCore.Mvc;

namespace API_DestinosDeViagens.Controllers;

[ApiController]
[Route("[controller]")]
public class TestimonalController : ControllerBase
{
    public int MyProperty { get; set; }
}
