﻿using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.StaticFiles;
using MyTravels.API.Services;

namespace MyTravels.API.Controllers
{
    [ApiController]
    [Authorize]
    [ApiVersion("0.1")]
    [Route("api/v{version:apiVersion}/file")]
    public class FileController : ControllerBase
    {
        private readonly FileExtensionContentTypeProvider _fileExtensionContentTypeProvider;
        private readonly ITravelsRepository _travelsRepository;

        public FileController(
            FileExtensionContentTypeProvider fileExtensionContentTypeProvider,
            ITravelsRepository travelsRepository
            )
        {
            _fileExtensionContentTypeProvider = fileExtensionContentTypeProvider ?? throw new ArgumentException(nameof(fileExtensionContentTypeProvider));
            _travelsRepository = travelsRepository ?? throw new ArgumentNullException(nameof(travelsRepository));
        }

        [HttpGet("{mediaId}")]
        public async Task<ActionResult> GetFile(int mediaId)
        {
            var media = await _travelsRepository.GetMediaAsync(mediaId);

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
