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

        private List<MediaDto>? _Media;
        public List<MediaDto>? Media 
        { 
            get
            {
                if (_Media != null)
                {
                    return _Media;
                }
                else
                {
                    return GetMediaFromSubTravels();
                }
            }
            set { _Media = value; }
        }

        private List<MediaDto>? GetMediaFromSubTravels()
        {
            if (SubTravels != null)
            {
                var media = new List<MediaDto>();
                foreach (var travel in SubTravels)
                {
                    if (travel.Media != null && travel.Media.Count > 0)
                    {
                        media.AddRange(travel.Media);
                    }
                }
                return media;
            }
            return null;
        }

        public ICollection<TravelDto>? SubTravels { get; set; } = new List<TravelDto>();

        public int TravelId { get; set; }
    }
}
