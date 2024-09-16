using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.StaticFiles;
using MyTravels.API.Services;

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
        /// <returns>File content</returns>
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
                    contentType = "application/octet-stream";
                }

                var bytes = System.IO.File.ReadAllBytes(media.Url);

                return File(bytes, contentType, Path.GetFileName(media.Url));
            }

            return NoContent();
        }
    }
}
