using API_DestinosDeViagens.Data.Dtos.DtoTestimonial;
using API_DestinosDeViagens.Models;
using AutoMapper;

namespace API_DestinosDeViagens.Profiles;

public class TestimonialProfile : Profile
{
    public TestimonialProfile()
    {
        CreateMap<CreateTestimonialDto, TestimonialModel>();

        CreateMap<TestimonialModel, ReadTestimonialDto>();

        CreateMap<UpdateTestimonialDto, TestimonialModel>();
        CreateMap<TestimonialModel, UpdateTestimonialDto>();
    }
}
