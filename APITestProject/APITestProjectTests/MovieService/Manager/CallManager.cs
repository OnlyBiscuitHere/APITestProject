using System.Threading.Tasks;
using Newtonsoft.Json.Linq;
using RestSharp;

namespace APITestProjectTests.MovieService.Manager
{
    public class CallManager
    {
        private readonly IRestClient _client;
        public int StatusCode { get; set; }
        public CallManager()
        {
            _client = new RestClient(AppConfigReader.BaseUrl);
        }
        public async Task<string> MakeMovieRequestAsync(string movie)
        {
            var request = new RestRequest();
            request.AddHeader("Content-Type", "application/json");
            SpaceChecker(movie);
            request.Resource = $"?t={movie}&apikey=6d25abe0";
            IRestResponse response = await _client.ExecuteAsync(request);
            StatusCode = (int)response.StatusCode;
            return response.Content;
        }
        public void SpaceChecker(string movie)
        {
            if (movie.Contains(" "))
            {
                movie.Replace(' ', '+');
            }
        }
    }
}
