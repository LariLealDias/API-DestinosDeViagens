using API_DestinosDeViagens.Data;
using API_DestinosDeViagens.Models;
using API_DestinosDeViagens.Services;

namespace API_DestinosDeViagens.Repository.RepositoryDestination;

public class DestinationRepository : IDestinationRepository
{
    private DestinosdeViagensContext _contex;
    public DestinationRepository(DestinosdeViagensContext contex)
    {
        _contex = contex;
    }


    public void Add(DestinationModel destimonial)
    {
        _contex.Destinations.Add(destimonial);
        SaveChanges();
    }




    public IEnumerable<DestinationModel> GetAll()
    {
        return _contex.Destinations;
    }


    public DestinationModel? GetById(int id)
    {
        var findDestinationById = _contex.Destinations.FirstOrDefault(d => d.Id == id);
        return findDestinationById;
    }


    public IEnumerable<DestinationModel> GetByTitle(string title)
    {
        var findByTitle = _contex.Destinations.Where(d => d.Title == title);
        return findByTitle;
    }


    public IEnumerable<DestinationModel> GetPaging(int skip = 0, int take = 6)
    {
        return _contex.Destinations.Skip(skip).Take(take);
    }


    public void Remove(DestinationModel id)
    {
        _contex.Remove(id);
        SaveChanges();
    }


    public void SaveChanges()
    {
        _contex.SaveChanges();
    }
}
