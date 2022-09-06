using AutoMapper;
using IMDB.Core.Applications.Common.CQRS.Commands;
using IMDB.Core.Applications.Common.CQRS.DTOs;
using IMDB.Core.Applications.Common.Interfaces;
using System.Threading;
using System.Threading.Tasks;

namespace IMDB.Core.Applications.Common.CQRS.Commands
{
    public abstract class CreateItemCommandBase<T> : RequestBase, MediatR.IRequest<IResult>
       where T : ICreateDtoBase
    {
        public T Item { get; set; }
    }

    public abstract class CreateItemCommandHandlerBase<T1, T2> : CommandHandlerBase, MediatR.IRequestHandler<T1, IResult>
        where T1 : CreateItemCommandBase<T2>
        where T2 : ICreateDtoBase

    {
        public CreateItemCommandHandlerBase(IUnitOfWork uow, IMapper mapper) : base(uow, mapper) { }

        public abstract Task<IResult> Handle(T1 request, CancellationToken cancellationToken);
    }
}
