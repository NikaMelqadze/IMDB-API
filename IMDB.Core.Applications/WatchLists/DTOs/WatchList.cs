using IMDB.Core.Applications.Common.CQRS.DTOs;

namespace IMDB.Core.Applications.WatchLists.DTOs
{
    public class WatchList : GetDtoBase<Domains.Entities.WatchList>
    {
        public bool Watched { get; set; }
        public string FilmId { get; set; }
        public string FilmTitle { get; set; }
        public string FilmDescription { get; set; }
        public decimal FilmRating { get; set; }
        public string FilmPoster { get; set; }
    }
}
