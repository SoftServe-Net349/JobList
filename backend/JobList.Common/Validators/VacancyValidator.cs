using FluentValidation;
using JobList.Common.Requests;

namespace JobList.Common.Validators
{
    public class VacancyValidator : AbstractValidator<VacancyRequest>
    {
        public VacancyValidator()
        {
            RuleFor(x => x.Name).Length(1, 200).WithMessage("Please specify a valid Name.");
            RuleFor(x => x.Description).NotEmpty().WithMessage("Please specify a valid Description.");
            RuleFor(x => x.Offering).NotEmpty().WithMessage("Please specify a valid Offering.");
            RuleFor(x => x.Requirements).NotEmpty().WithMessage("Please specify a valid Requirements.");
            // RuleFor(x => x.BePlus)
            // RuleFor(x => x.IsChecked)
            // RuleFor(x => x.Salary)
            RuleFor(x => x.FullPartTime).MaximumLength(25).WithMessage("Please specify a valid FullPartTime.");
            RuleFor(x => x.CreateDate).NotEmpty().WithMessage("Please specify a valid Creation Date.");
            RuleFor(x => x.RecruiterId).NotEmpty().WithMessage("Please specify a valid Recruiter Id.");
            RuleFor(x => x.WorkAreaId).NotEmpty().WithMessage("Please specify a valid Work Area Id.");
            RuleFor(x => x.CityId).NotEmpty().WithMessage("Please specify a valid City Id.");
        }
    }
}
