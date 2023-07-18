using API_DestinosDeViagens.Models;

namespace API_DestinosDeViagens.Repository.RepositoryTestimonial;

public interface ITestimonialRepository
{
    void Add(TestimonialModel testimonial);

    IEnumerable<TestimonialModel> GetPaging(int skip = 0, int take = 3 );

    TestimonialModel? GetById(int id);

    void SaveChanges();

    void Remove(TestimonialModel id);
}
