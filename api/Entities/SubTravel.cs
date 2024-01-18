using MyTravels.API.Models;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MyTravels.API.Entities
{
    public class SubTravel
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        [Required]
        [MaxLength(50)]
        public string Name { get; set; }
        
        [ForeignKey("TravelId")]
        public Travel? Travel { get; set; }
        public int TravelId { get; set; }

        [MaxLength(2000)]
        public string? Description { get; set; }

        public DateTime? Start { get; set; }
        public DateTime? End { get; set; }

        public ICollection<Media> Media { get; set; } = new List<Media>();

        public SubTravel(string name)
        {
            Name = name;
        }
    }
}
