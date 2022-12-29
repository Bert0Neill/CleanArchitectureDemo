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
        private readonly IAlbumService _service;
        private readonly ILogger<RepositoryController> _logger;

        public RepositoryController(IAlbumService service, ILogger<RepositoryController> logger)
        {
            _service = service;
            _logger = logger;
        }

        #region Get API Methods
       

        [HttpGet]
        [Route("RetrieveLatestAlbums")]
        public async Task<ActionResult<IEnumerable<Albums>>> RetrieveLatestAlbumsAsync()
        {
            var results = await _service.RetrieveTopTenAlbumsAsync();
            return Ok(results); 
        }

        [HttpGet]
        [Route("RetrieveMostActiveArtists")]
        public async Task<ActionResult<IEnumerable<Artists>>> RetrieveMostActiveArtistsAsync()
        {
            var results = await _service.RetrieveMostActiveArtistAsync();
            return Ok(results);
        }
        #endregion

        #region Post  API Methods
        [HttpPost]
        [Route("InsertAlbum")]
        public async Task<ActionResult<Albums>> InsertAlbumAsync(Albums album)
        {
            var results = await _service.InsertAlbumAsync(album);
            return Ok(results);
        }

        [HttpPost]
        [Route("InsertArtist")]
        public async Task<ActionResult<Artists>> InsertArtistAsync(Artists artist)
        {
            var results = await _service.InsertArtistAsync(artist);
            return Ok(results);
        }
        #endregion
    }
}

