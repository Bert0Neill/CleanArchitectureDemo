using AutoMapper;
using CleanArchitecture.Application.Interfaces;
using CleanArchitecture.Domain.Entities;
using Microsoft.Extensions.Logging;

namespace CleanArchitecture.Application.Services.Database
{
    /// <summary>
    /// The Application service fnx's can make multiple calls to Infrastructure fnx's to complete the task\logic.
    /// </summary>
    public class AlbumService : IAlbumService
    {
        private readonly IAlbumRepository _albumRepository;
        

        public AlbumService(IAlbumRepository albumRepository, ILogger<AlbumService> logger)
        {
            _albumRepository = albumRepository;            
        }

        public async Task<IEnumerable<Albums>> RetrieveTopTenAlbumsAsync()
        {            
            return await _albumRepository.RetrieveTopTenAlbumsAsync();

            // perform (multiple) calls to Infrastructure layer from Application service, to complete the overall task for this service fnx
            // for e.g. log some extra information regarding this task, send an email or make a call out to an external API to start a workflow            
        }

        public async Task<Albums> InsertAlbumAsync(Albums album)
        {
            return await _albumRepository.InsertAlbumAsync(album);
        }

    }
}
