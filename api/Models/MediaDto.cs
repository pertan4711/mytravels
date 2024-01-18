namespace MyTravels.API.Models
{
    public class MediaDto
    {
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public string? Description { get; set; }
        public string? Url { get; set; }
        public string? Type { get; set; }
    }
}