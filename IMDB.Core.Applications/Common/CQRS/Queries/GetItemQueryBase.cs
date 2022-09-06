using AutoMapper;
using IMDB.Core.Applications.Common.CQRS;
using IMDB.Core.Applications.Common.CQRS.DTOs;
using IMDB.Core.Applications.Common.Interfaces;
using System.Threading;
using System.Threading.Tasks;

namespace IMDB.Core.Applications.Common.CQRS.Queries
{
    public abstract class GetItemQueryBase<T> : RequestBase, MediatR.IRequest<IResult>
        where T : IGetDtoBase
    {
        public int Id { get; set; }
    }

    public abstract class GetItemQueryHandlerBase<T1, T2> : QueryHandlerBase, MediatR.IRequestHandler<T1, IResult>
        where T1 : GetItemQueryBase<T2>
        where T2 : IGetDtoBase
    {
        public GetItemQueryHandlerBase(IUnitOfWork uow, IMapper mapper) : base(uow, mapper) { }

        public abstract Task<IResult> Handle(T1 request, CancellationToken cancellationToken);
    }
}
