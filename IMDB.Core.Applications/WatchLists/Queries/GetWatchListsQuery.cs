using AutoMapper;
using IMDB.Core.Applications.Common.CQRS.DTOs;
using IMDB.Core.Applications.Common.CQRS.Queries;
using IMDB.Core.Applications.Common.Interfaces;
using IMDB.Core.Applications.WatchLists.DTOs;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace IMDB.Core.Applications.Persons.Queries
{
    public class GetWatchListsQuery : GetItemsQueryBase<WatchList>
    {
        public WatchListFilter Filter { get; set; }
    }

    public class GetPersonsQueryHandler : GetItemsQueryHandlerBase<GetWatchListsQuery, WatchList>
    {
        public GetPersonsQueryHandler(IUnitOfWork uow, IMapper mapper) : base(uow, mapper) { }

        public override async Task<IResult> Handle(GetWatchListsQuery request, CancellationToken cancellationToken)
        {
            var data = await _uow.WatchListsRepo.WatchListsAsync(request.Filter, cancellationToken);
            return new Result<List<WatchList>>(data);
        }
    }


}
