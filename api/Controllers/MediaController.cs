using Asp.Versioning;
using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.JsonPatch;
using Microsoft.AspNetCore.Mvc;
using MyTravels.API.Entities;
using MyTravels.API.Models;
using MyTravels.API.Services;
using System.Text.Json;

namespace MyTravels.API.Controllers
{
    /// <summary>
    /// Access media containing info about photos and movies
    /// </summary>
    [ApiController]
    //[Authorize]
    [ApiVersion("0.1")]
    [ApiVersion("0.2")]
    [Route("api")]
    public class MediaController : ControllerBase
    {
        private readonly ILogger<MediaController> _logger;
        private readonly ITravelsRepository _travelsRepository;
        private readonly IMapper _mapper;
        const int maxTravelsPageSize = 10;


        /// <summary>
        /// Constructor for Media controller
        /// </summary>
        /// <param name="logger"></param>
        /// <param name="travelsRepository"></param>
        /// <param name="mapper">Automapper instance</param>
        /// <exception cref="ArgumentNullException"></exception>
        public MediaController(
            ILogger<MediaController> logger,
            ITravelsRepository travelsRepository,
            IMapper mapper)
        {
            _logger = logger ?? throw new ArgumentNullException(nameof(logger));
            _travelsRepository = travelsRepository ?? throw new ArgumentException(nameof(travelsRepository));
            _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
        }


