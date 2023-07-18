using API_DestinosDeViagens.Data;
using API_DestinosDeViagens.Models;

namespace API_DestinosDeViagens.Repository.RepositoryTestimonial;

public class TestimonialRepository : ITestimonialRepository
{
    private DestinosdeViagensContext _contex;
    public TestimonialRepository(DestinosdeViagensContext contex)
    {
        _contex = contex;
    }
    public void Add(TestimonialModel testimonial)
    {
        _contex.Testimonials.Add(testimonial);
        SaveChanges();
    }

    public TestimonialModel GetById(int id)
    {
        var findTestimonialById = _contex.Testimonials.FirstOrDefault(t => t.Id == id);
        return findTestimonialById;
    }

    public IEnumerable<TestimonialModel> GetPaging(int skip = 0, int take = 3)
    {
       return _contex.Testimonials.Skip(skip).Take(take);   
    }

    public void Remove(TestimonialModel id)
    {
        _contex.Testimonials.Remove(id);
        SaveChanges();
    }

    public void SaveChanges()
    {
        _contex.SaveChanges();
    }
}
