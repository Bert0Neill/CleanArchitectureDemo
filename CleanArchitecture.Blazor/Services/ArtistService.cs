using static CleanArchitecture.Blazor.Services.AlbumService;
using System.Net.Http.Json;
using CleanArchitecture.Blazor.Models;
using CleanArchitecture.Blazor.Interfaces;

namespace CleanArchitecture.Blazor.Services
{
    public class ArtistService : IArtistService
    {

        private readonly HttpClient _httpClient;

        public ArtistService(HttpClient httpClient)
        {
            this._httpClient = httpClient;
        }

        public async Task<IEnumerable<ArtistDTO>> GetAlbums()
        {
            return await _httpClient.GetFromJsonAsync<IEnumerable<ArtistDTO>>("api/RetrieveMostActiveArtistsAsync");
        }
    }

}
