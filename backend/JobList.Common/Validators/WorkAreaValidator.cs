using FluentValidation;
using JobList.Common.Requests;

namespace JobList.Common.Validators
{
    public class WorkAreaValidator : AbstractValidator<WorkAreaRequest>
    {
        public WorkAreaValidator()
        {
            RuleFor(x => x.Name).Length(1, 100).WithMessage("Please specify a valid Name.");
            RuleFor(x => x.PhotoMimetype).MaximumLength(50).WithMessage("Please specify a valid Photo Mime Type.");
        }
    }
}
