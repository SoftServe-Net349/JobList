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
            //RuleFor(x => x.Count).NotEmpty().Must(c => c > 5 && c < 20).WithMessage("Please specify a valid Count. Max value: 19, Min value: 6");
            //RuleFor(x => x.DateOfCreation).NotEmpty().Must(BeAValidCreationDate).WithMessage($"Please specify a valid Creation Date. Sample Creation Date have to be between {DateTime.UtcNow.AddYears(-50).ToShortDateString()} and {DateTime.UtcNow.ToShortDateString()}");
            //RuleFor(x => x.SampleField).NotEmpty().WithMessage("Please specify a valid SampleField");

        }
    }
}
