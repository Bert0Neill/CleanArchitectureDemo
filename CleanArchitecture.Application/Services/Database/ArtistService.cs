using CleanArchitecture.Application.Interfaces;
using CleanArchitecture.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CleanArchitecture.Application.Services.Database
{
    public class ArtistService : IArtistService
    {
        private readonly IArtistRepository _artistRepository;

        public ArtistService(IArtistRepository artistRepository)
        {
            _artistRepository = artistRepository;
        }

        public async Task<IEnumerable<Artists>> RetrieveMostActiveArtistAsync()
        {
            return await _artistRepository.RetrieveMostActiveArtistAsync();
        }

        public async Task<Artists> InsertArtistAsync(Artists artist)
        {
            return await _artistRepository.InsertArtistAsync(artist);
        }
    }
}
