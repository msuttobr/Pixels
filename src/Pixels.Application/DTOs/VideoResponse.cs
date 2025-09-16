using Pixels.Domain.Entities;

namespace Pixels.Application.DTOs
{
    public class VideoResponse
    {
        public List<Video> Videos { get; set; } = new();
    }
}