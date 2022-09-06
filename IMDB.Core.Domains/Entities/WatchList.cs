using IMDB.Core.Domains.Common;
using System.Collections.Generic;

namespace IMDB.Core.Domains.Entities
{
    public class WatchList : BaseEntity
    {
        public WatchList()
        {
            OfferHistories = new HashSet<OfferHistory>();
        }

        public ICollection<OfferHistory> OfferHistories { get; set; }
        public int UserId { get; set; }
        public bool Watched { get; set; }
        public string FilmId { get; set; }
        public string FilmTitle { get; set; }

        public string FilmDescription { get; set; }
        public decimal FilmRating { get; set; }

        public string FilmPoster { get; set; }

    }
}
