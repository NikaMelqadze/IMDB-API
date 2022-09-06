using FluentValidation;
using IMDB.Core.Applications.Common.CQRS.DTOs;

namespace IMDB.Core.Applications.Common.CQRS.Commands
{
    public class UpdateItemCommandValidatorBase<T1, T2> : AbstractValidator<T1>
        where T1 : UpdateItemCommandBase<T2>
        where T2 : IChangeDtoBase
    {
        public UpdateItemCommandValidatorBase()
        {
            RuleFor(v => v.Item)
                .NotNull();
            When(v => v.Item != null, () =>
            {
                RuleFor(v => v.Item.Id)
                    .NotEmpty();
            });
        }
    }
}
