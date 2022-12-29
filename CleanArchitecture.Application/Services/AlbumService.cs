using CleanArchitecture.Application.Interfaces;
using CleanArchitecture.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CleanArchitecture.Application.Services
{
    public class AlbumService : IAlbumService
    {
        private readonly IAlbumRepository _albumRepository;

        public AlbumService(IAlbumRepository albumRepository)
        {
            _albumRepository = albumRepository;
        }

        public async Task<IEnumerable<Albums>> RetrieveTopTenAlbumsAsync()
        {
            return await _albumRepository.RetrieveTopTenAlbumsAsync();
        }

        public async Task<IEnumerable<Artists>> RetrieveMostActiveArtistAsync()
        {
            return await _albumRepository.RetrieveMostActiveArtistAsync();
        }

        public async Task<Albums> InsertAlbumAsync(Albums album)
        {
            return await _albumRepository.InsertAlbumAsync(album);
        }

        public async Task<Artists> InsertArtistAsync(Artists artist)
        {
            return await _albumRepository.InsertArtistAsync(artist);
        }


    }
}
