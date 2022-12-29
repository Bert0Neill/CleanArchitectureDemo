using Azure;
using CleanArchitecture.Application.Interfaces;
using CleanArchitecture.Domain.Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CleanArchitecture.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RepositoryController : ControllerBase
    {
        private readonly IAlbumService _albumService;
        private readonly IArtistService _artistService;
        private readonly ILogger<RepositoryController> _logger;

        public RepositoryController(IAlbumService albumService, IArtistService _artistService, ILogger<RepositoryController> logger)
        {
            _albumService = albumService;
            _logger = logger;
            _artistService = _artistService;
        }

        #region Get API Methods
       

        [HttpGet]
        [Route("RetrieveLatestAlbums")]
        public async Task<ActionResult<IEnumerable<Albums>>> RetrieveLatestAlbumsAsync()
        {
            var results = await _albumService.RetrieveTopTenAlbumsAsync();
            return Ok(results); 
        }

        [HttpGet]
        [Route("RetrieveMostActiveArtists")]
        public async Task<ActionResult<IEnumerable<Artists>>> RetrieveMostActiveArtistsAsync()
        {
            var results = await _artistService.RetrieveMostActiveArtistAsync();
            return Ok(results);
        }
        #endregion

        #region Post  API Methods
        [HttpPost]
        [Route("InsertAlbum")]
        public async Task<ActionResult<Albums>> InsertAlbumAsync(Albums album)
        {
            var results = await _albumService.InsertAlbumAsync(album);
            return Ok(results);
        }

        [HttpPost]
        [Route("InsertArtist")]
        public async Task<ActionResult<Artists>> InsertArtistAsync(Artists artist)
        {
            var results = await _artistService.InsertArtistAsync(artist);
            return Ok(results);
        }
        #endregion
    }
}

