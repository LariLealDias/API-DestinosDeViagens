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
            new CustomerModel { Id = 2, PhotoPath = "/assets/imgs/photoUser2.jpg", Name = "John" },
            new CustomerModel { Id = 3, PhotoPath = "/assets/imgs/photoUser3.jpg", Name = "Mary" },
            new CustomerModel { Id = 4, PhotoPath = "/assets/imgs/photoUser4.jpg", Name = "João" },
            new CustomerModel { Id = 5, PhotoPath = "/assets/imgs/photoUser5.jpg", Name = "Ricky" },
            new CustomerModel { Id = 6, PhotoPath = "/assets/imgs/photoUser6.jpg", Name = "Morty" },
            new CustomerModel { Id = 7, PhotoPath = "/assets/imgs/photoUser7.jpg", Name = "Billie" },
            new CustomerModel { Id = 8, PhotoPath = "/assets/imgs/photoUser8.jpg", Name = "Lana" },
            new CustomerModel { Id = 9, PhotoPath = "/assets/imgs/photoUser9.jpg", Name = "Alana" },
            new CustomerModel { Id = 10, PhotoPath = "/assets/imgs/photoUser10.jpg", Name = "Lina" }
        );
    }
}
