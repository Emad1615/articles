using FluentValidation;
using Submission.Application.Features.Articles.DTO;

namespace Submission.Application.Features.Articles.Validators
{
    public class BaseArticleValidator<T, DTO> : AbstractValidator<T> where DTO : BaseArticleDTO
    {
        public BaseArticleValidator(Func<T, DTO> selector)
        {
            RuleFor(x => selector(x).Title)
                .NotEmpty().WithMessage("Title is required.")
                .MaximumLength(255).WithMessage("Title must not exceed 255 characters.");
            RuleFor(x => selector(x).Scope)
                .NotEmpty().WithMessage("Scope is required.")
                .MaximumLength(2085).WithMessage("Scope must not exceed 255 characters.");
            RuleFor(x => selector(x).JournalId)
                .GreaterThanOrEqualTo(0).WithMessage("Invalid JournalId.");
        }
    }
}
