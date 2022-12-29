using CleanArchitecture.Application.Interfaces;
using CleanArchitecture.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace CleanArchitecture.Infrastructure.Database
{
    public class ArtistRepository : IArtistRepository
    {
        private readonly MusicContext _musicDbContext;

        public ArtistRepository(MusicContext musicDbContext)
        {
            _musicDbContext = musicDbContext;
        }

        public async Task<IEnumerable<Artists>> RetrieveMostActiveArtistAsync()
        {
            return await _musicDbContext.Artists.Take(10).ToListAsync();
        }

        public async Task<Artists> InsertArtistAsync(Artists artist)
        {
            _musicDbContext.Artists.Add(artist);
            await _musicDbContext.SaveChangesAsync();

            return artist;
        }


    }
}
