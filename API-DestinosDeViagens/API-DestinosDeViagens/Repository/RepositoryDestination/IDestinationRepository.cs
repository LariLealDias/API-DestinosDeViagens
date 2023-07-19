using API_DestinosDeViagens.Models;

namespace API_DestinosDeViagens.Repository.RepositoryDestination;

public interface IDestinationRepository
{
    void Add(DestinationModel destimonial);

    IEnumerable<DestinationModel> GetPaging(int skip = 0, int take = 3);

    IEnumerable<DestinationModel> GetAll();

    DestinationModel? GetById(int id);

    void SaveChanges();

    void Remove(DestinationModel id);
}
