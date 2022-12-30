using Ardalis.GuardClauses;
using AutoMapper;
using CleanArchitecture.API.DTOs;
using CleanArchitecture.Application.Interfaces;
using CleanArchitecture.Domain.Entities;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Text.Json;

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
            //guard clauses
            _albumService = Guard.Against.Null(albumService, nameof(albumService));
            _mapper = Guard.Against.Null(mapper, nameof(mapper));
            _logger = Guard.Against.Null(logger, nameof(logger));
            _artistService = Guard.Against.Null(artistService, nameof(artistService));

            _logger.LogInformation($"RepositoryController ctor");
        }

        #region Get API Methods              
        [HttpGet]
        [Route("RetrieveLatestAlbumsAsync")]
        public async Task<ActionResult<IEnumerable<AlbumDTO>>> RetrieveLatestAlbumsAsync()
        {
            _logger.LogInformation($"RetrieveLatestAlbumsAsync");

            var results = await _albumService.RetrieveCommonAlbumsAsync();
            var AlbumDto = _mapper.Map<IEnumerable<AlbumDTO>>(results);
            return Ok(AlbumDto); 
        }
        
        [HttpGet]
        [Route("RetrieveMostActiveArtistsAsync")]
        public async Task<ActionResult<IEnumerable<ArtistDTO>>> RetrieveMostActiveArtistsAsync()
        {
            _logger.LogInformation($"RetrieveMostActiveArtistsAsync");

            var results = await _artistService.RetrieveMostActiveArtistAsync();
            return Ok(results);
        }
        #endregion

        #region Post  API Methods        
        [HttpPost]
        [Route("InsertAlbumAsync")]
        public async Task<ActionResult<AlbumDTO>> InsertAlbumAsync([FromBody] AlbumDTO album)
        {
            _logger.LogInformation($"InsertAlbumAsync - {JsonSerializer.Serialize(album)}");

            var newAlbum = _mapper.Map<Albums>(album);
            var results = await _albumService.InsertNewAlbumAsync(newAlbum);
            return Ok(results);
        }
        
        [HttpPost]
        [Route("InsertArtistAsync")]
        public async Task<ActionResult<ArtistDTO>> InsertArtistAsync([FromBody] ArtistDTO artist)
        {
            _logger.LogInformation($"InsertArtistAsync - {JsonSerializer.Serialize(artist)}");

            var newArtist = _mapper.Map<Artists>(artist);
            var results = await _artistService.InsertArtistAsync(newArtist);
            return Ok(results);
        }
        #endregion

        #region Put  API Methods        
        [HttpPut]
        [Route("UpdateAlbumAsync")]
        public async Task<ActionResult<AlbumDTO>> UpdateAlbumAsync([FromBody] AlbumDTO album)
        {
            _logger.LogInformation($"UpdateAlbumAsync - {JsonSerializer.Serialize(album)}");

            var newAlbum = _mapper.Map<Albums>(album);
            var results = await _albumService.UpdateAlbumAsync(newAlbum);
            return Ok(results);
        }
        #endregion
    }
}

