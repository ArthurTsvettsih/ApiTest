using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Models;
using Services.Http;
using Services.Photos;

namespace Services.Albums
{
    public class AlbumsService: IAlbumsService
    {
        private readonly IHttpWrapper<List<Album>> _httpWrapper;
        private readonly IPhotosService _photosService;

        public AlbumsService(IHttpWrapper<List<Album>> httpWrapper, IPhotosService photosService)
        {
            _httpWrapper = httpWrapper;
            _photosService = photosService;
        }

        public async Task<List<Album>> GetAlbums()
        {
            // TODO AT: Extract this into settings
            var albums = await _httpWrapper.MakeHttpCall("http://jsonplaceholder.typicode.com/albums");
            var photos = await _photosService.GetPhotos();

            var result = MapPhotos(albums, photos);

            return result;
        }

        public async Task<List<Album>> GetAlbumsByUserId(int userId)
        {
            var allAlbums = await GetAlbums();

            return allAlbums.Where(x => x.UserId == userId).ToList();
        }

        private List<Album> MapPhotos(List<Album> albums, List<Photo> photos)
        {

            return albums;
        }
    }
}
