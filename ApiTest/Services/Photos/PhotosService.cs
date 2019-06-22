using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Models;
using Services.Http;

namespace Services.Photos
{
    public class PhotosService: IPhotosService
    {
        private readonly IHttpWrapper<List<Photo>> _httpWrapper;

        public PhotosService(IHttpWrapper<List<Photo>> httpWrapper)
        {
            _httpWrapper = httpWrapper;
        }

        public async Task<List<Photo>> GetPhotos()
        {
            return await _httpWrapper.MakeHttpCall("http://jsonplaceholder.typicode.com/photos");
        }
    }
}
