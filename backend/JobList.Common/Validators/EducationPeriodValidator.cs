using FluentValidation;
using JobList.Common.Requests;

namespace JobList.Common.Validators
{
    class EducationPeriodValidator : AbstractValidator<EducationPeriodRequest>
    {
        public EducationPeriodValidator()
        {
            RuleFor(x => x.StartDate).NotEmpty().WithMessage("Please specify a valid Start Date.");
            RuleFor(x => x.FinishDate).NotEmpty().WithMessage("Please specify a valid Finish Date.");
            RuleFor(x => x.SchoolId).NotEmpty().WithMessage("Please specify a valid School Id.");
            RuleFor(x => x.ResumeId).NotEmpty().WithMessage("Please specify a valid Resume Id.");
            RuleFor(x => x.FacultyId).NotEmpty().WithMessage("Please specify a valid Faculty Id.");
        }
    }
}
