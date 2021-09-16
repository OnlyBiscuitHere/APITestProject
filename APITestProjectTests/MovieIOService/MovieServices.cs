using System.Threading.Tasks;
using APITestProjectTests.MovieService.DataHandling;
using APITestProjectTests.MovieService.HTTPManager;
using Newtonsoft.Json.Linq;

namespace APITestProjectTests.MovieIOService
{
    public class MovieServices
    {
        public CallManager CallManager { get; set; }
        public JObject Json_response { get; set; }
        public DTO<MovieResponse> MovieResponseDTO { get; set; }
        public string MovieSelected { get; set; }
        public string MovieResponse { get; set; }
        public MovieServices()
        {
            CallManager = new CallManager();
            MovieResponseDTO = new DTO<MovieResponse>();
        }
        public async Task MakeAMovieRequestAsync(string movie)
        {
            MovieSelected = movie;
            MovieResponse = await CallManager.MakeMovieRequestByTitleAsync(movie);
            Json_response = JObject.Parse(MovieResponse);
            MovieResponseDTO.DeserializeResponse(MovieResponse);
        }
        public async Task MakeAIMDBRequestAsync(string imdb)
        {
            MovieSelected = imdb;
            MovieResponse = await CallManager.MakeMovieRequestByIDAsync(imdb);
            Json_response = JObject.Parse(MovieResponse);
            MovieResponseDTO.DeserializeResponse(MovieResponse);
        }
        public string GetYearOfMovie()
        {
            return MovieResponseDTO.Response.Year;
        }
        public bool RottenTomatoReviewed()
        {
            foreach (var review in MovieResponseDTO.Response.Ratings)
            {
                if (review.Source == "Rotten Tomatoes")
                {
                    return true;
                }
            }
            return false;
        }
        public bool IsActorInMovie(string actorName)
        {
            return MovieResponse.Contains(actorName);
        }

        public bool HasMovieReceivedAwards()
        {
            return (MovieResponseDTO.Response.Awards != "N/A"); /*? true : false;*/
        }
    }
}
