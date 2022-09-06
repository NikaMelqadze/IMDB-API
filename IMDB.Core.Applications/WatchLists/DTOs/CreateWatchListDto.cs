using IMDB.Core.Applications.Common.CQRS.DTOs;

namespace IMDB.Core.Applications.WatchLists.DTOs
{
    public class CreateWatchListDto : CreateDtoBase<Domains.Entities.WatchList>
    {
        public string MovieId { get; set; }
        public int UserId { get; set; }
    }
}
