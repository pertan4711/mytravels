namespace MyTravels.API.Models
{
    public class SubTravelDto
    {
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public string? Description { get; set; }

        public DateTime? Start { get; set; }
        public DateTime? End { get; set; }


        public ICollection<MediaDto>? Media { get; set; } = new List<MediaDto>();
    }
}
