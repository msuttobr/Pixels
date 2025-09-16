using Pixels.Domain.Entities;

namespace Pixels.Application.DTOs
{
    public class PhotoResponse
    {
        public List<Photo> Photos { get; set; } = new();
    }

}