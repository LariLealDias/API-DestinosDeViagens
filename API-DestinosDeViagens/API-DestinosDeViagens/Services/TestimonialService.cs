using API_DestinosDeViagens.Data.Dtos.DtoTestimonial;
using API_DestinosDeViagens.Models;
using API_DestinosDeViagens.Repository.RepositoryTestimonial;
using AutoMapper;
using Microsoft.AspNetCore.Http;
using Newtonsoft.Json;
using System.Text;

namespace API_DestinosDeViagens.Services;

public class TestimonialService
{
    private ITestimonialRepository  _iTestimonialRepository;
    private IMapper _mapper;
    private IConfiguration _config;
    public TestimonialService(ITestimonialRepository repository, IMapper mapper, IConfiguration config)
    {
        _iTestimonialRepository = repository;
        _mapper = mapper;
        _config = config;
    }

    //POST
    public TestimonialModel Add(CreateTestimonialDto testimonialDto)
    {
        TestimonialModel testimonialMapped = _mapper.Map<TestimonialModel>(testimonialDto);
        _iTestimonialRepository.Add(testimonialMapped);
        return testimonialMapped;
    }

    public async Task<dynamic> GetResponseChatGPTAsync(CreateTestimonialDto testimonialDto)
    {
        string keyChatGPT = _config["ChaveAPIChatGPT"];
        string promptText = $"Gere um texto que contenha até 160 caracteres, pode conter menos caracteres mas nunca ultrapasse esse limite de 160. \r\n\r\nO texto gerado deve ser coerente com a informação desse TITULO: '{testimonialDto.Title}',  será necessário analisar se o titulo tem o teor: bom, neutro ou ruim. \r\nOs titulos podem variar, mas sempre terá um teor bom, ruim ou neutro.\r\nExemplos de TITULO com teor bom: \r\n- \"Adorei usar o site\"\r\n- \"Eu recomendo de olhos fechado\"\r\n- \"Ótima acessibilidade\"\r\n- etc\r\n\r\nExemplos de TITULO com teor neutro:\r\n- \"facil de usar\"\r\n- \"O site é ok\"\r\n- \"Legal\"\r\n- etc\r\n\r\nExemplos de TITULO com teor ruim:\r\n- \"Pessima experiencia\"\r\n- \"Perdi minha viagem dos sonhos por conta desse site\"\r\n- \"Site desatualizado, perdi meu dinheiro\"\r\n- etc\r\n\r\nSe o titulo for considerado teor  \"bom\" então o texto gerado deverá ter conotação positiva\r\nExemplo de um texto de conotação positiva:\r\nTitulo: Eu gostei\r\n\"Tive ótima experiência usando esse site, consegui concluir minha viagem sem nenhum transtorno\"\r\n\r\nSe o titulo for considerado teor  \"ruim\" então o texto gerado deverá ter conotação negativa\r\nExemplo de um texto de conotação negativa:\r\nTitulo: Achei ruim, pouca opção\r\n\"Catalogo de viagens é muito pequeno, achei pessimo, tem sites melhores por ai\"\r\n\r\nSe o titulo for considerado teor  \"neutra\" então o texto gerado deverá ter conotação neutra\r\nExemplo de um texto de conotação neutra:\r\nTitulo: Nada de mais\r\n\"Tem muita propaganda sobre esse site, mas achei muito razoavel, da pra melhorar, porém tudo funcionou\"\r\n\r\nO tom do texto pode ser gerado de forma formal, casual, informativo, etc.\r\n\r\nO retorno da sua resposta deve pontual e assertivo, não faça introduções, apenas retorne o próprio texto.";

        var reqClient = new HttpClient();
        reqClient.DefaultRequestHeaders.Add("authorization", $"Bearer {keyChatGPT}");

        var json = JsonConvert.SerializeObject(
            new
            {
                model = "text-davinci-003",
                prompt = promptText,
                max_tokens = 100,
                temperature = 1
            }
         );

        var httpResponse = await reqClient.PostAsync("https://api.openai.com/v1/completions", new StringContent(json, Encoding.UTF8, "application/json"));

        var data = await httpResponse.Content.ReadAsStringAsync();

        var response = JsonConvert.DeserializeObject<dynamic>(data);


        TestimonialModel testimonialMapped = _mapper.Map<TestimonialModel>(testimonialDto);
        return response.choice[0].text;


        //return "stonf";
    }


    //GET 3 resource 
    public IEnumerable<ReadTestimonialDto> GetPaging(int skip = 0, int take = 3)
    {
        return _mapper.Map<List<ReadTestimonialDto>>(_iTestimonialRepository.GetPaging(skip, take).ToList());
    }

    //GET 3 random resource 
    public IEnumerable<ReadTestimonialDto> GetThreeRandom()
    {
        var allTestimonials = _iTestimonialRepository.GetAll();

        var randomTestimonials = allTestimonials.OrderBy(testimonials => Guid.NewGuid()).Take(3).ToList();

        return _mapper.Map<List<ReadTestimonialDto>>(randomTestimonials);
    }


    //GET by id
    public TestimonialModel? GetById(int id)
    {
        var findById = _iTestimonialRepository.GetById(id);
        return findById;
    }




    //PATCH
    public UpdateTestimonialDto PrepareTestimonialForUpdate(int id)
    {
        var idTestimonial = GetById(id);
        var dto = _mapper.Map<UpdateTestimonialDto>(idTestimonial);
        return dto;
    }

    public TestimonialModel ApplyUpdateValues(UpdateTestimonialDto testimonialDto, TestimonialModel idUpadated)
    {
        var mapping = _mapper.Map(testimonialDto, idUpadated);
        _iTestimonialRepository.SaveChanges();
        return mapping;
    }
  
    
    //DELETE
    public void DeleteById(TestimonialModel id)
    {
        _iTestimonialRepository.Remove(id);
    }
   
    
    //Mapping to DTOs layer
    public ReadTestimonialDto GetMappingById(int id)
    {
        var testimonialId = GetById(id);
        var testimonialMapped = _mapper.Map<ReadTestimonialDto>(testimonialId);
        return testimonialMapped;
    }
}
