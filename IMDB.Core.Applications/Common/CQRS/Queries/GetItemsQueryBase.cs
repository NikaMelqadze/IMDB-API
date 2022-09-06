using AutoMapper;
using IMDB.Core.Applications.Common.CQRS.DTOs;
using IMDB.Core.Applications.Common.Interfaces;
using System.Threading;
using System.Threading.Tasks;

namespace IMDB.Core.Applications.Common.CQRS.Queries
{
    public abstract class GetItemsQueryBase<T> : RequestBase, MediatR.IRequest<IResult>  //MediatR.IRequest<System.Collections.Generic.List<T>> 
        where T : IGetDtoBase
    {
    }

    public abstract class GetItemsQueryHandlerBase<T1, T2> : QueryHandlerBase, MediatR.IRequestHandler<T1, IResult>
        where T1 : GetItemsQueryBase<T2>
        where T2 : IGetDtoBase
    {
        public GetItemsQueryHandlerBase(IUnitOfWork uow, IMapper mapper) : base(uow, mapper) { }

        public abstract Task<IResult> Handle(T1 request, CancellationToken cancellationToken);
    }
}
