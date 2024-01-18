using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MyTravels.API.Entities
{
    public class Media
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        [Required]
        [MaxLength(50)]
        public string Name { get; set; }


        [ForeignKey("TravelId")]
        public int? TravelId { get; set; }
        public Travel? Travel { get; set; }


        [MaxLength(2000)]
        public string? Description { get; set; }
        
        public string? Url { get; set; }
        public string? Type { get; set; }

        public Media(string name)
        {
            Name = name;
        }
    }
}
