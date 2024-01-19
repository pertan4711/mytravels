using MyTravels.API.Entities;

namespace MyTravels.API
{
    public class TravelsDataStore
    {
        public List<Travel> Travels { get; set; }

        public static TravelsDataStore Current { get; } = new TravelsDataStore();

        public TravelsDataStore()
        {
            Travels = new List<Travel>()
            {
                new Travel("Maldiverna_2021")
                {
                    Id = 1,
                    Description = "Dykning och Amari Havodda i Maldiverna 2021",
                    SubTravels = new List<Travel>()
                    {
                        new Travel("Amari Havodda")
                        {
                            Id = 2,
                            Description = "Hotellö i Maldiverna med ett fint husrev",
                            Start = new DateTime(2021, 2, 10),
                            End = new DateTime(2021, 2, 17),
                            Media = new List<Media>()
                            {
                                new Media("Dsc344")
                                {
                                    Id = 1,
                                    Type = "jpeg",
                                    Url = "\\\\pertanqnap\\Multimedia\\eget\\2021\\01 Maldiverna\\Daniellas mobil\\IMG-20210215-WA0017.jpg",
                                    TravelId = 1,
                                },
                                new Media("Dsc345")
                                {
                                    Id = 10,
                                    Type = "jpeg",
                                    Url = "\\\\pertanqnap\\Multimedia\\eget\\2021\\01 Maldiverna\\Daniellas mobil\\IMG-20210215-WA0018.jpg",
                                    TravelId = 1,
                                }
                            }
                        },
                        new Travel("Maldives Current Dives")
                        {
                            Id = 3,
                            Description = "Dykning i södra Maldiverna ofta i strömstarka kanaler",
                            Start = new DateTime(2021, 2, 17),
                            End = new DateTime(2021, 2, 22),
                            Media = new List<Media>()
                            {
                                new Media("Dsc3466")
                                {
                                    Id = 2,
                                    Type = "jpeg",
                                    Url = "\\\\pertanqnap\\Multimedia\\eget\\2021\\01 Maldiverna\\Daniellas mobil\\IMG-20210215-WA0017.jpg"
                                }
                            },
                        },
                        new Travel("Huvudstad i Maldiverna")
                        {
                            Id = 4,
                            Name = "Male",
                            Media = new List<Media>(),
                            Start = new DateTime(2021, 2, 22),
                            End = new DateTime(2021, 2, 23),
                        }
                    },
                },
                new Travel("Segling i Kroatien")
                {
                    Id = 5,
                    Description = "50-års present - Segling i Kornati med barnen och Slovenien",
                    Media = new List<Media>(),
                    SubTravels = new List<Travel>()
                    {
                        new Travel("Segling i Kornati")
                        {
                            Id= 6,
                            Description = "Segling från Biograd i naturresavatet Kornati",
                            Start = new DateTime(2021, 6, 18),
                            End = new DateTime(2021, 6, 25),
                        },
                        new Travel("Zadar")
                        {
                            Id = 7,
                            Start = new DateTime(2021, 6, 25),
                            End = new DateTime(2021, 6, 27),
                        },
                        new Travel("Pletjevica")
                        {
                            Id = 8,
                            Name = "Pletjevica",
                            Description = "Naturreservat med många sjöar",
                            Start = new DateTime(2021, 6, 27),
                            End = new DateTime(2021, 6, 27),
                        },
                        new Travel("Slovenien")
                        {
                            Id = 9,
                            Start = new DateTime(2021, 6, 28),
                            End = new DateTime(2021, 7, 4),
                        }
                    }
                },
                new Travel("Rom_2021") 
                { 
                    Id = 10,
                    Description = "Höstresa till Rom",
                    Media = new List<Media>(),
                    Start = new DateTime(2021, 9, 16),
                    End = new DateTime(2021, 9 , 20),
                }
            };
        }
    }
}
