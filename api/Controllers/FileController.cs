using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.StaticFiles;
using MyTravels.API.Services;
using System.Text.Json;

namespace MyTravels.API.Controllers
{
    /// <summary>
    /// Return a file. The route is set in header of class.
    /// </summary>
    [ApiController]
    //[Authorize]
    [ApiVersion("0.1")]
    [Route("api/v{version:apiVersion}/file")]
    public class FileController : ControllerBase
    {
        private readonly FileExtensionContentTypeProvider _fileExtensionContentTypeProvider;
        private readonly ITravelsRepository _travelsRepository;
        private string _mediaPath = "";


        /// <summary>
        /// Constructor need type provider and repo
        /// </summary>
        /// <param name="fileExtensionContentTypeProvider"></param>
        /// <param name="travelsRepository"></param>
        /// <param name="configuration"></param>
        /// <exception cref="ArgumentException"></exception>
        /// <exception cref="ArgumentNullException"></exception>
        public FileController(
            FileExtensionContentTypeProvider fileExtensionContentTypeProvider,
            ITravelsRepository travelsRepository,
            IConfiguration configuration
            )
        {
            _fileExtensionContentTypeProvider = fileExtensionContentTypeProvider ?? throw new ArgumentException(nameof(fileExtensionContentTypeProvider));
            _travelsRepository = travelsRepository ?? throw new ArgumentNullException(nameof(travelsRepository));
            _mediaPath = configuration["Media:MediaPath"];
        }


        /// <summary>
        /// Return a media file
        /// </summary>
        /// <param name="mediaId">ID for media</param>
        /// <returns>File content (image)</returns>
        [HttpGet("{mediaId}")]
        public async Task<ActionResult> GetFile(int mediaId)
        {
            var media = await _travelsRepository.GetMediaAsync(mediaId);

            Response.Headers.Append("Access-Control-Allow-Origin", "*");

            if (media == null)
            {
                return NotFound();
            }

            if (media.Url != null)
            {
                if (!_fileExtensionContentTypeProvider.TryGetContentType(media.Url, out var contentType))
                {
                    contentType = "application/octet-stream"; // catch all if contentTypeProvider cannot determine
                }

                var bytes = System.IO.File.ReadAllBytes(media.Url);

                return File(bytes, contentType, Path.GetFileName(media.Url));
            }

            return NoContent();
        }

        /// <summary>
        /// Return media files
        /// </summary>
        /// <param name="travelId">ID for travel</param>
        /// <returns>File contents (images)</returns>
        [HttpGet("travels/{travelId}/medias")]
        public async Task<ActionResult> GetFiles(int travelId,
            int pageNumber = 1,
            int pageSize = 10)
        {
            var (medias, paginationMetadata) = await _travelsRepository.GetMediaFromTravelAsync(travelId, pageNumber, pageSize);

            Response.Headers.Append("Access-Control-Allow-Origin", "*");
            Response.Headers.Append("X-Pagination", JsonSerializer.Serialize(paginationMetadata));

            if (medias == null)
            {
                return NotFound();
            }

            var files = new List<FileContentResult>();
            foreach (var media in medias.Take(pageSize))
            {
                if (media.Url != null)
                {
                    if (!_fileExtensionContentTypeProvider.TryGetContentType(media.Url, out var contentType))
                    {
                        contentType = "application/octet-stream"; // catch all if contentTypeProvider cannot determine
                    }

                    var bytes = System.IO.File.ReadAllBytes(media.Url);

                    var myFile = File(bytes, contentType, Path.GetFileName(media.Url));
                    files.Add(myFile);
                }
            }

            return Ok(files);
        }
    }
}
