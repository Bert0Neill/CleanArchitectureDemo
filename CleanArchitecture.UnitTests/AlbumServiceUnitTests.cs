using Bogus;
using CleanArchitecture.Application.Interfaces;
using CleanArchitecture.Application.Services.Database;
using CleanArchitecture.Domain.Entities;
using Microsoft.Extensions.Logging;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace CleanArchitecture.UnitTests
{
    [TestClass]
    public class AlbumServiceUnitTests
    {
        private IAlbumService albumService;
        private Faker<Albums> albumsMock;
        private Faker<Artists> artistMock;
        private Faker<Genres> genreMock;

        /*
         * Mock out the Infrastructure DB Interfaces with Bogas data
         */
        [TestInitialize()]
        public void Initialize() {
            //Arrange
            //Set Id to 0 that will be increased on every iteration by faker object id rule
            int albumID = 0;
            int artistID = 0;
            int genreID = 0;

            this.albumsMock = new Faker<Albums>();
            this.artistMock = new Faker<Artists>();
            this.genreMock = new Faker<Genres>();

        //Initialize the mock class and test employees class object
        var albumRepositoryMock = new Mock<IAlbumRepository>();           
            Mock <ILogger<AlbumService>> logger = new Mock<ILogger<AlbumService>>(); // mock injected logger

            //This contains the rules for generating the fake data.            
            artistMock
                .RuleFor(x => x.ArtistId, ++artistID)
                .RuleFor(x => x.ArtistName, f => f.Person.LastName)
                .RuleFor(x => x.ActiveFrom, f => f.Date.Past(10));

            genreMock
              .RuleFor(x => x.GenreId, ++genreID)
              .RuleFor(x => x.Genre, f => f.Person.FirstName);
              
            albumsMock
                .RuleFor(x => x.AlbumId, ++albumID)
                .RuleFor(x => x.AlbumName, f => f.Person.FullName)
                .RuleFor(x => x.ArtistId, artistID)
                .RuleFor(x => x.GenreId, genreID)
                .RuleFor(x => x.ReleaseDate, f => f.Date.Past(10))
                .RuleFor(x => x.Genre, genreMock)
                .RuleFor(x => x.Artist, artistMock);

            //this will set the mock method with response generated from Bogus library
            var mockData = albumsMock.GenerateBetween(1, 20).AsEnumerable<Albums>;

            // mock db repository methods
            albumRepositoryMock.Setup(c => c.RetrieveTopTenAlbumsAsync()).ReturnsAsync(mockData);
            albumRepositoryMock.Setup(c => c.UpdateAlbumAsync(It.IsAny<Albums>())).ReturnsAsync(albumsMock);
            albumRepositoryMock.Setup(c => c.InsertAlbumAsync(It.IsAny<Albums>())).ReturnsAsync(albumsMock);

            //This will assign the mock data access object to business logic constructor
            albumService = new AlbumService(albumRepositoryMock.Object, logger.Object);
        }

        [TestCleanup()]
        public void Cleanup() { }

        [TestMethod]
        public void RetrieveCommonAlbumsAsync_ListOfAlbumsReturned()
        {
            //Act
            var actual = albumService.RetrieveCommonAlbumsAsync();

            //Asset
            Assert.IsNotNull(actual);
            Assert.IsTrue(actual.Result.AsEnumerable().Count() > 0);            
        }

        [TestMethod]
        public void InsertNewAlbumAsync_NewAlbumIsInserted()
        {
            //Act            
            var updatedAlbum = albumService.InsertNewAlbumAsync(albumsMock);

            //Asset
            Assert.IsNotNull(updatedAlbum);
            Assert.AreEqual(updatedAlbum.Result.AlbumId, 1);
            Assert.IsNotNull(updatedAlbum.Result.AlbumName);
        }


        [TestMethod]
        public void UpdateAlbumAsync_ExistingAlbumIsUpdated()
        {
            //Act            
            var updatedAlbum = albumService.UpdateAlbumAsync(albumsMock);

            //Asset
            Assert.IsNotNull(updatedAlbum);            
            Assert.AreEqual(updatedAlbum.Result.AlbumId , 1);
            Assert.IsNotNull(updatedAlbum.Result.AlbumName);
        }
    }
}