using static CleanArchitecture.Blazor.Services.AlbumService;
using System.Net.Http.Json;
using CleanArchitecture.Blazor.Models;
using CleanArchitecture.Blazor.Interfaces;

namespace CleanArchitecture.Blazor.Services
{
    public class AlbumService : IAlbumService
    {

        private readonly HttpClient _httpClient;

        public AlbumService(HttpClient httpClient)
        {
            this._httpClient = httpClient;
        }

        public async Task<IEnumerable<AlbumDTO>> GetAlbums()
        {        
            return await _httpClient.GetFromJsonAsync<IEnumerable<AlbumDTO>>("api/Repository/RetrieveLatestAlbumsAsync");
        }
    }

}
