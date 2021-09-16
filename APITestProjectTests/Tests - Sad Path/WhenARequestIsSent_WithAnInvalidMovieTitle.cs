using NUnit.Framework;
using System.Linq;
using APITestProjectTests.MovieIOService;
using System.Threading.Tasks;

namespace APITestProjectTests.Tests___Sad_Path
{
    public class WhenARequestIsSentWithAnInvalidMDBID
    {
        private MovieServices _movieServices;
        [OneTimeSetUp]
        public async Task OneTimeSetup()
        {
            _movieServices = new MovieServices();
            await _movieServices.MakeAMovieRequestAsync("idk");
        }

        [Test]
        public void GivenAnInvalidMovieTitle_ResponseIsFalse()
        {
            Assert.That(_movieServices.MovieResponseDTO.Response.Title, Is.EqualTo(null));
        }

        //[Test]
        //public void GivenAnInvalidMovieTitle_StatusCodeIs404()
        //{
        //    Assert.That(_movieServices.CallManager.StatusCode, Is.EqualTo("404"));
        //}

    }
}