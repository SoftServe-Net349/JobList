﻿using FluentValidation;
using JobList.Common.Requests;

namespace JobList.Common.Validators
{
    public class SchoolValidator : AbstractValidator<SchoolRequest>
    {
        public SchoolValidator()
        {
            RuleFor(x => x.Id).NotEmpty().WithMessage("Please specify a valid Id.");
            RuleFor(x => x.Name).NotEmpty().Length(1, 300).WithMessage("Please specify a valid Name.");
        }
    }
}
