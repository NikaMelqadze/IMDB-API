using AutoMapper;
using IMDB.Core.Applications.Common.Interfaces;

namespace IMDB.Core.Applications.Common.CQRS.Commands
{
    public abstract class CommandHandlerBase
    {
        protected readonly IUnitOfWork _uow;
        protected readonly IMapper _mapper;

        public CommandHandlerBase(IUnitOfWork uow, IMapper mapper)
        {
            _uow = uow;
            _mapper = mapper;
        }
    }
}
