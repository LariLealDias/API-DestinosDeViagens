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
    [Migration("20230719202901_CreatingDestinationTable")]
    partial class CreatingDestinationTable
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

                    b.Property<double>("Price")
                        .HasColumnType("double");

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
