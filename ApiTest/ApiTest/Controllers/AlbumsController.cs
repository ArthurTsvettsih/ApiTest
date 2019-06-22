using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Models;
using Services.Albums;

namespace ApiTest.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AlbumsController : ControllerBase
    {
        private readonly IAlbumsService _albumsService;

        public AlbumsController(IAlbumsService albumsService)
        {
            _albumsService = albumsService;
        }

        [HttpGet]
        public async Task<List<Album>> Get()
        {
            return await _albumsService.GetAlbums();
        }

        [HttpGet("{id}")]
        public async Task<List<Album>> Get(int id)
        {
            return await _albumsService.GetAlbumsByUserId();
        }
    }
}
