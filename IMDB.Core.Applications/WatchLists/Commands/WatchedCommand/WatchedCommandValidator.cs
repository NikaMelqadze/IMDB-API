using IMDB.Core.Applications.Common.CQRS.Commands;
using FluentValidation;

namespace IMDB.Core.Applications.WatchLists.Commands.WatchedCommand
{
    public class WatchedCommandValidator :
         UpdateItemCommandValidatorBase<WatchedCommand, DTOs.WatchedDto>
    {
        public WatchedCommandValidator() : base()
        {
            When(v => v.Item != null, () =>
            {
                RuleFor(v => v.Item.FilmId).NotEmpty();
                RuleFor(v => v.Item.UserId).NotNull();
            });
        }
    }



}
