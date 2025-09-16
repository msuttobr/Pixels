using System.Net.Http.Json;
using System.Text.Json;
using Microsoft.Extensions.Options;
using Pixels.Application.DTOs;
using Pixels.Application.Interfaces;
using Pixels.Domain.Entities;
using Pixels.Infrastructure.Configurations;

namespace Pixels.Infrastructure.Repositories
{
    public class VideoRepository : IVideoRepository
    {
        private readonly HttpClient _httpClient;
        private readonly PexelsSettings _settings;

        public VideoRepository(HttpClient httpClient, IOptions<PexelsSettings> settings)
        {
            _httpClient = httpClient;
            _settings = settings.Value;

            _httpClient.BaseAddress = new Uri(_settings.VideosBaseUrl);
            _httpClient.DefaultRequestHeaders.Add("Authorization", _settings.ApiKey);
        }
        public async Task<IEnumerable<Video>> SearchAsync(string query, int perPage)
        {
            if (string.IsNullOrWhiteSpace(query))
                return Enumerable.Empty<Video>();

            var response = await _httpClient.GetFromJsonAsync<VideoResponse>($"search?query={query}&per_page={perPage}");
            return response?.Videos ?? Enumerable.Empty<Video>();
        }
    }
}