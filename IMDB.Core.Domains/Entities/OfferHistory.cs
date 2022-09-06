using IMDB.Core.Domains.Common;
using System;

namespace IMDB.Core.Domains.Entities
{
    public class OfferHistory : BaseEntity
    {
        public WatchList WatchList { get; set; }
        public int WatchListId { get; set; }
        public DateTime OfferDate { get; set; }
    }
}
