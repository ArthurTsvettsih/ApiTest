using System.Collections.Generic;
using Models;

namespace Services.Albums
{
    public interface IAlbumsService
    {
        List<Album> GetAlbums();
        List<Album> GetAlbumsByUserId();
    }
}
