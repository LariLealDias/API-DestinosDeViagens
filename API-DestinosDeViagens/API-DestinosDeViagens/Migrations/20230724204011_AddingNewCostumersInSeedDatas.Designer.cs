﻿// <auto-generated />
using API_DestinosDeViagens.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace API_DestinosDeViagens.Migrations
{
    [DbContext(typeof(DestinosdeViagensContext))]
    [Migration("20230724204011_AddingNewCostumersInSeedDatas")]
    partial class AddingNewCostumersInSeedDatas
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.10")
                .HasAnnotation("Relational:MaxIdentifierLength", 64);

            modelBuilder.Entity("API_DestinosDeViagens.Models.CustomerModel", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<string>("PhotoPath")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.HasKey("Id");

                    b.ToTable("Customers");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Name = "Maria",
                            PhotoPath = "/assets/imgs/photoUser1.jpg"
                        },
                        new
                        {
                            Id = 2,
                            Name = "John",
                            PhotoPath = "/assets/imgs/photoUser2.jpg"
                        },
                        new
                        {
                            Id = 3,
                            Name = "Mary",
                            PhotoPath = "/assets/imgs/photoUser3.jpg"
                        },
                        new
                        {
                            Id = 4,
                            Name = "João",
                            PhotoPath = "/assets/imgs/photoUser4.jpg"
                        },
                        new
                        {
                            Id = 5,
                            Name = "Ricky",
                            PhotoPath = "/assets/imgs/photoUser5.jpg"
                        },
                        new
                        {
                            Id = 6,
                            Name = "Morty",
                            PhotoPath = "/assets/imgs/photoUser6.jpg"
                        },
                        new
                        {
                            Id = 7,
                            Name = "Billie",
                            PhotoPath = "/assets/imgs/photoUser7.jpg"
                        },
                        new
                        {
                            Id = 8,
                            Name = "Lana",
                            PhotoPath = "/assets/imgs/photoUser8.jpg"
                        },
                        new
                        {
                            Id = 9,
                            Name = "Alana",
                            PhotoPath = "/assets/imgs/photoUser9.jpg"
                        },
                        new
                        {
                            Id = 10,
                            Name = "Lina",
                            PhotoPath = "/assets/imgs/photoUser10.jpg"
                        });
                });

            modelBuilder.Entity("API_DestinosDeViagens.Models.DestinationModel", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<string>("PhotoPath")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<float>("Price")
                        .HasColumnType("float");

                    b.Property<string>("Title")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("varchar(50)");

                    b.HasKey("Id");

                    b.ToTable("Destinations");
                });

            modelBuilder.Entity("API_DestinosDeViagens.Models.TestimonialModel", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<int>("CustomerModelId")
                        .HasColumnType("int");

                    b.Property<string>("Text")
                        .IsRequired()
                        .HasMaxLength(300)
                        .HasColumnType("varchar(300)");

                    b.Property<string>("Title")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("varchar(50)");

                    b.HasKey("Id");

                    b.HasIndex("CustomerModelId")
                        .IsUnique();

                    b.ToTable("Testimonials");
                });

            modelBuilder.Entity("API_DestinosDeViagens.Models.TestimonialModel", b =>
                {
                    b.HasOne("API_DestinosDeViagens.Models.CustomerModel", "CustomerModel")
                        .WithOne("TestimonialModel")
                        .HasForeignKey("API_DestinosDeViagens.Models.TestimonialModel", "CustomerModelId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("CustomerModel");
                });

            modelBuilder.Entity("API_DestinosDeViagens.Models.CustomerModel", b =>
                {
                    b.Navigation("TestimonialModel")
                        .IsRequired();
                });
#pragma warning restore 612, 618
        }
    }
}
