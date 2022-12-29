using CleanArchitecture.Domain.Entities;

namespace CleanArchitecture.Application.Interfaces
{
    public interface IArtistRepository
    {
        Task<Artists> InsertArtistAsync(Artists artist);
        Task<IEnumerable<Artists>> RetrieveMostActiveArtistAsync();
    }
}