using CleanArchitecture.Blazor.Models;

namespace CleanArchitecture.Blazor.Interfaces
{
    public interface IAlbumService
    {
        Task<IEnumerable<AlbumDTO>> GetAlbums();
    }
}