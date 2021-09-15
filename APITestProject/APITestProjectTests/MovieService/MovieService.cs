using APITestProjectTests.MovieService.DataHandling;
using APITestProjectTests.MovieService.Manager;
using Newtonsoft.Json.Linq;
using System.Threading.Tasks;

namespace APITestProjectTests.MovieService
{
    public class MovieService
    {
        public CallManager callManager { get; set; }
        public JObject Json_response { get; set; }
        public DTO<MovieResponse> MovieResponseDTO { get; set; }
        public string MovieSelected { get; set; }
        public string MovieResponse { get; set; }
        public MovieService()
        {
            callManager = new CallManager();
            MovieResponseDTO = new DTO<MovieResponse>();
        }
        public async Task MakeRequestAsync(string movie)
        {
            MovieSelected = movie;
            MovieResponse = await callManager.MakeMovieRequestAsync(movie);
            Json_response = JObject.Parse(MovieResponse);
            MovieResponseDTO.DeserializeResponse(MovieResponse);
        }
        // Add Extra functionality to make sure things are there, etc.
    }
}
