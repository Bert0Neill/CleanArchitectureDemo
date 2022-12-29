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

        public async Task<IEnumerable<Artists>> RetrieveMostActiveArtistAsync()
        {
            return await _musicDbContext.Artists.Take(10).ToListAsync();
        }

        public async Task<Albums> InsertAlbumAsync(Albums album)
        {
            _musicDbContext.Albums.Add(album);
            await _musicDbContext.SaveChangesAsync();

            return album;
        }


        public async Task<Artists> InsertArtistAsync(Artists artist)
        {
            _musicDbContext.Artists.Add(artist);
            await _musicDbContext.SaveChangesAsync();

            return artist;
        }


    }
}
