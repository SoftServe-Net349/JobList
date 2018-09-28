using FluentValidation;
using JobList.Common.Requests;

namespace JobList.Common.Validators
{
    public class CompanyValidator : AbstractValidator<CompanyRequest>
    {
        public CompanyValidator()
        {
            RuleFor(x => x.Name).NotEmpty().WithMessage("Please specify a valid Name.");
            RuleFor(x => x.BossName).NotEmpty().WithMessage("Please specify a valid BossName.");
            RuleFor(x => x.FullDescription).NotEmpty().WithMessage("Please specify a valid FullDescription.");
            RuleFor(x => x.Address).NotEmpty().WithMessage("Please specify a valid Address.");
            RuleFor(x => x.Phone).NotEmpty().WithMessage("Please specify a valid Phone.");
            RuleFor(x => x.Email).NotEmpty().WithMessage("Please specify a valid Email.");
            RuleFor(x => x.Password).NotEmpty().WithMessage("Please specify a valid Password.");
            RuleFor(x => x.RoleId).NotEmpty().WithMessage("Please specify a valid RoleId.");

        }
    }
}
