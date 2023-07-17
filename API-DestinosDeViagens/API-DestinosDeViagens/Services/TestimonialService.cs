using API_DestinosDeViagens.Data.Dtos.DtoTestimonial;
using API_DestinosDeViagens.Models;
using API_DestinosDeViagens.Repository.RepositoryTestimonial;
using AutoMapper;

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

    public TestimonialModel Add(CreateTestimonialDto testimonialDto)
    {
        TestimonialModel testimonialMapped = _mapper.Map<TestimonialModel>(testimonialDto);
        _iTestimonialRepository.Add(testimonialMapped);
        return testimonialMapped;
    }


    public TestimonialModel? GetById(int id)
    {
        var findById = _iTestimonialRepository.GetById(id);
        return findById;
    }


    //Mapping to DTOs layer
    public ReadTestimonialDto GetMappingById(int id)
    {
        var testimonialId = GetById(id);
        var testimonialMapped = _mapper.Map<ReadTestimonialDto>(testimonialId);
        return testimonialMapped;
    }
}
