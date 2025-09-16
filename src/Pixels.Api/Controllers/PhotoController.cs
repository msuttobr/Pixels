using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using Pixels.Application.Services;
using Pixels.Infrastructure.Configurations;

namespace Pixels.Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class PhotoController : ControllerBase
    {
        private readonly PhotoService _photoService;
        private readonly SearchSettings _searchSettings;

        public PhotoController(PhotoService photoService, IOptions<SearchSettings> searchSettings)
        {
            _photoService = photoService;
            _searchSettings = searchSettings.Value;
        }

        /// <summary>
        /// Busca fotos pelo termo informado, também pode incluir um limite de fotos.
        /// </summary>
        [HttpGet("search")]
        public async Task<IActionResult> Search([FromQuery] string query, [FromQuery] int? perPage)
        {
            if (string.IsNullOrWhiteSpace(query))
            {
                return BadRequest("Query parameter is required.");
            }
            int pageSize = perPage ?? _searchSettings.DefaultPerPage;
            if (pageSize <= 0 || pageSize > 10)
            {
                return BadRequest("perPage must be between 1 and 10.");
            }
            var photos = await _photoService.SearchAsync(query, pageSize);
            return Ok(photos);
        }
    }
}