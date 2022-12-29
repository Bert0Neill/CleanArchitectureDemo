using CleanArchitecture.Domain.Entities;

namespace CleanArchitecture.Application.Interfaces
{
    public interface IAlbumRepository
    {
        Task<Albums> InsertAlbumAsync(Albums album);
        Task<IEnumerable<Albums>> RetrieveTopTenAlbumsAsync();        
    }
}