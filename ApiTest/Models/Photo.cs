using System;
using System.Collections.Generic;
using System.Text;

namespace Models
{
    public class Photo
    {
        public int AlbumId { get; set; }
        public int Id { get; set; }
        public string Title { get; set; }
        
        // The urls could be of type Uri, but if they are invalid it would fail to deserialize 
        public string Url { get; set; }
        public string ThumbnailUrl { get; set; }
    }
}
