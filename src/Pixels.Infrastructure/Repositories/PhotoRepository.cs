using System.Net.Http.Json;
using Pixels.Application.Interfaces;
using Pixels.Domain.Entities;
using Pixels.Application.DTOs;
using Microsoft.Extensions.Options;
using Pixels.Infrastructure.Configurations;


namespace Pixels.Infrastructure.Repository
{
    public class PhotoRepository : IPhotoRepository
    {
        private readonly HttpClient _httpClient;
        private readonly PexelsSettings _settings;
        public PhotoRepository(HttpClient httpClient, IOptions<PexelsSettings> settings)
        {
            _httpClient = httpClient;
            _settings = settings.Value;

            _httpClient.BaseAddress = new Uri(_settings.BaseUrl);
            _httpClient.DefaultRequestHeaders.Add("Authorization", _settings.ApiKey);
        }

        public async Task<IEnumerable<Photo>> SearchAsync(string query, int perPage)
        {
            if (string.IsNullOrWhiteSpace(query))
                return Enumerable.Empty<Photo>();

            var response = await _httpClient.GetFromJsonAsync<PhotoResponse>(
                $"search?query={Uri.EscapeDataString(query)}&per_page={perPage}");
            return response?.Photos ?? Enumerable.Empty<Photo>();
        }
    }
}