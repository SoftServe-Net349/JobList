using FluentValidation;
using JobList.Common.Requests;

namespace JobList.Common.Validators
{
    public class UserValidator : AbstractValidator<UserRequest>
    {
        public UserValidator()
        {
            RuleFor(x => x.FirstName).Length(1, 50).WithMessage("Please specify a valid First Name.");
            RuleFor(x => x.LastName).Length(1, 50).WithMessage("Please specify a valid Last Name.");
            RuleFor(x => x.Phone).MaximumLength(15).WithMessage("Please specify a valid Phone.");
            // RuleFor(x => x.PhotoData)
            RuleFor(x => x.PhotoMimeType).MaximumLength(50).WithMessage("Please specify a valid Photo Mime Type.");
            RuleFor(x => x.Sex).MaximumLength(1).WithMessage("Please specify a valid Sex.");
            RuleFor(x => x.BirthData).NotEmpty().WithMessage("Please specify a valid Birth Date.");
            // RuleFor(x => x.Address)
            RuleFor(x => x.Email).Length(1, 150).WithMessage("Please specify a valid Email.");
            RuleFor(x => x.Password).Length(1, 100).WithMessage("Please specify a valid Password.");
            RuleFor(x => x.RoleId).NotEmpty().WithMessage("Please specify a valid Role Id.");
            RuleFor(x => x.CityId).NotEmpty().WithMessage("Please specify a valid City Id.");
        }
    }
}
