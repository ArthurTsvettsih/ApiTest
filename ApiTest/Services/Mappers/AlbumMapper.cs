using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Models;

namespace Services.Mappers
{
    public class AlbumMapper: IMapper<Album, Photo>
    {
        public List<Album> MapItems(List<Album> albums, List<Photo> photos)
        {
            if(albums == null || photos == null)
                throw new ArgumentException($"Neither {nameof(albums)} or {nameof(photos)} can be null. {nameof(albums)} - {albums} | {nameof(photos)} - {photos}");

            if (photos.Count < 1 || albums.Count < 1)
                return albums;

            var photoGroups = photos.ToLookup(x => x.AlbumId);

            foreach (var album in albums)
            {
                album.Photos = photoGroups[album.Id].ToList();
            }

            return albums;
        }
    }
}
