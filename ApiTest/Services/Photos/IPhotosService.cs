using System.Collections.Generic;
using Models;

namespace Services.Photos
{
    public interface IPhotosService
    {
        List<Photo> GetPhotos();
    }
}
