using CleanArchitecture.Application.Interfaces;
using CleanArchitecture.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace CleanArchitecture.Infrastructure.Database
{
    public class AlbumRepository : IAlbumRepository
    {
        private readonly MusicContext _musicDbContext;

        public AlbumRepository(MusicContext musicDbContext)
        {
            _musicDbContext = musicDbContext;
        }

        public async Task<IEnumerable<Albums>> RetrieveTopTenAlbumsAsync()
        {
            return await _musicDbContext.Albums.Take(10).ToListAsync();
        }
    }
}
