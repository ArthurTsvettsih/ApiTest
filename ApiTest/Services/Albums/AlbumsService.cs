using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Models;
using Services.Http;

namespace Services.Albums
{
    public class AlbumsService: IAlbumsService
    {
        private readonly IHttpWrapper<List<Album>> _httpWrapper;

        public AlbumsService(IHttpWrapper<List<Album>> httpWrapper)
        {
            _httpWrapper = httpWrapper;
        }

        public async Task<List<Album>> GetAlbums()
        {
            // TODO AT: Cache this
            // TODO AT: Extract this into settings
            var result = await _httpWrapper.MakeHttpCall("http://jsonplaceholder.typicode.com/albums");
            return result;
        }

        public async Task<List<Album>> GetAlbumsByUserId(int userId)
        {
            var allAlbums = await GetAlbums();

            return allAlbums.Where(x => x.UserId == userId).ToList();
        }
    }
}
