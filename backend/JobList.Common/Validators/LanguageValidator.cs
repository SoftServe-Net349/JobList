using FluentValidation;
using JobList.Common.Requests;

namespace JobList.Common.Validators
{
    public class LanguageValidator : AbstractValidator<LanguageRequest>
    {
        public LanguageValidator()
        {
            RuleFor(x => x.Name).Length(1, 50).WithMessage("Please specify a valid Name.");
        }
    }
}
