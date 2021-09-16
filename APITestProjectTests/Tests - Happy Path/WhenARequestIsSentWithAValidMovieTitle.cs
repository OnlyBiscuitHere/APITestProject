using NUnit.Framework;
using System.Linq;
using APITestProjectTests.MovieIOService;
using System.Threading.Tasks;

namespace APITestProjectTests.Tests___Happy_Path
{
    public class WhenARequestIsSentWithAValidMovieTitle
    {
        private MovieServices _movieService;
        [OneTimeSetUp]
        public async Task OneTimeSetup()
        {
            _movieService = new MovieServices();
            await _movieService.MakeAMovieRequestAsync("John Wick");
        }
        [Test]
        public void StatusIs200()
        {
            Assert.That(_movieService.CallManager.StatusCode, Is.EqualTo(200));
        }
        [Test]
        public void CorrectMovieTitleIsReturned()
        {
            Assert.That(_movieService.MovieResponseDTO.Response.Title, Is.EqualTo("John Wick"));
        }
        [Test]
        public void CorrectYearIsReturned()
        {
            Assert.That(_movieService.GetYearOfMovie(), Is.EqualTo("2014"));
        }
        [Test]
        public void CorrectAgeRatingIsReturned()
        {
            Assert.That(_movieService.MovieResponseDTO.Response.Rated, Is.EqualTo("R"));
        }
        [Test]
        public void MovieHas3Reviews()
        {
            Assert.That(_movieService.MovieResponseDTO.Response.Ratings.Length, Is.EqualTo(3));
        }
        [Test]
        public void MovieHasReviewFromRottenTomatoes()
        {
            Assert.That(_movieService.MovieResponseDTO.Response.Ratings.Any(r => r.Source == "Rotten Tomatoes"));
        }
    }
}
