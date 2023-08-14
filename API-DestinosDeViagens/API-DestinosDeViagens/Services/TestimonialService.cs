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

    public string GetResponseChatGPTAsync(CreateTestimonialDto testimonialDto)
    {
        string keyChatGPT = _config["ChaveAPIChatGPT"];
        string promptText = $"Gere um texto relacionado ao título {testimonialDto.Title}, considerando o teor (bom, neutro ou ruim) do título.Considere o assunto: site de viagens e gere na perspectiva de um usuario. O texto gerado pode conter até 35 caracteres. Seja objetivo e mande apenas o texto, sem o titulo.";

        using (HttpClient reqClient = new HttpClient())
        {
            //var reqClient = new HttpClient();
            reqClient.DefaultRequestHeaders.Add("authorization", $"Bearer {keyChatGPT}");

            var json = JsonConvert.SerializeObject(
                new
                {
                    model = "text-davinci-003",
                    prompt = promptText,
                    max_tokens = 500,
                    temperature = 1
                }
             );

            var httpResponse =  reqClient.PostAsync("https://api.openai.com/v1/completions", new StringContent(json, Encoding.UTF8, "application/json")).GetAwaiter().GetResult(); ;

            var data =  httpResponse.Content.ReadAsStringAsync().GetAwaiter().GetResult();

            var response = JsonConvert.DeserializeObject<dynamic>(data);
            Console.WriteLine(response.choices[0].text);


            TestimonialModel testimonialMapped = _mapper.Map<TestimonialModel>(testimonialDto);
            string treatResponse = response.choices[0].text;
            treatResponse = treatResponse.Replace("\n", "");
            return treatResponse;
        }
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
