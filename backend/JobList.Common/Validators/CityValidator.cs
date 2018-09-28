using FluentValidation;
using JobList.Common.Requests;

namespace JobList.Common.Validators
{
    public class CityValidator : AbstractValidator<CityRequest>
    {
        public CityValidator()
        {
            RuleFor(x => x.Name).NotEmpty().WithMessage("Please specify a valid Name.");
        }
    }
}
