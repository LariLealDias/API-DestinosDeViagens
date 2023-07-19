using API_DestinosDeViagens.Data.Dtos.DtoTestimonial;
using API_DestinosDeViagens.Services;
using Microsoft.Extensions.Logging;

namespace DestinosDeViagens.Teste;

public class TestimonialServiceTeste
{
    private TestimonialService _testimonialService;
    private CreateTestimonialDto _dto;
    private ILogger<TestimonialServiceTeste> _log;
    public TestimonialServiceTeste(TestimonialService testimonialService, 
                                    CreateTestimonialDto dto,
                                     ILogger<TestimonialServiceTeste> log)
    {
        _testimonialService = testimonialService;
        _dto = dto;
        _log = log;
    }


    [Fact]
    public void validarMetodoAddERetornarTipoModel()
    {
        var resultado = _testimonialService.Add(_dto);
        _log.LogInformation(resultado + "AQUIII");
        Assert.NotNull(resultado);

    }
}