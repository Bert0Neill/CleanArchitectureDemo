using CleanArchitecture.Application.Interfaces;
using CleanArchitecture.Application.Services.Database;
using CleanArchitecture.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using System.Text.Json;

namespace CleanArchitecture.Infrastructure.Database
{
    public class AlbumRepository : IAlbumRepository
    {
        private readonly MusicContext _musicDbContext;
        private readonly ILogger<AlbumRepository> _logger;

        public AlbumRepository(MusicContext musicDbContext, ILogger<AlbumRepository> logger)
        {
            _musicDbContext = musicDbContext;
            _logger = logger;

            _logger.LogInformation($"AlbumRepository ctor");
        }

        public async Task<IEnumerable<Albums>> RetrieveTopTenAlbumsAsync()
        {
            _logger.LogInformation($"RetrieveTopTenAlbumsAsync");

            return await _musicDbContext.Albums.Take(10).ToListAsync();
        }

        public async Task<IEnumerable<Artists>> RetrieveMostActiveArtistAsync()
        {
            _logger.LogInformation($"RetrieveMostActiveArtistAsync");

            return await _musicDbContext.Artists.Take(10).ToListAsync();
        }

        public async Task<Albums> InsertAlbumAsync(Albums album)
        {
            _logger.LogInformation($"InsertAlbumAsync - {JsonSerializer.Serialize(album)}");

            _musicDbContext.Albums.Add(album);
            await _musicDbContext.SaveChangesAsync();

            return album;
        }

        public async Task<Albums> UpdateAlbumAsync(Albums album)
        {
            _logger.LogInformation($"UpdateAlbumAsync - {JsonSerializer.Serialize(album)}");

            _musicDbContext.Update(album);
            await _musicDbContext.SaveChangesAsync();
            
            return album;
        }
    }
}
