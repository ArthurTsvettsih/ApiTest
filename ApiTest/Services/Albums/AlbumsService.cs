using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Models;

namespace Services.Albums
{
    public class AlbumsService: IAlbumsService
    {
        public async Task<List<Album>> GetAlbums()
        {
            throw new NotImplementedException();
        }

        public async Task<List<Album>> GetAlbumsByUserId()
        {
            throw new NotImplementedException();
        }
    }
}
