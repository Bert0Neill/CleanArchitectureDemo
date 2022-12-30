using BenchmarkDotNet.Attributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MeasurePerformances
{
    [MemoryDiagnoser]
    [Orderer(BenchmarkDotNet.Order.SummaryOrderPolicy.FastestToSlowest)]
    [RankColumn]
    public class BenchmarkAPIs
    {
        private static HttpClient _httpClient;

        [GlobalSetup]
        public void GlobalSetup()
        {
            //Write your initialization code here           
        }

        [Benchmark]
        public void RetrieveAlbums()
        {
            //Write your code here

            _httpClient = new HttpClient();
            _httpClient.BaseAddress = new Uri("https://localhost:7074/");

            var response = _httpClient.GetAsync("api/RetrieveLatestAlbumsAsync");            
        }
        [Benchmark]
        public void RetrieveArtists()
        {
            _httpClient = new HttpClient();
            _httpClient.BaseAddress = new Uri("https://localhost:7074/");

            var response = _httpClient.GetAsync("api/RetrieveMostActiveArtistsAsync");            
        }
    }
}
