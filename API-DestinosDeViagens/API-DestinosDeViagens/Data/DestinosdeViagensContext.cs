using API_DestinosDeViagens.Data.SeedDatas;
using API_DestinosDeViagens.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;

namespace API_DestinosDeViagens.Data;

public class DestinosdeViagensContext : DbContext
{
    public DestinosdeViagensContext(DbContextOptions<DestinosdeViagensContext> opts) : base(opts)
    {

    }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.LogTo(Console.WriteLine);
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfiguration(new SeedDataConfiguration());

        modelBuilder.Entity<CustomerModel>()
          .HasOne(c => c.TestimonialModel )
          .WithOne(t => t.CustomerModel)
          .HasForeignKey<TestimonialModel>(t => t.CustomerModelId);

        //config cascade To RoadTrip and Destination
        modelBuilder.Entity<RoadTripModel>()
            .HasOne(r => r.DestinationModel)
            .WithOne(d => d.RoadTrip)
            .HasForeignKey<RoadTripModel>(t => t.DestinationModelId)
             .OnDelete(DeleteBehavior.Cascade);

    }

    public DbSet<TestimonialModel> Testimonials { get; set;}
    public DbSet<CustomerModel> Customers { get; set;}
    public DbSet<DestinationModel> Destinations { get; set; }
    public DbSet<RoadTripModel> RoadTrips { get; set; }
}
