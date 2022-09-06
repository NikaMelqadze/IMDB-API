
namespace IMDB.Core.Applications.Common.CQRS.DTOs
{
    public class Paging
    {
        public Paging(int take, int skip)
        {
            Take = take;
            Skip = skip;
        }
        public int Take { get; set; }
        public int Skip { get; set; }
    }
}