        /// <summary>
        /// Get a range or all media (if not including some filtering or searching)
        /// </summary>
        /// <param name="name">Search for media with specific name</param>
        /// <param name="searchQuery">Search for media which include text from name or description</param>
        /// <param name="pageNumber">Specify page</param>
        /// <param name="pageSize">Specify page size</param>
        /// <returns>List of media</returns>
        [HttpGet("media")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<ActionResult<IEnumerable<MediaDto>>> GetAllMedia(
            string? name = null,
            string? searchQuery = null,
            int pageNumber = 1,
            int pageSize = 10)
        {
            try
            {
                if (pageSize > maxTravelsPageSize)
                {
                    pageSize = maxTravelsPageSize;
                }

                var (media, paginationMetadata) =
                    await _travelsRepository.GetMediaAsync(name, searchQuery, pageNumber, pageSize);

                // Header including pagination info
                Response.Headers.Append("Access-Control-Allow-Origin", "*");
                Response.Headers.Append("X-Pagination", JsonSerializer.Serialize(paginationMetadata));

                var mediaDto = _mapper.Map<IEnumerable<MediaDto>>(media);

                return Ok(mediaDto);
            }
            catch (Exception ex)
            {
                _logger.LogCritical(ex, "Exception while getting media.");
                return StatusCode(500, "A problem happened while handling your request.");
            }
        }


        /// <summary>
        /// Get a list of media from a specific travel
        /// </summary>
        /// <param name="travelId">Travel ID</param>
        /// <returns>List of media</returns>
        [HttpGet("travels/{travelId}/media", Name = "GetMediaFromTravel")]
        public async Task<ActionResult<IEnumerable<MediaDto>>> GetMediaFromTravel(int travelId)
        {
            try
            {
                Response.Headers.Append("Access-Control-Allow-Origin", "*");
                if (!await _travelsRepository.TravelExistsAsync(travelId))
                {
                    _logger.LogInformation($"Travel with id {travelId} was not found when accessing media.");
                    return NotFound();
                }
                
                var media = await _travelsRepository.GetMediaFromTravelAsync(travelId);
                var mediaDto = _mapper.Map<IEnumerable<MediaDto>>(media);

                return Ok(mediaDto);
            }
            catch (Exception ex)
            {
                _logger.LogCritical($"Exception while getting media for travel with id {travelId}.", ex);
                return StatusCode(500, "A problem happened while handling your request.");
            }
        }


        /// <summary>
        /// Get specific media
        /// </summary>
        /// <param name="mediaId">Media ID</param>
        /// <returns>Media</returns>
        [HttpGet("media/{mediaId}", Name = "GetMedia")]
        public async Task<ActionResult<MediaDto>> GetMedia(int mediaId)
        {
            try
            {
                var media = await _travelsRepository.GetMediaAsync(mediaId);

                if (media == null)
                {
                    return NotFound();
                }

                return Ok(_mapper.Map<MediaDto>(media));

            }
            catch (Exception)
            {
                _logger.LogCritical($"Exception while getting media with id {mediaId}.");
                return StatusCode(500, "A problem happened while handling your request.");
            }
        }


        /// <summary>
        /// Get specific media
        /// </summary>
        /// <param name="travelId">Travel ID</param>
        /// <param name="mediaId">Media ID</param>
        /// <returns>Media</returns>
        [HttpGet("travels/{travelId}/media/{mediaId}", Name = "GetMediaWithTravel")]
        public async Task<ActionResult<MediaDto>> GetMediaWithTravel(int travelId, int mediaId)
        {
            try
            {
                var media = await _travelsRepository.GetMediaAsync(travelId, mediaId);

                if (media == null)
                {
                    return NotFound();
                }

                return Ok(_mapper.Map<MediaDto>(media));

            }
            catch (Exception)
            {
                _logger.LogCritical($"Exception while getting media with id {mediaId}.");
                return StatusCode(500, "A problem happened while handling your request.");
            }
        }


        /// <summary>
        /// Create new media which belong to a travel.
        /// </summary>
        /// <param name="travelId">Travel ID</param>
        /// <param name="media">Media for creation Data Transfer Object (MediaForCreationDto)</param>
        /// <returns>API call to access newly created instance</returns>
        [HttpPost("travels/{travelId}/media")]
        public async Task<ActionResult<MediaDto>> CreateMediaWithTravel(int travelId, MediaForCreationDto media)
        {
            if (!await _travelsRepository.TravelExistsAsync(travelId))
            {
                return NotFound();
            }

            var finalMedia = _mapper.Map<Media>(media);

            await _travelsRepository.AddMediaForTravelAsync(travelId, finalMedia);
            await _travelsRepository.SaveChangesAsync();

            var createMediaToReturn = _mapper.Map<MediaDto>(finalMedia);

            return CreatedAtRoute("GetMediaWithTravel", new
            {
                travelId,
                mediaId = createMediaToReturn.Id,
            },
            createMediaToReturn);
        }


        /// <summary>
        /// Create new media which do not belong to a travel.
        /// </summary>
        /// <param name="media">Media for creation Data Transfer Object (MediaForCreationDto)</param>
        /// <returns>API call to access newly created instance</returns>
        [HttpPost("media")]
        public async Task<ActionResult<MediaDto>> CreateMedia(MediaForCreationDto media)
        {
            var finalMedia = _mapper.Map<Media>(media);

            await _travelsRepository.AddMediaAsync(finalMedia);
            await _travelsRepository.SaveChangesAsync();

            var createMediaToReturn = _mapper.Map<MediaDto>(finalMedia);

            return CreatedAtRoute("GetMedia", new
            {
                mediaId = createMediaToReturn.Id,
            },
            createMediaToReturn);
        }


        /// <summary>
        /// Udpate media with full update
        /// </summary>
        /// <param name="travelId">Travel ID</param>
        /// <param name="mediaId">Media ID</param>
        /// <param name="media">Media to update to</param>
        /// <returns>No content (204)</returns>
        [HttpPut("travels/{travelId}/media/{mediaId}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult> UpdateMedia(
            int travelId, 
            int mediaId, 
            MediaForUpdateDto media)
        {
            if (!await _travelsRepository.TravelExistsAsync(travelId))
            {
                return NotFound();
            }

            if (!await _travelsRepository.MediaExistsAsync(travelId, mediaId))
            {
                return NotFound();
            }

            var existingMedia = await _travelsRepository.GetMediaAsync(mediaId);
            _mapper.Map(media, existingMedia);

            await _travelsRepository.SaveChangesAsync();

            return NoContent();
        }


        /// <summary>
        /// Partially update media with JsonPatchDocument
        /// </summary>
        /// <param name="travelId">Travel ID</param>
        /// <param name="mediaId">Media ID</param>
        /// <param name="patchDocument"></param>
        /// <returns></returns>
        [HttpPatch("travels/{travelId}/media/{mediaId}")]
        public async Task<ActionResult> PartiallyUpdateMedia(
            int travelId, 
            int mediaId,
            JsonPatchDocument<MediaForUpdateDto> patchDocument)
        {
            if (!await _travelsRepository.TravelExistsAsync(travelId))
            {
                return NotFound();
            }

            var media = await _travelsRepository.GetMediaAsync(mediaId);
            if (media == null)
            {
                return NotFound();
            }

            var mediaToPatch = _mapper.Map<MediaForUpdateDto>(media);

            // Checkar inkommande patchDoc
            patchDocument.ApplyTo(mediaToPatch, ModelState);
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            // Checkar om modellen inte bryter mot något nytt
            if (!TryValidateModel(mediaToPatch))
            {
                return BadRequest(ModelState);
            }

            _mapper.Map(mediaToPatch, media);
            await _travelsRepository.SaveChangesAsync();

            return NoContent();
        }


        /// <summary>
        /// Delete media
        /// </summary>
        /// <param name="travelId">Travel ID</param>
        /// <param name="mediaId">Media ID</param>
        /// <returns></returns>
        [HttpDelete("travels/{travelId}/media/{mediaId}")]
        public async Task<ActionResult> DeleteMedia(int travelId, int mediaId)
        {
            if (!await _travelsRepository.TravelExistsAsync(travelId))
            {
                return NotFound();
            }

            var mediaEntity = await _travelsRepository.GetMediaAsync(travelId, mediaId);
            if (mediaEntity == null) 
            { 
                return NotFound(); 
            } 

            _travelsRepository.DeleteMedia(mediaEntity);
            await _travelsRepository.SaveChangesAsync();

            return NoContent();
        }
    }
}
