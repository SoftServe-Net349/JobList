using FluentValidation;
using JobList.Common.Requests;

namespace JobList.Common.Validators
{
    public class ExperienceValidator : AbstractValidator<ExperienceRequest>
    {
        public ExperienceValidator()
        {
            RuleFor(x => x.CompanyName).Length(1, 200).WithMessage("Please specify a valid Company Name.");
            RuleFor(x => x.Position).Length(1, 200).WithMessage("Please specify a valid Position.");
            RuleFor(x => x.StartDate).NotEmpty().WithMessage("Please specify a valid Start Date.");
            RuleFor(x => x.FinishDate).NotEmpty().WithMessage("Please specify a valid Finish Date.");
            RuleFor(x => x.ResumeId).NotEmpty().WithMessage("Please specify a valid Resume Id.");
        }
    }
}
