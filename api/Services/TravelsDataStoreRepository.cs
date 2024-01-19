using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MyTravels.API.Entities;

namespace MyTravels.API.Services
{
    public class TravelsDataStoreRepository : ITravelsRepository
    {
        private readonly IMapper _mapper;

        public TravelsDataStoreRepository(IMapper mapper)
        {
            _mapper = mapper;
        }

        public async Task<(IEnumerable<Travel>, PaginationMetadata)> GetTravelsAsync(
            bool includeSubTravels = true, 
            string? name = null, 
            string? searchQuery = null, 
            int pageNumber = 1, 
            int pageSize = 10)
        {
            var travels = TravelsDataStore.Current.Travels.ToList();
            var totalItemCount = travels.Count();
            var paginationMetadata = new PaginationMetadata(totalItemCount, pageSize, pageNumber);

            var paginated = travels
                .OrderBy(t => t.Name)
                .Skip(pageSize * (pageNumber - 1))
                .Take(pageSize)
                .ToList();

            var travelsToReturn = _mapper.Map<IEnumerable<Travel>>(paginated);

            return (travelsToReturn, paginationMetadata);
        }

        public Task<Travel?> GetTravelAsync(int travelId, bool includeSubTravels)
        {
            var travel = TravelsDataStore.Current.Travels
                .Where(t => t.Id == travelId)
                .FirstOrDefault();
            return Task.FromResult(travel);
        }

        public Task AddTravelAsync(Travel travel)
        {
            throw new NotImplementedException();
        }

        public void DeleteTravel(int travelId)
        {
            throw new NotImplementedException();
        }

        public Task AddMediaAsync(Media media)
        {
            throw new NotImplementedException();
        }

        public Task AddMediaForTravelAsync(int travelId, Media media)
        {
            throw new NotImplementedException();
        }

        public void DeleteMedia(Media media)
        {
            throw new NotImplementedException();
        }

        public Task<(IEnumerable<Media>, PaginationMetadata)> GetMediaAsync(string? name = null, string? searchQuery = null, int pageNumber = 1, int pageSize = 10)
        {
            throw new NotImplementedException();
        }

        public Task<Media?> GetMediaAsync(int mediaId)
        {
            throw new NotImplementedException();
        }

        public Task<Media?> GetMediaAsync(int traveliId, int mediaId)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<Media>> GetMediaFromTravelAsync(int travelId)
        {
            throw new NotImplementedException();
        }

        public Task<bool> MediaExistsAsync(int travelId, int mediaId)
        {
            throw new NotImplementedException();
        }

        public Task<bool> SaveChangesAsync()
        {
            throw new NotImplementedException();
        }

        public Task<bool> TravelExistsAsync(int travelId)
        {
            throw new NotImplementedException();
        }
    }
}
