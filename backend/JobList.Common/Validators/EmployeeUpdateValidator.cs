using FluentValidation;
using JobList.Common.Requests;

namespace JobList.Common.Validators
{
    public class EmployeeUpdateValidator : AbstractValidator<EmployeeUpdateRequest>
    {
        public EmployeeUpdateValidator()
        {
            RuleFor(x => x.FirstName).NotEmpty().Length(1, 50).WithMessage("Please specify a valid First Name.");
            RuleFor(x => x.LastName).NotEmpty().Length(2, 50).WithMessage("Please specify a valid Last Name.");
            RuleFor(x => x.Phone).MaximumLength(15).WithMessage("Please specify a valid Phone.");
            RuleFor(x => x.PhotoMimeType).MaximumLength(5).WithMessage("Please specify a valid Photo Mime Type.");
            RuleFor(x => x.Sex).MaximumLength(1).WithMessage("Please specify a valid Sex.");
            RuleFor(x => x.BirthDate).NotEmpty().WithMessage("Please specify a valid Birth Date.");
            RuleFor(x => x.Email).NotEmpty().Length(6, 254).WithMessage("Please specify a valid Email.");
            RuleFor(x => x.RoleId).NotEmpty().WithMessage("Please specify a valid Role Id.");
            RuleFor(x => x.CityId).NotEmpty().WithMessage("Please specify a valid City Id.");
        }
    }
}
