using CleanArchitecture.Domain.Entities;

namespace CleanArchitecture.Application.Interfaces
{
    public interface IArtistService
    {
        Task<IEnumerable<Artists>> RetrieveMostActiveArtistAsync();
        Task<Artists> InsertArtistAsync(Artists artist);
    }
}