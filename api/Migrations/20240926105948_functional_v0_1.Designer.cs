﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using MyTravels.API.DbContexts;

#nullable disable

namespace MyTravels.API.Migrations
{
    [DbContext(typeof(TravelContext))]
    [Migration("20240926105948_functional_v0_1")]
    partial class functional_v0_1
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder.HasAnnotation("ProductVersion", "8.0.8");

            modelBuilder.Entity("MyTravels.API.Entities.Media", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("Description")
                        .HasMaxLength(2000)
                        .HasColumnType("TEXT");

                    b.Property<int?>("TravelId")
                        .HasColumnType("INTEGER");

                    b.Property<string>("Type")
                        .HasColumnType("TEXT");

                    b.Property<string>("Url")
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.HasIndex("TravelId");

                    b.ToTable("Media");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            TravelId = 1,
                            Type = "jpeg",
                            Url = "\\\\pertanqnap\\Multimedia\\eget\\2021\\01 Maldiverna\\Daniellas mobil\\IMG-20210215-WA0017.jpg"
                        },
                        new
                        {
                            Id = 2,
                            TravelId = 2,
                            Type = "jpeg",
                            Url = "\\\\pertanqnap\\Multimedia\\eget\\2021\\01 Maldiverna\\Daniellas mobil\\IMG-20210215-WA0017.jpg"
                        });
                });

            modelBuilder.Entity("MyTravels.API.Entities.Travel", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("Description")
                        .HasMaxLength(2000)
                        .HasColumnType("TEXT");

                    b.Property<DateTime?>("End")
                        .HasColumnType("TEXT");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("TEXT");

                    b.Property<DateTime?>("Start")
                        .HasColumnType("TEXT");

                    b.Property<int?>("TravelId")
                        .HasColumnType("INTEGER");

                    b.HasKey("Id");

                    b.HasIndex("TravelId");

                    b.ToTable("Travels");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Description = "Dykning och Amari Havodda i Maldiverna 2021",
                            Name = "Maldiverna_2021"
                        },
                        new
                        {
                            Id = 2,
                            Description = "50-års present - Segling i Kornati med barnen och Slovenien",
                            Name = "Segling i Kroatien"
                        },
                        new
                        {
                            Id = 3,
                            Description = "Höstresa till Rom",
                            End = new DateTime(2021, 9, 20, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Name = "Rom_2021",
                            Start = new DateTime(2021, 9, 16, 0, 0, 0, 0, DateTimeKind.Unspecified)
                        },
                        new
                        {
                            Id = 4,
                            Description = "Hotellö i Maldiverna med ett fint husrev",
                            End = new DateTime(2021, 2, 17, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Name = "Amari Havodda",
                            Start = new DateTime(2021, 2, 10, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            TravelId = 1
                        },
                        new
                        {
                            Id = 5,
                            Description = "Dykning i södra Maldiverna ofta i strömstarka kanaler",
                            End = new DateTime(2021, 2, 22, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Name = "Maldives Current Dives",
                            Start = new DateTime(2021, 2, 17, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            TravelId = 1
                        },
                        new
                        {
                            Id = 6,
                            Description = "Huvudstad i Maldiverna",
                            End = new DateTime(2021, 2, 23, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Name = "Male",
                            Start = new DateTime(2021, 2, 22, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            TravelId = 1
                        },
                        new
                        {
                            Id = 7,
                            Description = "Segling från Biograd i naturresavatet Kornati",
                            End = new DateTime(2021, 6, 25, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Name = "Segling i Kornati",
                            Start = new DateTime(2021, 6, 18, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            TravelId = 2
                        },
                        new
                        {
                            Id = 8,
                            End = new DateTime(2021, 6, 27, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Name = "Zadar",
                            Start = new DateTime(2021, 6, 25, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            TravelId = 2
                        },
                        new
                        {
                            Id = 9,
                            Description = "Naturreservat med många sjöar",
                            End = new DateTime(2021, 6, 27, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Name = "Pletjevica",
                            Start = new DateTime(2021, 6, 27, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            TravelId = 2
                        },
                        new
                        {
                            Id = 10,
                            Description = "Fina ställen i alperna",
                            End = new DateTime(2021, 7, 4, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Name = "Slovenien",
                            Start = new DateTime(2021, 6, 28, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            TravelId = 2
                        },
                        new
                        {
                            Id = 11,
                            Description = "Huvudstad i Kroatien",
                            End = new DateTime(2021, 7, 4, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Name = "Zagreb",
                            Start = new DateTime(2021, 6, 28, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            TravelId = 2
                        });
                });

            modelBuilder.Entity("MyTravels.API.Entities.Media", b =>
                {
                    b.HasOne("MyTravels.API.Entities.Travel", "Travel")
                        .WithMany("Media")
                        .HasForeignKey("TravelId");

                    b.Navigation("Travel");
                });

            modelBuilder.Entity("MyTravels.API.Entities.Travel", b =>
                {
                    b.HasOne("MyTravels.API.Entities.Travel", "MasterTravel")
                        .WithMany("SubTravels")
                        .HasForeignKey("TravelId");

                    b.Navigation("MasterTravel");
                });

            modelBuilder.Entity("MyTravels.API.Entities.Travel", b =>
                {
                    b.Navigation("Media");

                    b.Navigation("SubTravels");
                });
#pragma warning restore 612, 618
        }
    }
}
