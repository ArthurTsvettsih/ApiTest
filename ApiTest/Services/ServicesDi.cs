using Microsoft.Extensions.DependencyInjection;
using Models;
using Services.Albums;
using Services.Http;
using Services.Mappers;
using Services.Photos;

namespace Services
{
    public static class ServicesDi
    {
        public static void SetupDependencyInjection(IServiceCollection services)
        {
            //TODO AT: Add DI tests
            services.AddTransient<IAlbumsService, AlbumsService>();
            services.AddTransient<IPhotosService, PhotosService>();
            services.AddTransient(typeof(IHttpWrapper<>), typeof(HttpWrapper<>));
            
            //TODO AT: This should be generic. Maybe a factory?
            services.AddTransient(typeof(IMapper<Album, Photo>), typeof(AlbumMapper));
        }
    }
}
