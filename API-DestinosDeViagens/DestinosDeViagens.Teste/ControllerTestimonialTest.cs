using Microsoft.AspNetCore.Mvc.Testing;
using Microsoft.VisualStudio.TestPlatform.TestHost;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace DestinosDeViagens.Teste;

public class ControllerTestimonialTest : IClassFixture<WebApplicationFactory<Program>>
{
    private readonly WebApplicationFactory<Program> _factory;
    public ControllerTestimonialTest(WebApplicationFactory<Program> factory)
    {
        _factory = factory;
    }

    [Theory]
    [InlineData("/api/testimonial")]
    [InlineData("/api/testimonial?skip=0&take=3")]
    public async Task GetTestimonialTest(string url)
    {
        //Arrange
        var client =_factory.CreateClient();

        //var routeUrl = "/testimonial";

        //Act
        var response = await client.GetAsync(url);

        //Assert
        response.EnsureSuccessStatusCode();
        Assert.Equal("application/json; charset=utf-8", response.Content.Headers.ContentType.ToString());
    }

}
