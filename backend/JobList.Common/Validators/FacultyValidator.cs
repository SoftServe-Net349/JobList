using FluentValidation;
using JobList.Common.Requests;

namespace JobList.Common.Validators
{
    public class FacultyValidator : AbstractValidator<FacultyRequest>
    {
        public FacultyValidator()
        {
            RuleFor(x => x.Id).NotEmpty().WithName("Please specify a valid Id.");
            RuleFor(x => x.Name).NotEmpty().Length(1, 200).WithName("Please specify a valid Name.");
        }
    }
}
