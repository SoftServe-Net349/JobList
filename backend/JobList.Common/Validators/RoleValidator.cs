using FluentValidation;
using JobList.Common.Requests;

namespace JobList.Common.Validators
{
    public class RoleValidator : AbstractValidator<RoleRequest>
    {
        public RoleValidator()
        {
            RuleFor(x => x.Id).NotEmpty().WithMessage("Please specify a valid Id.");
            RuleFor(x => x.Name).NotEmpty().Length(1, 10).WithMessage("Please specify a valid Name.");
        }
    }
}
