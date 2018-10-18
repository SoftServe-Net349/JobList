using FluentValidation;
using JobList.Common.Requests;

namespace JobList.Common.Validators
{
    public class FavoriteVacancyValidator : AbstractValidator<FavoriteVacancyRequest>
    {
        public FavoriteVacancyValidator()
        {
            RuleFor(x => x.VacancyId).NotEmpty().WithMessage("Please specify a valid Vacancy Id.");
            RuleFor(x => x.UserId).NotEmpty().WithMessage("Please specify a valid User Id.");
        }
    }
}
