using System;
using System.Collections.Generic;
using System.Linq;
using Models;

namespace ServicesTests.Builders
{
    public class AlbumMapperListBuilder
    {
        public List<Album> Albums;
        public List<Photo> Photos;

        public AlbumMapperListBuilder()
        {
            Albums = new List<Album>();
            Photos = new List<Photo>();
        }

        public AlbumMapperListBuilder WithAlbum(int albumId, string title)
        {
            if (Albums.Any(x => x.Id == albumId))
                throw new ArgumentException($"{nameof(albumId)} is already in the list of {nameof(Albums)}. {nameof(albumId)} - {albumId}");

            Albums.Add(new Album
            {
                Id = albumId,
                Title = title
            });

            return this;
        }

        public AlbumMapperListBuilder WithPhoto(int albumId, int photoId)
        {
            if (Photos.Any(x => x.Id == photoId))
                throw new ArgumentException($"{nameof(photoId)} is already in the list of {nameof(Photos)}. {nameof(photoId)} - {photoId}");

            Photos.Add(new Photo()
            {
                Id = photoId,
                AlbumId = albumId
            });

            return this;
        }

    }
}
