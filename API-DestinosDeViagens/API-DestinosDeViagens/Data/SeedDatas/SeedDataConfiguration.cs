using API_DestinosDeViagens.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;


namespace API_DestinosDeViagens.Data.SeedDatas;

public class SeedDataConfiguration : IEntityTypeConfiguration<CustomerModel>
{
    public void Configure(EntityTypeBuilder<CustomerModel> builder)
    {
        builder.HasKey(s => s.Id);
        builder.Property(s => s.PhotoPath).IsRequired();
        builder.Property(s => s.Name).IsRequired();

        builder.HasData(
            new CustomerModel { Id = 1, PhotoPath = "/assets/imgs/photoUser1.jpg", Name = "Maria" },
            new CustomerModel { Id = 2, PhotoPath = "/assets/imgs/photoUser2.jpg", Name = "John" }
        );
    }
}
