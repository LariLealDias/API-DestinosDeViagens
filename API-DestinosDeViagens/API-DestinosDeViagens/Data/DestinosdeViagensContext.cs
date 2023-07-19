using API_DestinosDeViagens.Data.SeedDatas;
using API_DestinosDeViagens.Models;
using Microsoft.EntityFrameworkCore;

namespace API_DestinosDeViagens.Data;

public class DestinosdeViagensContext : DbContext
{
    public DestinosdeViagensContext(DbContextOptions<DestinosdeViagensContext> opts) : base(opts)
    {
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfiguration(new SeedDataConfiguration());

        modelBuilder.Entity<CustomerModel>()
          .HasOne(c => c.TestimonialModel )
          .WithOne(t => t.CustomerModel)
          .HasForeignKey<TestimonialModel>(t => t.CustomerModelId);
    }

    public DbSet<TestimonialModel> Testimonials { get; set;}
    public DbSet<CustomerModel> Customers { get; set;}
    public DbSet<DestinationModel> Destinations { get; set; }
}
