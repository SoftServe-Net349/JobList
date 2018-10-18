using FluentValidation;
using JobList.Common.Requests;

namespace JobList.Common.Validators
{
    public class RecruiterValidator : AbstractValidator<RecruiterRequest>
    {
        public RecruiterValidator()
        {
            RuleFor(x => x.FirstName).Length(1, 50)
                                     .WithMessage("Please specify a valid First Name.");
            RuleFor(x => x.LastName).Length(1, 50)
                                    .WithMessage("Please specify a valid Last Name.");
            RuleFor(x => x.Phone).Length(1, 15)
                                 .WithMessage("Please specify a valid Phone.");
            RuleFor(x => x.PhotoData).NotEmpty().WithMessage("Please specify a valid Photo Data.");
            RuleFor(x => x.PhotoMimetype).NotEmpty()
                                         .MaximumLength(50)
                                         .WithMessage("Please specify a valid Photo Mimetype.");
            RuleFor(x => x.Email).Length(1, 150)
                                 .WithMessage("Please specify a valid Email.");
            RuleFor(x => x.Password).Length(1, 100)
                                    .WithMessage("Please specify a valid Password.");
            RuleFor(x => x.CompanyId).NotEmpty().WithMessage("Please specify a valid  Company Id.");
            RuleFor(x => x.RoleId).NotEmpty().WithMessage("Please specify a valid ");
        }
    }
}
