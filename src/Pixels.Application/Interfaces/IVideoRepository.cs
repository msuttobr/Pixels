using Pixels.Domain.Entities;

namespace Pixels.Application.Interfaces
{
    public interface IVideoRepository
    {
        Task<IEnumerable<Video>> SearchAsync(string query, int perPage);
    }
}