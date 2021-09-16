using NUnit.Framework;
using System.Linq;
using APITestProjectTests.MovieIOService;
using System.Threading.Tasks;

namespace APITestProjectTests.Tests___Sad_Path
{
    public class WhenARequestIsSentWithAnInvalidMovieTitle
    {
        private MovieServices _movieServices;
        [OneTimeSetUp]
        public async Task OneTimeSetup()
        {
            _movieServices = new MovieServices();
            await _movieServices.MakeAMovieRequestAsync("idk");
        }

        [Test]
        public void GivenAnInvalidMovieTitle_StatusCodeIsStill200()
        {
            Assert.That(_movieServices.CallManager.StatusCode, Is.EqualTo(200));
        }

        [Test]
        public void GivenAnInvalidMovieTitle_ResponseIsFalse()
        {
            Assert.That(_movieServices.MovieResponseDTO.Response.Response, Is.EqualTo("False"));
        }

        [Test]
        public void GivenAnInvalidMovieTitle_RatingsAreNull()
        {
            Assert.That(_movieServices.MovieResponseDTO.Response.imdbRating, Is.EqualTo(null));
        }
        
        [Test]
        public void GivenAnInvalidMovieTitle_TitleIsNull()
        {
            Assert.That(_movieServices.MovieResponseDTO.Response.Title, Is.EqualTo(null));
        }


        [Test]
        public void GivenAnInvalidMovieTitle_AgeRatingsAreNull()
        {
            Assert.That(_movieServices.MovieResponseDTO.Response.Rated, Is.EqualTo(null));
        }

    }
}
