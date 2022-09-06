using AutoMapper;
using IMDB.Core.Applications.Common.Interfaces;

namespace IMDB.Core.Applications.Common.CQRS.Queries
{
    public abstract class QueryHandlerBase
    {
        protected readonly IUnitOfWork _uow;
        protected readonly IMapper _mapper;

        public QueryHandlerBase(IUnitOfWork uow, IMapper mapper)
        {
            _uow = uow;
            _mapper = mapper;
        }
    }
}
