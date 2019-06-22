using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.Extensions.DependencyInjection;
using Services.Albums;
using Services.Photos;

namespace Services
{
    public static class ServicesDi
    {
        public static void SetupDependencyInjection(IServiceCollection services)
        {
            services.AddTransient<IAlbumsService, AlbumsService>();
            services.AddTransient<IPhotosService, PhotosService>();
        }
    }
}
