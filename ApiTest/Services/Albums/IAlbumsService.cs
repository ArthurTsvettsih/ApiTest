using System.Collections.Generic;
using System.Threading.Tasks;
using Models;

namespace Services.Albums
{
    public interface IAlbumsService
    {
        Task<List<Album>> GetAlbums();
        Task<List<Album>> GetAlbumsByUserId(int userId);
    }
}
