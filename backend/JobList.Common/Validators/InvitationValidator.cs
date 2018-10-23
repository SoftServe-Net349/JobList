using FluentValidation;
using JobList.Common.Requests;

namespace JobList.Common.Validators
{
    public class InvitationValidator : AbstractValidator<InvitationRequest>
    {
        public InvitationValidator()
        {
            //RuleFor(x => x.VacancyId).NotEmpty().WithMessage("Please specify a valid Vacancy Id.");
            RuleFor(x => x.EmployeeId).NotEmpty().WithMessage("Please specify a valid Employee Id.");
        }
    }
}
