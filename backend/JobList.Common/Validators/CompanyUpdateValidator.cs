using FluentValidation;
using JobList.Common.Requests;

namespace JobList.Common.Validators
{
    public class CompanyUpdateValidator : AbstractValidator<CompanyUpdateRequest>
    {
        public CompanyUpdateValidator()
        {
            RuleFor(x => x.Name).NotEmpty().MaximumLength(200).WithMessage("Please specify a valid Name.");
            RuleFor(x => x.BossName).NotEmpty().MaximumLength(100).WithMessage("Please specify a valid BossName.");
            RuleFor(x => x.FullDescription).NotEmpty().WithMessage("Please specify a valid FullDescription.");
            RuleFor(x => x.Address).NotEmpty().MaximumLength(200).WithMessage("Please specify a valid Address.");
            RuleFor(x => x.Email).NotEmpty().MaximumLength(254).WithMessage("Please specify a valid Email.");
            RuleFor(x => x.RoleId).NotEmpty().WithMessage("Please specify a valid RoleId.");
            RuleFor(x => x.ShortDescription).NotEmpty().MaximumLength(25).WithMessage("Please specify a valid ShortDescription.");
            RuleFor(x => x.LogoMimetype).MaximumLength(5).WithMessage("Please specify a valid LogoMimetype.");
            RuleFor(x => x.Phone).MaximumLength(15).WithMessage("Please specify a valid Phone.");
            RuleFor(x => x.Site).MaximumLength(100).WithMessage("Please specify a valid Site.");
        }
    }
}
