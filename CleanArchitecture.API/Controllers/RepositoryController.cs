using AutoMapper;
using CleanArchitecture.API.DTOs;
using CleanArchitecture.Application.Interfaces;
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
        private readonly IMapper _mapper;

        public RepositoryController(IAlbumService albumService, IArtistService artistService, IMapper mapper, ILogger<RepositoryController> logger)
        {
            _albumService = albumService;
            _logger = logger;
            _artistService = artistService;
            _mapper = mapper;
        }

        #region Get API Methods       
        [HttpGet]
        [Route("RetrieveLatestAlbumsAsync")]
        public async Task<ActionResult<IEnumerable<AlbumDTO>>> RetrieveLatestAlbumsAsync()
        {
            var results = await _albumService.RetrieveTopTenAlbumsAsync();

            var AlbumDto = _mapper.Map<IEnumerable<AlbumDTO>>(results);
            

            return Ok(AlbumDto); 
        }

        [HttpGet]
        [Route("RetrieveMostActiveArtistsAsync")]
        public async Task<ActionResult<IEnumerable<ArtistDTO>>> RetrieveMostActiveArtistsAsync()
        {
            var results = await _artistService.RetrieveMostActiveArtistAsync();
            return Ok(results);
        }
        #endregion

        #region Post  API Methods
        [HttpPost]
        [Route("InsertAlbumAsync")]
        public async Task<ActionResult<AlbumDTO>> InsertAlbumAsync([FromBody] AlbumDTO album)
        {
            //var results = await _albumService.InsertAlbumAsync(album);
            //return Ok(results);
            return Ok(Enumerable.Empty<AlbumDTO>());
        }

        [HttpPost]
        [Route("InsertArtistAsync")]
        public async Task<ActionResult<ArtistDTO>> InsertArtistAsync([FromBody] ArtistDTO artist)
        {
            //var results = await _artistService.InsertArtistAsync(artist);
            //return Ok(results);
            return Ok(Enumerable.Empty<ArtistDTO>());
        }
        #endregion

        #region Put  API Methods
        [HttpPut]
        [Route("UpdateAlbumAsync")]
        public async Task<ActionResult<AlbumDTO>> UpdateAlbumAsync([FromBody] AlbumDTO album)
        {
            //var results = await _albumService.InsertAlbumAsync(album);
            //return Ok(results);
            return Ok(Enumerable.Empty<AlbumDTO>());
        }
        #endregion
    }
}

