using System.Collections.Generic;

namespace IMDB.Core.Applications.Common.CQRS.DTOs
{
    public class PagedResult<T> where T : class
    {
        public IEnumerable<T> Items { get; set; }
        public int ItemsTotalCount { get; set; }
    }
}
