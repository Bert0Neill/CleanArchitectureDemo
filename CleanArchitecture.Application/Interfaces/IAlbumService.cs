using CleanArchitecture.Domain.Entities;

namespace CleanArchitecture.Application.Interfaces
{
    public interface IAlbumService
    {
        Task <IEnumerable<Albums>> RetrieveTopTenAlbumsAsync();
    }
}