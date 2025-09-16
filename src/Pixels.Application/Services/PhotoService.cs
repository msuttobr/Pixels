using Pixels.Application.Interfaces;
using Pixels.Domain.Entities;

namespace Pixels.Application.Services
{
    public class PhotoService
    {
        private readonly IPhotoRepository _photoRepository;

        public PhotoService(IPhotoRepository photoRepository)
        {
            _photoRepository = photoRepository;
        }

        public async Task<IEnumerable<Photo>> SearchAsync(string query, int perPage)
        {
            if (string.IsNullOrWhiteSpace(query))
                return Enumerable.Empty<Photo>();

            return await _photoRepository.SearchAsync(query, perPage);
        }
    }
}