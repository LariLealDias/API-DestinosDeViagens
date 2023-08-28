using API_DestinosDeViagens.Data;
using API_DestinosDeViagens.Models;

namespace API_DestinosDeViagens.Repository.RepositoryRoadTrip;

public class RoadTripRepository : IRoadTripRepository
{
    private DestinosdeViagensContext _contex;
    public RoadTripRepository(DestinosdeViagensContext contex)
    {
        _contex = contex;
    }
    public void Add(RoadTripModel roadTrip)
    {
        _contex.RoadTrips.Add(roadTrip);
        _contex.SaveChanges();
    }
}
