using IMDB.Core.Applications.Common.Interfaces;
using IMDB.Core.Domains.MovieService;
using IMDB.Infrastructure.ServiceOptions;
using Microsoft.Extensions.Options;
using Newtonsoft.Json;
using System.Net.Http;
using System.Threading.Tasks;

namespace IMDB.Infrastructure.Services
{
    public class IMDBService : IMovieService
    {
        private readonly MovieServiceDataOptions _serviceOptions;
        private static readonly HttpClient client = new HttpClient();

        public IMDBService(IOptions<MovieServiceDataOptions> serviceOptions)
        {
            _serviceOptions = serviceOptions.Value;
        }

        public async Task<SearchData> SearchAsync(string name)
        {
            var responseString = await client.GetStringAsync(GenerateServiceUrl("Search",name));
            var jsonData = JsonConvert.DeserializeObject<SearchData>(responseString);
            return jsonData;
        }

        public async Task<WikipediaData> GetMovieWikipediaDataAsync(string movieId)
        {
            var responseString = await client.GetStringAsync(GenerateServiceUrl("Wikipedia", movieId));
            var jsonData = JsonConvert.DeserializeObject<WikipediaData>(responseString);
            return jsonData;
        }

        public async Task<PosterData> GetMoviePosterDataAsync(string movieId)
        {
            var responseString = await client.GetStringAsync(GenerateServiceUrl("Posters", movieId));
            var jsonData = JsonConvert.DeserializeObject<PosterData>(responseString);
            return jsonData;
        }

        public async Task<RatingData> GetMovieRatingDataAsync(string movieId)
        {
            var responseString = await client.GetStringAsync(GenerateServiceUrl("Ratings", movieId));
            var jsonData = JsonConvert.DeserializeObject<RatingData>(responseString);
            return jsonData;
        }

        private string GenerateServiceUrl(string serviceName, string param)
        {
            return string.Format("{0}{1}/{2}/{3}", _serviceOptions.ApiUrl, serviceName, _serviceOptions.ApiKey, param);
        }

    }
}
