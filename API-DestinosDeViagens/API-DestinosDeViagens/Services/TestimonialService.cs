using API_DestinosDeViagens.Data.Dtos.DtoTestimonial;
using API_DestinosDeViagens.Models;
using API_DestinosDeViagens.Repository.RepositoryTestimonial;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;

namespace API_DestinosDeViagens.Services;

public class TestimonialService
{
    private ITestimonialRepository  _iTestimonialRepository;
    private IMapper _mapper;
    public TestimonialService(ITestimonialRepository repository, IMapper mapper)
    {
        _iTestimonialRepository = repository;
        _mapper = mapper;
    }

    //POST
    public TestimonialModel Add(CreateTestimonialDto testimonialDto)
    {
        TestimonialModel testimonialMapped = _mapper.Map<TestimonialModel>(testimonialDto);
        _iTestimonialRepository.Add(testimonialMapped);
        return testimonialMapped;
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
