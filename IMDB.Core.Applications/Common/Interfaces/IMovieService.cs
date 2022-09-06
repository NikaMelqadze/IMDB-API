using IMDB.Core.Domains.MovieService;
using System.Threading.Tasks;

namespace IMDB.Core.Applications.Common.Interfaces
{
    public interface IMovieService
    {
        public Task<SearchData> SearchAsync(string name);

        public Task<WikipediaData> GetMovieWikipediaDataAsync(string movieId);

        public Task<PosterData> GetMoviePosterDataAsync(string movieId);

        public Task<RatingData> GetMovieRatingDataAsync(string movieId);


    }
}
