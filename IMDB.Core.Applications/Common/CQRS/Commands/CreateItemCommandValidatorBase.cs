using FluentValidation;
using IMDB.Core.Applications.Common.CQRS.DTOs;

namespace IMDB.Core.Applications.Common.CQRS.Commands
{
    public class CreateItemCommandValidatorBase<T1, T2> : AbstractValidator<T1>
        where T1 : CreateItemCommandBase<T2>
        where T2 : ICreateDtoBase
    {
        public CreateItemCommandValidatorBase()
        {
            CascadeMode = CascadeMode.Stop;
            RuleFor(v => v.Item)
                .NotNull();
        }
    }
}
