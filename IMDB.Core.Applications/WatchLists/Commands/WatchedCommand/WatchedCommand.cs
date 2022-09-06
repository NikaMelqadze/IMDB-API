using AutoMapper;
using IMDB.Core.Applications.Common.CQRS.Commands;
using IMDB.Core.Applications.Common.CQRS.DTOs;
using IMDB.Core.Applications.Common.Exceptions;
using IMDB.Core.Applications.Common.Interfaces;
using IMDB.Core.Applications.WatchLists.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace IMDB.Core.Applications.WatchLists.Commands.WatchedCommand
{
    public class WatchedCommand : UpdateItemCommandBase<WatchedDto>
    {
    }

    public class WatchedCommandHandler : UpdateItemCommandHandlerBase<WatchedCommand, WatchedDto>
    {
        public WatchedCommandHandler(IUnitOfWork uow, IMapper mapper)
            : base(uow, mapper) { }

        public override async Task<IResult> Handle(WatchedCommand request, CancellationToken cancellationToken)
        {
            var entity = await _uow.WatchListsRepo.GetEntityItem(request.Item.UserId, request.Item.FilmId);
            if (entity == null)
            {
                throw new NotFoundException();
            }

            Validate(entity);

            entity.Watched = true;
            
            await _uow.SaveChangesAsync(cancellationToken);

            return new Result();
        }

        protected void Validate(Domains.Entities.WatchList entity)
        {
            if(entity.Watched) throw new ValidationException("ITEM_ALREADY_ISWATCHED");
        }

    }
}
