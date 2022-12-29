using CleanArchitecture.Domain.Entities;

namespace CleanArchitecture.Application.Interfaces
{
    public interface IAlbumService
    {
        Task <IEnumerable<Albums>> RetrieveTopTenAlbumsAsync();
        Task<IEnumerable<Artists>> RetrieveMostActiveArtistAsync();
        Task<Albums> InsertAlbumAsync(Albums album);
        Task<Artists> InsertArtistAsync(Artists artist);
    }
}