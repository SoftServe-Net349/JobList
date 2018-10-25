using FluentValidation;
using JobList.Common.Requests;

namespace JobList.Common.Validators
{
    public class WorkAreaValidator : AbstractValidator<WorkAreaRequest>
    {
        public WorkAreaValidator()
        {
            RuleFor(x => x.Id).NotEmpty().WithMessage("Please specify a valid Id.");
            RuleFor(x => x.Name).NotEmpty().Length(1, 100).WithMessage("Please specify a valid Name.");
        }
    }
}
