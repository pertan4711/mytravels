using System.ComponentModel.DataAnnotations;

namespace MyTravels.API.Models
{
    public class MediaForCreationDto
    {
        [MaxLength(50)]
        public string? Name { get; set; } = string.Empty;
        
        [MaxLength(2000)]
        public string? Description { get; set; }

        [Required(ErrorMessage = "You should provide a Url value")] // Custom error message
        public string Url { get; set; } = string.Empty;

        public string? Type { get; set; }
    }
}