using API_DestinosDeViagens.Data.Dtos.DtoDestination;
using API_DestinosDeViagens.Models;
using AutoMapper;

namespace API_DestinosDeViagens.Profiles;

public class DestinationProfile : Profile
{
    public DestinationProfile()
    {
        CreateMap<CreateDestinationDto, DestinationModel>();

        CreateMap<DestinationModel, ReadDestinationDto>();

        CreateMap<UpdateDestinationDto, DestinationModel>();
        CreateMap<DestinationModel, UpdateDestinationDto>();
    }
}
