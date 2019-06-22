using System;
using System.Collections.Generic;
using System.Text;
using Models;

namespace Services
{
    public interface IPhotosService
    {
        List<Photo> GetPhotos();
    }
}
