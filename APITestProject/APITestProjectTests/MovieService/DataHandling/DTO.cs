using Newtonsoft.Json;

namespace APITestProjectTests.MovieService.DataHandling
{
    public class DTO<ResponseType> where ResponseType : IResponse, new()
    {
        public ResponseType Response { get; set; }
        public void DeserializeResponse(string movieResponse)
        {
            Response = JsonConvert.DeserializeObject<ResponseType>(movieResponse);
        }
    }
}
