using IMDB.Core.Applications.Common.CQRS.Commands;
using FluentValidation;

namespace IMDB.Core.Applications.WatchLists.Commands.CreateWatchListCommand
{    
    public class CreateWatchedListCommandValidator :
         CreateItemCommandValidatorBase<CreateWatchListCommand, DTOs.CreateWatchListDto>
    {
        public CreateWatchedListCommandValidator() : base()
        {
            When(v => v.Item != null, () =>
            {
                RuleFor(v => v.Item.MovieId).NotEmpty();
                RuleFor(v => v.Item.UserId).NotNull();
            });
        }
    }


}
