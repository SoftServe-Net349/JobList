using FluentValidation;
using JobList.Common.Requests;

namespace JobList.Common.Validators
{
    public class LanguageValidator : AbstractValidator<LanguageRequest>
    {
        public LanguageValidator()
        {
            RuleFor(x => x.Id).NotEmpty().WithMessage("Please specify a valid Id.");
            RuleFor(x => x.Name).NotEmpty().Length(1, 50).WithMessage("Please specify a valid Name.");
        }
    }
}
