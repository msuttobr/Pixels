using Pixels.Application.Interfaces;
using Pixels.Domain.Entities;

namespace Pixels.Application.Services
{
    public class VideoService
    {
        private readonly IVideoRepository _videoRepository;

        public VideoService(IVideoRepository videoRepository)
        {
            _videoRepository = videoRepository;
        }

        public async Task<IEnumerable<Video>> SearchAsync(string query, int perPage)
        {
            if (string.IsNullOrWhiteSpace(query))
                return Enumerable.Empty<Video>();

            return await _videoRepository.SearchAsync(query, perPage);
        }
    }
}