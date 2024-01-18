using MyTravels.API.Models;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MyTravels.API.Entities
{
    public class Travel
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        [Required]
        [MaxLength(50)]
        public string Name { get; set; }


        [ForeignKey("TravelId")]
        public int? TravelId { get; set; }
        public Travel? MasterTravel { get; set; }
        public List<Travel> SubTravels { get; set; } = new List<Travel>();


        [MaxLength(2000)]
        public string? Description { get; set; }

        private DateTime? _Start;
        private DateTime? _End;

        public DateTime? Start 
        { 
            get
            {
                if (_Start != null) 
                    return _Start.Value;
                else
                {
                    return GetStartFromSubTravels();
                }
            }
            set
            {
                _Start = value;
            }
        }

        private DateTime? GetStartFromSubTravels()
        {
            if (SubTravels != null)
            {
                DateTime? first = null;
                foreach (var travel in SubTravels)
                {
                    if (first == null)
                    {
                        first = travel.Start;
                    }
                    if (travel.Start < first)
                    {
                        first = travel.Start;
                    }
                }
                return first;
            }
            return null;
        }

        public DateTime? End 
        { 
            get
            {
                if (_End != null)
                    return _End.Value;
                else
                {
                    return GetEndFromSubTravels();
                }
            }
            set => _End = value; 
        }

        private DateTime? GetEndFromSubTravels()
        {
            if (SubTravels != null)
            {
                DateTime? end = null;
                foreach (var travel in SubTravels)
                {
                    if (end == null)
                    {
                        end = travel.End;
                    }
                    if (travel.End < end)
                    {
                        end = travel.End;
                    }
                }
                return end;
            }
            return null;
        }

        public List<Media> Media { get; set; } = new List<Media>();

        public Travel(string name)
        {
            Name = name;
        }
    }
}
