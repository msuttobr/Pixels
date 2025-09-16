namespace Pixels.Api.Extensions
{
    using Microsoft.Extensions.Configuration;
    using Microsoft.Extensions.DependencyInjection;
    using Pixels.Application.Interfaces;
    using Pixels.Application.Services;
    using Pixels.Infrastructure.Configurations;
    using Pixels.Infrastructure.Repositories;
    using Pixels.Infrastructure.Repository;

    public static class ServiceCollectionExtensions
    {
        public static IServiceCollection ExtensionsCollection(this IServiceCollection services, IConfiguration config)
        {
            // Pexels configuration
            services.Configure<PexelsSettings>(config.GetSection("Pexels"));

            // Search configuration
            services.Configure<SearchSettings>(config.GetSection("SearchSettings"));
            
            // Photo
            services.AddHttpClient<IPhotoRepository, PhotoRepository>();
            services.AddScoped<PhotoService>();

            // Video
            services.AddHttpClient<IVideoRepository, VideoRepository>();
            services.AddScoped<VideoService>();
            
            return services;
        }
    }
}