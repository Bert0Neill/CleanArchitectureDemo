using CleanArchitecture.Blazor.Models;

namespace CleanArchitecture.Blazor.Interfaces
{
    public interface IArtistService
    {
        Task<IEnumerable<ArtistDTO>> GetAlbums();
    }
}