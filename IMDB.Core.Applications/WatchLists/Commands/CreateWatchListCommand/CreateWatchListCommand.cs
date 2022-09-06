using AutoMapper;
using IMDB.Core.Applications.Common.CQRS.Commands;
using IMDB.Core.Applications.Common.CQRS.DTOs;
using IMDB.Core.Applications.Common.Interfaces;
using IMDB.Core.Applications.WatchLists.DTOs;
using System.ComponentModel.DataAnnotations;
using System.Globalization;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace IMDB.Core.Applications.WatchLists.Commands.CreateWatchListCommand
{
    public class CreateWatchListCommand : CreateItemCommandBase<CreateWatchListDto>
    {
        
    }

    public class CreateWatchedListCommandHandler : CreateItemCommandHandlerBase<CreateWatchListCommand, CreateWatchListDto>
    {
        protected readonly IMovieService _context;

        public CreateWatchedListCommandHandler(IMovieService context, IUnitOfWork uow, IMapper mapper)
            : base(uow, mapper)
        {

            _context = context;
        }

        public override async Task<IResult> Handle(CreateWatchListCommand request, CancellationToken cancellationToken)
        {
            Validate(request.Item);

            var entity = new Domains.Entities.WatchList();

            entity.UserId = request.Item.UserId;
            entity.Watched = false;
            entity.FilmId = request.Item.MovieId;

            var wikiData = await _context.GetMovieWikipediaDataAsync(request.Item.MovieId);
            var posterData = await _context.GetMoviePosterDataAsync(request.Item.MovieId);
            var ratingData = await _context.GetMovieRatingDataAsync(request.Item.MovieId);

            entity.FilmTitle = ratingData.Title;
            entity.FilmDescription = wikiData.PlotShort.PlainText;
            entity.FilmRating = decimal.Parse(ratingData.IMDb, new NumberFormatInfo { NumberDecimalSeparator = "." });
            entity.FilmPoster = posterData.Posters.Any() ? posterData.Posters.First().Link : null;

            await _uow.WatchListsRepo.AddEntityItem(entity);

            await _uow.SaveChangesAsync(cancellationToken);

            return new Result<int>(entity.Id);
        }

        protected void Validate(CreateWatchListDto item)
        {
            if (_uow.WatchListsRepo.CheckDublicates(item))
            {
                throw new ValidationException("ITEM_EXISTS");
            }
        }
    }
}