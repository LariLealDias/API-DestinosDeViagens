using Microsoft.AspNetCore.Mvc.Testing;
using Microsoft.VisualStudio.TestPlatform.TestHost;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DestinosDeViagens.Teste;

public class ControllerTestimonialTest : IClassFixture<WebApplicationFactory<Program>>
{
    private readonly WebApplicationFactory<Program> _factory;
    public ControllerTestimonialTest(WebApplicationFactory<Program> factory)
    {
        _factory = factory;
    }


}
