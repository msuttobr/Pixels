namespace Pixels.Api.Controllers
{
    using Microsoft.AspNetCore.Mvc;
    using Pixels.Application.DTOs;
    using Pixels.Infrastructure.Configurations;
    using Pixels.Application.Services;
    using Microsoft.Extensions.Options;

    [ApiController]
    [Route("api/[controller]")]
    public class VideoController : ControllerBase
    {
        private readonly VideoService _videoService;
        private readonly SearchSettings _searchSettings;

        public VideoController(VideoService videoService, IOptions<SearchSettings> searchSettings)
        {
            _videoService = videoService;
            _searchSettings = searchSettings.Value;
        }

        /// <summary>
        /// Busca vídeos pelo termo informado, também pode incluir um limite de vídeos.
        /// </summary>
        [HttpGet("search")]
        public async Task<IActionResult> Search([FromQuery] string query, [FromQuery] int? perPage)
        {
            if (string.IsNullOrWhiteSpace(query))
                return BadRequest("Query parameter is required.");

            int effectivePerPage = perPage ?? _searchSettings.DefaultPerPage;

            var videos = await _videoService.SearchAsync(query, effectivePerPage);

            var response = new VideoResponse
            {
                Videos = videos.ToList()
            };

            return Ok(response);
        }
    }
}