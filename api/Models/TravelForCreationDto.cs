using System.ComponentModel.DataAnnotations;

namespace MyTravels.API.Models
{
    public class TravelForCreationDto
    {
        [Required]
        [MaxLength(50)]
        public string Name { get; set; } = string.Empty;

        [MaxLength(2000)]
        public string? Description { get; set; }

        public DateTime? Start { get; set; }
        public DateTime? End { get; set; }

        public ICollection<TravelDto>? SubTravels { get; set; } = new List<TravelDto>();
        public ICollection<MediaDto>? Media { get; set; } = new List<MediaDto>();
    }
}