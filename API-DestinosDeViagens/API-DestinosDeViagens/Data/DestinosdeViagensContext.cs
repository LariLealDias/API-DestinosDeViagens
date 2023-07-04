using API_DestinosDeViagens.Models;
using Microsoft.EntityFrameworkCore;

namespace API_DestinosDeViagens.Data;

public class DestinosdeViagensContext : DbContext
{
    public DestinosdeViagensContext(DbContextOptions<DestinosdeViagensContext> opts) : base(opts)
    {
            
    }
    
    public DbSet<TestimonialModel> Testimonials { get; set;}
}
