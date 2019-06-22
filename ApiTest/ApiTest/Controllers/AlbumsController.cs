using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Models;
using Services.Albums;

namespace ApiTest.Controllers
{
    [Route("api/albums")]
    [ApiController]
    public class AlbumsController : ControllerBase
    {
        private readonly IAlbumsService _albumsService;

        public AlbumsController(IAlbumsService albumsService)
        {
            _albumsService = albumsService;
        }

        [HttpGet]
        public async Task<List<Album>> Get(int userId)
        {
            if (userId == 0)
                return await _albumsService.GetAlbums();
            else
                return await _albumsService.GetAlbumsByUserId(userId);
        }
    }
}
