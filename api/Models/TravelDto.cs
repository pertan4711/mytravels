using System.Collections.Generic;

namespace MyTravels.API.Models
{
    /// <summary>
    /// A DTO for a travel
    /// </summary>
    public class TravelDto
    {
        /// <summary>
        /// The id of the travel
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// The name of the travel
        /// </summary>
        public string Name { get; set; } = string.Empty;

        /// <summary>
        /// Description of the travel
        /// </summary>
        public string? Description { get; set; }

        public DateTime? Start { get; set; }
        public DateTime? End { get; set; }

        public ICollection<TravelDto>? SubTravels { get; set; } = new List<TravelDto>();
        public ICollection<MediaDto>? Media { get; set; } = new List<MediaDto>();
    }
}
