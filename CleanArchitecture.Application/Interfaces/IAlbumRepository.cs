using CleanArchitecture.Domain.Entities;

namespace CleanArchitecture.Application.Interfaces
{
    public interface IAlbumRepository
    {
        IEnumerable<Albums> RetrieveTopTenAlbumns();
    }
}