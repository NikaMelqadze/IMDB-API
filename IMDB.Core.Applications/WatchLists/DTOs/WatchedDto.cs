using IMDB.Core.Applications.Common.CQRS.DTOs;


namespace IMDB.Core.Applications.WatchLists.DTOs
{
    public class WatchedDto : ChangeDtoBase<Domains.Entities.WatchList>
    {
        public int Id { get; set; }
        public int UserId { get; set; }
        public string FilmId { get; set; }

    }
}
