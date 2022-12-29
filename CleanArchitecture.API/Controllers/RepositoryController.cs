using CleanArchitecture.Application.Interfaces;
using CleanArchitecture.Domain.Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CleanArchitecture.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RepositoryController : ControllerBase
    {
        private readonly IAlbumService _service;
        private readonly ILogger<RepositoryController> _logger;

        public RepositoryController(IAlbumService service, ILogger<RepositoryController> logger)
        {
            _service = service;
            _logger = logger;
        }

        #region Get API Methods
       

        [HttpGet]
        [Route("RetrieveLatestAlbums")]
        public IEnumerable<Albums> RetrieveLatestAlbums()
        {
            return _service.RetrieveTopTenAlbums().ToList();            
        }

        [HttpGet]
        [Route("RetrieveMostActiveArtists")]
        public IEnumerable<Albums> RetrieveMostActiveArtists()
        {
            return _service.RetrieveTopTenAlbums().ToList();
        }
        #endregion

        #region Post  API Methods
        //[HttpPost]
        //[Route("InsertAlbum")]
        //public WeatherForecast InsertAlbum()
        //{
        //    //return Enumerable.Range(1, 5).Select(index => new WeatherForecast
        //    //{
        //    //    Date = DateTime.Now.AddDays(index),
        //    //    TemperatureC = Random.Shared.Next(-20, 55),
        //    //    Summary = Summaries[Random.Shared.Next(Summaries.Length)]
        //    //})
        //    //.ToArray();
        //}

        //[HttpPost]
        //[Route("InsertArtist")]
        //public WeatherForecast InsertArtist()
        //{
        //    //return Enumerable.Range(1, 5).Select(index => new WeatherForecast
        //    //{
        //    //    Date = DateTime.Now.AddDays(index),
        //    //    TemperatureC = Random.Shared.Next(-20, 55),
        //    //    Summary = Summaries[Random.Shared.Next(Summaries.Length)]
        //    //})
        //    //.ToArray();
        //}
        #endregion
    }
}

