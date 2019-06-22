using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Models;

namespace Services.Mappers
{
    class AlbumMapper: IMapper<Album, Photo>
    {
        public List<Album> MapItems(List<Album> albums, List<Photo> photos)
        {
            var photoGroups = photos.ToLookup(x => x.AlbumId);

            foreach (var album in albums)
            {
                album.Photos = photoGroups[album.Id].ToList();
            }

            return albums;
        }
    }
}
