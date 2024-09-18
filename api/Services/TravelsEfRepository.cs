using Microsoft.EntityFrameworkCore;
using MyTravels.API.DbContexts;
using MyTravels.API.Entities;
using System.Xml.Linq;


namespace MyTravels.API.Services
{
    /// <summary>
    /// Implementation of repository interface for Entity Framework
    /// </summary>
    public class TravelsEfRepository : ITravelsRepository
    {
        private readonly TravelContext _context;

        /// <summary>
        /// Constructor of EF context
        /// </summary>
        /// <param name="context">EF context</param>
        /// <exception cref="ArgumentNullException">context is invalid</exception>
        public TravelsEfRepository(TravelContext context)
        {
            _context = context ?? throw new ArgumentNullException(nameof(context));
        }


        // -----------------------------------------------------------------
        // Travels
        // -----------------------------------------------------------------
        public async Task<(IEnumerable<Travel>, PaginationMetadata)> GetTravelsAsync(
            bool includeSubTravels, 
            string? name = null, 
            string? searchQuery = null,
            int pageNumber = 1,
            int pageSize = 10)
        {
            var travels = _context.Travels as IQueryable<Travel>;

            if (includeSubTravels)
            {
                travels = travels
                    .Include(t => t.Media)
                    .Include(t => t.SubTravels)
                    .Include("SubTravels.Media"); // Subtravel media
            }
            else
            {
                travels = travels
                    .Where(t => t.TravelId == null);
            }

            if (!string.IsNullOrWhiteSpace(name))
            {
                name = name.Trim();
                travels = travels.Where(t => t.Name == name);
            }

            if (!string.IsNullOrWhiteSpace(searchQuery))
            {
                searchQuery = searchQuery.Trim();
                travels = travels.Where(t => t.Name.Contains(searchQuery)
                    || (t.Description != null && t.Description.Contains(searchQuery)));
            }

            var totalItemCount = await travels.CountAsync();
            var paginationMetadata = new PaginationMetadata(totalItemCount, pageSize, pageNumber);

            var travelsToReturn = await travels
                .OrderBy(t => t.Start)
                .ThenBy(t => t.Name)
                .Skip(pageSize * (pageNumber - 1))
                .Take(pageSize)
                .ToListAsync();

            return (travelsToReturn, paginationMetadata);
        }


        public async Task<Travel?> GetTravelAsync(int travelId, bool includeSubTravels)
        {
            if (includeSubTravels)
            {
                var travel = await _context.Travels
                    .Include(t => t.Media) // Travel media
                    .Include(t => t.SubTravels)
                    .Include("SubTravels.Media") // Subtravel media
                    .Where(t => t.Id == travelId)
                    .FirstOrDefaultAsync();
                return travel;
            }

            return await _context.Travels
                .Where(t => t.Id == travelId)
                .FirstOrDefaultAsync();
        }

        public async Task<bool> TravelExistsAsync(int travelId)
        {
            return await _context.Travels.AnyAsync(t => t.Id == travelId);
        }

        public Task AddTravelAsync(Travel travel)
        {
            _context.Travels.Add(travel);
            return Task.CompletedTask;
        }

        public void DeleteTravel(int travelId)
        {
            throw new NotImplementedException();
        }


        // -----------------------------------------------------------------
        // Media
        // -----------------------------------------------------------------
        public async Task<(IEnumerable<Media>, PaginationMetadata)> GetMediaAsync(
            string? name = null,
            string? searchQuery = null,
            int pageNumber = 1,
            int pageSize = 10)
        {
            var media = _context.Media as IQueryable<Media>;

            if (!string.IsNullOrWhiteSpace(searchQuery))
            {
                searchQuery = searchQuery.Trim();
                media = media.Where(t => t.Description != null && t.Description.Contains(searchQuery));
            }

            var totalItemCount = await media.CountAsync();
            var paginationMetadata = new PaginationMetadata(totalItemCount, pageSize, pageNumber);

            var mediaToReturn = await media
                .OrderBy(t => t.Id)
                .Skip(pageSize * (pageNumber - 1))
                .Take(pageSize)
                .ToListAsync();

            return (mediaToReturn, paginationMetadata);
        }

        public async Task<Media?> GetMediaAsync(int mediaId)
        {
            return await _context.Media.FirstOrDefaultAsync(m => m.Id == mediaId);
        }

        public async Task<Media?> GetMediaAsync(int travelId, int mediaId)
        {
            return await _context.Media.FirstOrDefaultAsync(m => m.Id == mediaId && m.TravelId == travelId);
        }

        public async Task<(IEnumerable<Media>, PaginationMetadata)> GetMediaFromTravelAsync(int travelId,
            int pageNumber = 1,
            int pageSize = 10)
        {
            var travel = await _context.Travels
                .Where(t => t.Id == travelId)
                .Include(m => m.Media)
                .Include(t => t.SubTravels)
                .SingleOrDefaultAsync();

            if (travel != null)
            {
                var medias = travel.Media;
                var totalItemCount = medias.Count();
                
                var subTravelMedia = travel.SubTravels.SelectMany(m => m.Media);
                medias.AddRange(subTravelMedia);

                var paginationMetadata = new PaginationMetadata(totalItemCount, pageSize, pageNumber);

                var mediaToReturn = medias
                    .OrderBy(m => m.Id)
                    .Skip(pageSize * (pageNumber - 1))
                    .Take(pageSize)
                    .ToList();

                return (mediaToReturn, paginationMetadata);
            }

            return ([], new PaginationMetadata(0, pageSize, pageNumber));
        }


        public async Task AddMediaAsync(Media media)
        {
            _context.Media.Add(media);
        }

        public async Task AddMediaForTravelAsync(int travelId, Media media)
        {
            var travel = await _context.Travels.FirstOrDefaultAsync(t => t.Id == travelId);

            if (travel != null)
            {
                travel.Media.Add(media);
            }
        }

        public async Task<bool> MediaExistsAsync(int travelId, int mediaId)
        {
            var travel = await _context.Travels
                .Include(t => t.Media)
                .FirstOrDefaultAsync(t => t.Id == travelId);

            if (travel != null)
            {
                var media = travel.Media.FirstOrDefault(t => t.Id == mediaId);
                return media != null;
            }

            return false;
        }

        public void DeleteMedia(Media media)
        {
            _context.Media.Remove(media);
        }


        // -------------------------------------- //
        // System
        // -------------------------------------- //
        public async Task<bool> SaveChangesAsync()
        {
            return (await _context.SaveChangesAsync() >= 0);
        }
    }
}
