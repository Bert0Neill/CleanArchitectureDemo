using CleanArchitecture.Domain.Entities;

namespace CleanArchitecture.Application.Interfaces
{
    public interface IAlbumService
    {
        Task <IEnumerable<Albums>> RetrieveCommonAlbumsAsync();        
        Task<Albums> InsertNewAlbumAsync(Albums album);
        Task<Albums> UpdateAlbumAsync(Albums newAlbum);        
    }
}