using API_DestinosDeViagens.Data.Dtos.DtoDestination;
using API_DestinosDeViagens.Models;
using API_DestinosDeViagens.Repository.RepositoryDestination;
using AutoMapper;

namespace API_DestinosDeViagens.Services;

public class DestinationService
{
    private IDestinationRepository _iDestinationRepository;
    private IMapper _mapper;
    private RoadTripService _roadTripService;

    public DestinationService(IDestinationRepository iDestinationRepository, IMapper mapper, RoadTripService roadTripService)
    {
        _iDestinationRepository = iDestinationRepository;
        _mapper = mapper;
        _roadTripService = roadTripService; 
    }


    //POST
    public DestinationModel Add(CreateDestinationDto destinationDto)
    {
        DestinationModel destinationMapped = _mapper.Map<DestinationModel>(destinationDto);
        _iDestinationRepository.Add(destinationMapped);
        
        return destinationMapped;
    }

    public void CreateRoadTrip(string title, int id)
    {
        //RoadTripModel roadTrip = new RoadTripModel();
        ////title = roadTrip.DestinationModel.Title;
        //roadTrip.DestinationModel = new DestinationModel { Title = title };

        _roadTripService.GetResponseIAToSightsFildInRoadTripModel(title, id);
    }

    //GET 3 resource 
    public IEnumerable<ReadDestinationDto> GetPaging(int skip = 0, int take = 6)
    {
        return _mapper.Map<List<ReadDestinationDto>>(_iDestinationRepository.GetPaging(skip, take).ToList());
    }


    //GET 3 random resource 
    public IEnumerable<ReadDestinationDto> GetThreeRandom()
    {
        var allTestimonials = _iDestinationRepository.GetAll();

        var randomTestimonials = allTestimonials.OrderBy(testimonials => Guid.NewGuid()).Take(3).ToList();

        return _mapper.Map<List<ReadDestinationDto>>(randomTestimonials);
    }


    //GET by Id
    public DestinationModel? GetById(int id)
    {
        var findById = _iDestinationRepository.GetById(id);
        return findById;
    }


    //GET only by Title
    public IEnumerable<ReadDestinationDto> GetByTitle(string title)
    {
        return _mapper.Map<List<ReadDestinationDto>>(_iDestinationRepository.GetByTitle(title).ToList());
    }


    //PATCH
    public UpdateDestinationDto PrepareDestinationForUpdate(int id)
    {
        var idDestination = GetById(id);
        var dto = _mapper.Map<UpdateDestinationDto>(idDestination);
        return dto;
    }

    public DestinationModel ApplyUpdateValues(UpdateDestinationDto destinationdto, DestinationModel idUpadated)
    {
        var mapping = _mapper.Map(destinationdto, idUpadated);
        _iDestinationRepository.SaveChanges();
        return mapping;
    }


    //DELETE
    public void DeleteById(DestinationModel id)
    {
        _iDestinationRepository.Remove(id);
    }


    //Mapping to DTOs layer
    public ReadDestinationDto GetMappingById(int id)
    {
        var destinationId = GetById(id);
        var destinationMapped = _mapper.Map<ReadDestinationDto>(destinationId);
        return destinationMapped;
    }
}
