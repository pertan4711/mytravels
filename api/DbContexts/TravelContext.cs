using Microsoft.EntityFrameworkCore;
using MyTravels.API.Entities;
using MyTravels.API.Models;

namespace MyTravels.API.DbContexts
{
    public class TravelContext : DbContext
    {
        // För att inte klaga på att dessa kan vara null - använd '!'
        public DbSet<Travel> Travels { get; set; } = null!;
        //public DbSet<SubTravel> SubTravels { get; set; } = null!;
        public DbSet<Media> Media { get; set; } = null!;

        //// Överrrid med optionsBuilder för att konfigurera uppkoppling till databas
        //protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        //{
        //    optionsBuilder.UseSqlite("connectionString");
        //    base.OnConfiguring(optionsBuilder);
        //}

        // By exposing this constructor we can now provide these options at the moment we register our DBContext
        // Genom att använda base kan vi provida connectionString vid uppstart i Program
        public TravelContext(DbContextOptions<TravelContext> options) : base(options)
        {
        }

        // Överrid med modelBuilder för att manuellt konstruera modellen eller seeda med initiala data
        //protected override void OnModelCreating(ModelBuilder modelBuilder)
        //{
        //    modelBuilder.Entity<Travel>()
        //        .HasData(
        //            new Travel("Maldiverna_2021")
        //            {
        //                Id = 1,
        //                Description = "Dykning och Amari Havodda i Maldiverna 2021",
        //            },
        //            new Travel("Segling i Kroatien")
        //            {
        //                Id = 2,
        //                Description = "50-års present - Segling i Kornati med barnen och Slovenien",
        //            },
        //            new Travel("Rom_2021")
        //            {
        //                Id = 3,
        //                Description = "Höstresa till Rom",
        //                Start = new DateTime(2021, 9, 16),
        //                End = new DateTime(2021, 9, 20),
        //            },
        //            new Travel("Amari Havodda")
        //            {
        //                Id = 4,
        //                Description = "Hotellö i Maldiverna med ett fint husrev",
        //                Start = new DateTime(2021, 2, 10),
        //                End = new DateTime(2021, 2, 17),
        //                TravelId = 1,
        //            },
        //            new Travel("Maldives Current Dives")
        //            {
        //                Id = 5,
        //                Description = "Dykning i södra Maldiverna ofta i strömstarka kanaler",
        //                Start = new DateTime(2021, 2, 17),
        //                End = new DateTime(2021, 2, 22),
        //                TravelId = 1,
        //            },
        //            new Travel("Male")
        //            {
        //                Id = 6,
        //                Description = "Huvudstad i Maldiverna",
        //                Start = new DateTime(2021, 2, 22),
        //                End = new DateTime(2021, 2, 23),
        //                TravelId = 1,
        //            },
        //            new Travel("Segling i Kornati")
        //            {
        //                Id = 7,
        //                Description = "Segling från Biograd i naturresavatet Kornati",
        //                Start = new DateTime(2021, 6, 18),
        //                End = new DateTime(2021, 6, 25),
        //                TravelId = 2,
        //            },
        //            new Travel("Zadar")
        //            {
        //                Id = 8,
        //                Start = new DateTime(2021, 6, 25),
        //                End = new DateTime(2021, 6, 27),
        //                TravelId = 2,
        //            },
        //            new Travel("Pletjevica")
        //            {
        //                Id = 9,
        //                Description = "Naturreservat med många sjöar",
        //                Start = new DateTime(2021, 6, 27),
        //                End = new DateTime(2021, 6, 27),
        //                TravelId = 2,
        //            },
        //            new Travel("Slovenien")
        //            {
        //                Id = 10,
        //                Description = "Fina ställen i alperna",
        //                Start = new DateTime(2021, 6, 28),
        //                End = new DateTime(2021, 7, 4),
        //                TravelId = 2,
        //            },
        //            new Travel("Zagreb")
        //            {
        //                Id = 11,
        //                Description = "Huvudstad i Kroatien",
        //                Start = new DateTime(2021, 6, 28),
        //                End = new DateTime(2021, 7, 4),
        //                TravelId = 2,
        //            }
        //        );

        //    modelBuilder.Entity<Media>()
        //        .HasData(
        //            new Media("IMG-20210215-WA0017")
        //            {
        //                Id = 1,
        //                Type = "jpeg",
        //                Url = "\\\\pertanqnap\\Multimedia\\eget\\2021\\01 Maldiverna\\Daniellas mobil\\IMG-20210215-WA0017.jpg",
        //                TravelId = 1,
        //            },
        //            new Media("Dsc345")
        //            {
        //                Id = 2,
        //                Name = "Dsc344",
        //                Type = "jpeg",
        //                Url = "\\\\pertanqnap\\Multimedia\\eget\\2021\\01 Maldiverna\\Daniellas mobil\\IMG-20210215-WA0017.jpg",
        //                TravelId = 2,
        //            }
        //        );

        //    base.OnModelCreating(modelBuilder);
        //}
    }
}
