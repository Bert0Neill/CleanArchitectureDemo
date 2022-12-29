using CleanArchitecture.Domain.Entities;

namespace CleanArchitecture.Application.Interfaces
{
    public interface IAlbumRepository
    {
        Task<IEnumerable<Albums>> RetrieveTopTenAlbumsAsync();
    }
}