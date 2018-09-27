using FluentValidation;
using JobList.Common.Requests;
using System;

namespace JobList.Common.Validators
{
    public class CityValidator : AbstractValidator<CityRequest>
    {
        public CityValidator()
        {
            RuleFor(x => x.Name).NotEmpty().WithMessage("Please specify a valid Name. Max length: 50, Min length: 3");
            //RuleFor(x => x.Count).NotEmpty().Must(c => c > 5 && c < 20).WithMessage("Please specify a valid Count. Max value: 19, Min value: 6");
            //RuleFor(x => x.DateOfCreation).NotEmpty().Must(BeAValidCreationDate).WithMessage($"Please specify a valid Creation Date. Sample Creation Date have to be between {DateTime.UtcNow.AddYears(-50).ToShortDateString()} and {DateTime.UtcNow.ToShortDateString()}");
            //RuleFor(x => x.SampleField).NotEmpty().WithMessage("Please specify a valid SampleField");
        }

        private bool BeAValidCreationDate(DateTime date)
        {
            if (date > DateTime.UtcNow || date < DateTime.UtcNow.AddYears(-50))
                return false;

            return true;
        }
    }
}
