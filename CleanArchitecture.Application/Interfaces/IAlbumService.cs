using CleanArchitecture.Domain.Entities;

namespace CleanArchitecture.Application.Interfaces
{
    public interface IAlbumService
    {
        IEnumerable<Albums> RetrieveTopTenAlbums();
    }
}