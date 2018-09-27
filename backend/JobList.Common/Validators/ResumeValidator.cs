using FluentValidation;
using JobList.Common.Requests;

namespace JobList.Common.Validators
{
    public class ResumeValidator : AbstractValidator<ResumeRequest>
    {
        public ResumeValidator()
        {
            RuleFor(x => x.Id).NotEmpty().WithMessage("Please specify a valid Id.");
            RuleFor(x => x.SoftSkills).NotEmpty().WithMessage("Please specify a valid SoftSkills.");
            RuleFor(x => x.KeySkills).NotEmpty().WithMessage("Please specify a valid SoftSkills.");
            RuleFor(x => x.WorkAreaId).NotEmpty().WithMessage("Please specify a valid WorkAreaId.");
            RuleFor(x => x.CreateDate).NotEmpty().WithMessage("Please specify a valid CreateDate.");
            RuleFor(x => x.FamilyState).Length(2, 20).WithMessage("Please specify a valid Title. Max length: 20, Min length: 2");

        }
    }
}
