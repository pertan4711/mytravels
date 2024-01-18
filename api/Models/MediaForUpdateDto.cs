using System.ComponentModel.DataAnnotations;

namespace MyTravels.API.Models
{
    public class MediaForUpdateDto
    {
        [Required(ErrorMessage = "You should provide a NAME value")]
        [MaxLength(50)]
        public string Name { get; set; } = string.Empty;
        [MaxLength(2000)]
        public string? Description { get; set; }
        public string? Url { get; set; }
        public string? Type { get; set; }
    }
}