using FluentValidation;
using JobList.Common.Requests;

namespace JobList.Common.Validators
{
    public class CityValidator : AbstractValidator<CityRequest>
    {
        public CityValidator()
        {
            RuleFor(x => x.Id).NotEmpty().WithMessage("Please specify a valid Id.");
            RuleFor(x => x.Name).NotEmpty().MaximumLength(100).WithMessage("Please specify a valid Name.");
            RuleFor(x => x.PhotoMimeType).MaximumLength(5).WithMessage("Please specify a valid Photo Mime Type.");
        }
    }
}
