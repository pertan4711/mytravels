using MyTravels.API.Entities;

namespace MyTravels.API.Services
{
    /// <summary>
    /// Repository accessing info for travel and media
    /// </summary>
    public interface ITravelsRepository
    {
        // -----------------------------------------------------------------
        // Travels
        // -----------------------------------------------------------------

        /// <summary>
        /// Get a range or all of travels, splitted up in pages
        /// </summary>
        /// <param name="includeSubTravels">Include sub travels in list</param>
        /// <param name="name">Search for specific name</param>
        /// <param name="searchQuery">Search for text in name or description</param>
        /// <param name="pageNumber">Page number</param>
        /// <param name="pageSize">Page size</param>
        /// <returns>A list of travels</returns>
        Task<(IEnumerable<Travel>, PaginationMetadata)> GetTravelsAsync(
            bool includeSubTravels = true, 
            string? name = null, 
            string? searchQuery = null,
            int pageNumber = 1,
            int pageSize = 10);

        /// <summary>
        /// Get specific travel
        /// </summary>
        /// <param name="travelId">Travel ID</param>
        /// <param name="includeSubTravels">Include sub travels</param>
        /// <returns>Specific travel</returns>
        Task<Travel?> GetTravelAsync(int travelId, bool includeSubTravels);

        /// <summary>
        /// Helper function. Does travel exist?
        /// </summary>
        /// <param name="travelId">Travel ID</param>
        /// <returns>true or false</returns>
        Task<bool> TravelExistsAsync(int travelId);

        /// <summary>
        /// Add travel to repository
        /// </summary>
        /// <param name="travel">Travel entity</param>
        /// <returns>Nothing</returns>
        Task AddTravelAsync(Travel travel);

        /// <summary>
        /// Delete travel from repository
        /// </summary>
        /// <param name="travel">Travel entity</param>
        void DeleteTravel(int travelId);


        // -----------------------------------------------------------------
        // Media
        // -----------------------------------------------------------------

        /// <summary>
        /// Get a range or all of media, splitted up in pages
        /// </summary>
        /// <param name="name">Search for specific name</param>
        /// <param name="searchQuery">Search for text in name</param>
        /// <param name="pageNumber">Page number</param>
        /// <param name="pageSize">Page size</param>
        /// <returns>A list of media</returns>
        Task<(IEnumerable<Media>, PaginationMetadata)> GetMediaAsync(
            string? name = null,
            string? searchQuery = null,
            int pageNumber = 1,
            int pageSize = 10);

        /// <summary>
        /// Get specific media
        /// </summary>
        /// <param name="mediaId">Media ID</param>
        /// <returns>Media entity</returns>
        Task<Media?> GetMediaAsync(int mediaId);

        /// <summary>
        /// Get specific media
        /// </summary>
        /// <param name="traveliId">Travel ID</param>
        /// <param name="mediaId">Media ID</param>
        /// <returns>Media entity</returns>
        Task<Media?> GetMediaAsync(int traveliId, int mediaId);

        /// <summary>
        /// Get all media for specific travel
        /// </summary>
        /// <param name="travelId">Travel ID</param>
        /// <param name="pageNumber">Page number</param>
        /// <param name="pageSize">Page size</param>
        /// <returns>List of media</returns>
        Task<(IEnumerable<Media>, PaginationMetadata)> GetMediaFromTravelAsync(int travelId,
            int pageNumber = 1,
            int pageSize = 10);

        /// <summary>
        /// Add media for travel
        /// </summary>
        /// <param name="media">Media entity</param>
        /// <returns>Nothing</returns>
        Task AddMediaAsync(Media media);

        /// <summary>
        /// Add media for travel
        /// </summary>
        /// <param name="travelId">Travel ID</param>
        /// <param name="media">Media entity</param>
        /// <returns>Nothing</returns>
        Task AddMediaForTravelAsync(int travelId, Media media);

        /// <summary>
        /// Helper function. Does media exist?
        /// </summary>
        /// <param name="travelId">Travel ID</param>
        /// <param name="mediaId">Media ID</param>
        /// <returns>true or false</returns>
        Task<bool> MediaExistsAsync(int travelId, int mediaId);

        /// <summary>
        /// Delete media from repository
        /// </summary>
        /// <param name="mediaId">Media entity</param>
        void DeleteMedia(Media mediaId);

        // -----------------------------------------------------------------
        // System persistence
        // -----------------------------------------------------------------

        /// <summary>
        /// Save changes to repository
        /// </summary>
        /// <returns>Did it succeed?</returns>
        Task<bool> SaveChangesAsync();
    }
}
