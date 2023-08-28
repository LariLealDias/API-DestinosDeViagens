using API_DestinosDeViagens.Data;
using API_DestinosDeViagens.Models;
using Microsoft.EntityFrameworkCore.Diagnostics;

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
        Console.WriteLine(  "ESTOU NA REPOSITORY");


        _contex.RoadTrips.Add(roadTrip);

        Console.WriteLine("ESTOU em baixo do add");

        _contex.SaveChanges();
    }
}
