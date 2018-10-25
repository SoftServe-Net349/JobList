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
            RuleFor(x => x.FamilyState).Length(1, 20).WithMessage("Please specify a valid FamilyState. Max length: 20, Min length: 2");
            RuleFor(x => x.Linkedin).Length(1, 200).WithMessage("Please specify a valid Linkedin. Max length: 20, Min length: 2");
            RuleFor(x => x.Github).Length(1, 200).WithMessage("Please specify a valid Github. Max length: 20, Min length: 2");
            RuleFor(x => x.Skype).Length(1, 200).WithMessage("Please specify a valid Skype. Max length: 20, Min length: 2");
            RuleFor(x => x.Instagram).Length(1, 200).WithMessage("Please specify a valid Instagram. Max length: 20, Min length: 2");
            RuleFor(x => x.Facebook).Length(1, 200).WithMessage("Please specify a valid Facebook. Max length: 20, Min length: 2");
            RuleFor(x => x.Introduction).NotEmpty().Length(1, 300).WithMessage("Please specify a valid Introduction. Max length: 20, Min length: 2");
            RuleFor(x => x.Position).Length(1, 100).WithMessage("Please specify a valid Position. Max length: 20, Min length: 2");

        }
    }
}
