using CleanArchitecture.Domain.Entities;

namespace CleanArchitecture.Application.Interfaces
{
    public interface IAlbumRepository
    {
        Task<Albums> InsertAlbumAsync(Albums album);
        Task<IEnumerable<Artists>> RetrieveMostActiveArtistAsync();
        Task<IEnumerable<Albums>> RetrieveTopTenAlbumsAsync();
        Task<Artists> InsertArtistAsync(Artists artist);
    }
}