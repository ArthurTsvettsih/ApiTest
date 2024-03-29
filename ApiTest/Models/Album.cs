﻿using System;
using System.Collections.Generic;

namespace Models
{
    public class Album
    {
        public Album()
        {
            Photos = new List<Photo>();
        }

        public int UserId { get; set; }
        public int Id { get; set; }
        public string Title { get; set; }
        public List<Photo> Photos { get; set; }
    }
}
