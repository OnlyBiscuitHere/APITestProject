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
        public async Task MakeRequest(string movie)
        {
            MovieSelected = movie;
            MovieResponse = await CallManager.MakeMovieRequestAsync(movie);
            Json_response = JObject.Parse(MovieResponse);
            MovieResponseDTO.DeserializeResponse(MovieResponse);
        }
    }
}
