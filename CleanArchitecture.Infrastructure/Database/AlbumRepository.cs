using CleanArchitecture.Application.Interfaces;
using CleanArchitecture.Domain.Entities;

namespace CleanArchitecture.Infrastructure.Database
{
    public class AlbumRepository : IAlbumRepository
    {
        private readonly MusicContext _musicDbContext;

        public AlbumRepository(MusicContext musicDbContext)
        {
            _musicDbContext = musicDbContext;
        }

        public IEnumerable<Albums> RetrieveTopTenAlbums()
        {
            return _musicDbContext.Albums.Take(10).ToList();
        }
    }
}
