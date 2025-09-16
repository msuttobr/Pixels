using Pixels.Domain.Entities;

namespace Pixels.Application.Interfaces
{
    public interface IPhotoRepository
    {
        Task<IEnumerable<Photo>> SearchAsync(string query, int perPage);
    }
}