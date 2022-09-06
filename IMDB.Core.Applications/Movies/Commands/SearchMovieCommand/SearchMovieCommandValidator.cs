using FluentValidation;

namespace IMDB.Core.Applications.Movies.Commands.SearchMovieCommand
{
    public class SearchMovieCommandValidator: AbstractValidator<SearchMovieCommand>
    {
        public SearchMovieCommandValidator()
        {
            RuleFor(v => v.Name).NotEmpty();
        }
    }
}
