using FluentValidation;
using JobList.Common.Requests;

namespace JobList.Common.Validators
{
    public class SchoolValidator : AbstractValidator<SchoolRequest>
    {
        public SchoolValidator()
        {
            RuleFor(x => x.Name).Length(1, 300).WithMessage("Please specify a valid Name.");
        }
    }
}
