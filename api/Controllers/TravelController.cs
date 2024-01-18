using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using MyTravels.API.Entities;
using MyTravels.API.Models;
using MyTravels.API.Services;
using System.Text.Json;

namespace MyTravels.API.AddControllers
{
    /// <summary>
    /// Access travel info at high level -
    /// Get Travels, specific travel or create a travel
    /// </summary>
    [ApiController]
    [Authorize]
    [ApiVersion("0.1")]
    [Route("api/v{version:apiVersion}/travels")]
    public class TravelController : ControllerBase
    {
        private readonly ILogger<TravelController> _logger;
        private readonly IMailService _mailService;
        private readonly ITravelsRepository _travelsRepository;
        private readonly IMapper _mapper;
        const int maxTravelsPageSize = 10;


        /// <summary>
        /// Constructor for Travel controller
        /// </summary>
        /// <param name="logger">External logger</param>
        /// <param name="mailService">Imaginary MailService</param>
        /// <param name="travelsRepository"></param>
        /// <param name="mapper">Automapper instance</param>
        /// <exception cref="ArgumentNullException"></exception>
        public TravelController(
            ILogger<TravelController> logger,
            IMailService mailService,
            ITravelsRepository travelsRepository,
            IMapper mapper)
        {
            _logger = logger ?? throw new ArgumentNullException(nameof(logger));
            _mailService = mailService ?? throw new ArgumentNullException(nameof(mailService));
            _travelsRepository = travelsRepository ?? throw new ArgumentNullException(nameof(travelsRepository));
            _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
        }


        /// <summary>
        /// Fetch travel info for all your travels (if not including some filtering or searching)
        /// </summary>
        /// <param name="includeSubTravels">Include subtravels</param>
        /// <param name="name">Search for travel with specific name</param>
        /// <param name="searchQuery">Search for travels which include text from name or description</param>
        /// <param name="pageNumber">Specify page</param>
        /// <param name="pageSize">Specify page size</param>
        /// <returns>List of multiple travels</returns>
        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<ActionResult<IEnumerable<TravelDto>>> GetTravels(
            bool includeSubTravels = false, 
            string? name = null, 
            string? searchQuery = null,
            int pageNumber = 1,
            int pageSize = 10)
        {
            if (pageSize > maxTravelsPageSize)
            {
                pageSize = maxTravelsPageSize;
            }

            var (travels, paginationMetadata) = 
                await _travelsRepository.GetTravelsAsync(includeSubTravels, name, searchQuery, pageNumber, pageSize);

            // Header including pagination info
            Response.Headers.Add("X-Pagination", JsonSerializer.Serialize(paginationMetadata));

            if (includeSubTravels)
            {
                return Ok(_mapper.Map<IEnumerable<TravelDto>>(travels));
            }

            return Ok(_mapper.Map<IEnumerable<TravelWithoutSubTravelsDto>>(travels));
        }


        /// <summary>
        /// Get specific travel info
        /// </summary>
        /// <param name="id">Travel id</param>
        /// <param name="includeSubTravels">Include subtravels</param>
        /// <returns>Info about specific travel</returns>
        /// <response code="200">Returns the requested travel</response>
        [HttpGet("{id}", Name = "GetTravel")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult> GetTravel(int id, bool includeSubTravels = false)
        {
            var travel = await _travelsRepository.GetTravelAsync(id, includeSubTravels);

            if (travel == null)
            {
                _logger.LogInformation($"Travel with id {id} wasn't found");
                return NotFound();
            }

            if (includeSubTravels)
            {
                return Ok(_mapper.Map<TravelDto>(travel));
            }

            return Ok(_mapper.Map<TravelWithoutSubTravelsDto>(travel));
        }


        /// <summary>
        /// Create a new travel with a TravelForCreation DTO
        /// </summary>
        /// <param name="travel">TravelForCreationDto specifying a new travel</param>
        /// <returns>Call to get the newly created travel</returns>
        [HttpPost]
        public async Task<ActionResult<TravelDto>> CreateTravel(TravelForCreationDto travel)
        {
            var createTravel = _mapper.Map<Travel>(travel);

            await _travelsRepository.AddTravelAsync(createTravel);
            await _travelsRepository.SaveChangesAsync();

            var createTravelToReturn = _mapper.Map<TravelDto>(createTravel);

            return CreatedAtRoute(
                "GetTravel", 
                new
                {
                    createTravelToReturn.Id,
                },
                createTravelToReturn);
        }


        [HttpDelete]
        public async Task<ActionResult> DeleteTravel(int travelId)
        {
            var travelEntity = await _travelsRepository.GetTravelAsync(travelId, includeSubTravels: true);

            if (travelEntity != null)
            {
                foreach (var travel in travelEntity.SubTravels)
                {
                    _travelsRepository.DeleteTravel(travel.Id);
                }

                _travelsRepository.DeleteTravel(travelEntity.Id);
                await _travelsRepository.SaveChangesAsync();
                
                _mailService.Send("Travel is removed", $"Travel {travelEntity.Name} with id {travelEntity.Id} is removed.");
            }

            return NoContent();
        }
    }
}