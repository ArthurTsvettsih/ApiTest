using System;
using System.Collections.Generic;
using System.Text;
using Models;

namespace Services
{
    public interface IAlbumsService
    {
        List<Album> GetAlbums();
        List<Album> GetAlbumsByUserId();
    }
}
