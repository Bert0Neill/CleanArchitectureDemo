using AutoMapper;
using CleanArchitecture.Application.Interfaces;
using CleanArchitecture.Domain.Entities;
using Microsoft.Extensions.Logging;
using System.Text.Json;

namespace CleanArchitecture.Application.Services.Database
{
    /// <summary>
    /// The Application service fnx's can make multiple calls to Infrastructure fnx's to complete the task\logic.
    /// </summary>    
    public class AlbumService : IAlbumService
    {
        private readonly IAlbumRepository _albumRepository;
        private readonly ILogger<AlbumService> _logger;


        public AlbumService(IAlbumRepository albumRepository, ILogger<AlbumService> logger)
        {
            _albumRepository = albumRepository;      
            _logger = logger;
        }

        public async Task<IEnumerable<Albums>> RetrieveCommonAlbumsAsync()
        {
            _logger.LogInformation("RetrieveCommonAlbumsAsync");

            // Perform business logic steps in service:
            // 1) Call an external API to start a workflow...
            // 2) Send an email notification...

            return await _albumRepository.RetrieveTopTenAlbumsAsync();
        }

        public async Task<Albums> InsertNewAlbumAsync(Albums album)
        {
            _logger.LogInformation($"InsertNewAlbumAsync - {JsonSerializer.Serialize(album)}");

            return await _albumRepository.InsertAlbumAsync(album);
        }

        public async Task<Albums> UpdateAlbumAsync(Albums album)
        {
            _logger.LogInformation($"UpdateAlbumAsync - {JsonSerializer.Serialize(album)}");

            return await _albumRepository.UpdateAlbumAsync(album);
        }
    }
}
