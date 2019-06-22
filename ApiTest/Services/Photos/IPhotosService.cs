using System.Collections.Generic;
using System.Threading.Tasks;
using Models;

namespace Services.Photos
{
    public interface IPhotosService
    {
        Task<List<Photo>> GetPhotos();
    }
}
