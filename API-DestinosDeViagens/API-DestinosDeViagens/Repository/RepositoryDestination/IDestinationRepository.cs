using API_DestinosDeViagens.Models;

namespace API_DestinosDeViagens.Repository.RepositoryDestination;

public interface IDestinationRepository
{
    void Add(DestinationModel destimonial);

    IEnumerable<DestinationModel> GetAll();

    IEnumerable<DestinationModel> GetPaging(int skip = 0, int take = 6);

    DestinationModel? GetById(int id);

    IEnumerable<DestinationModel> GetByTitle(string title);

    void SaveChanges();

    void Remove(DestinationModel id);
}
