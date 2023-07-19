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


    public IEnumerable<TestimonialModel> GetAll()
    {
        return _contex.Testimonials;
    }


    public IEnumerable<TestimonialModel> GetPaging(int skip = 0, int take = 3)
    {
       return _contex.Testimonials.Skip(skip).Take(take);   
    }


    public TestimonialModel GetById(int id)
    {
        var findTestimonialById = _contex.Testimonials.FirstOrDefault(t => t.Id == id);
        return findTestimonialById;
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
