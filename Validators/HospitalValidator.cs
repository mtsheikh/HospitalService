using FluentValidation;
using HospitalService.Models;

namespace HospitalService.Validators
{
    public class HospitalValidator : AbstractValidator<hospital>
    {
        public HospitalValidator()
        {
            // Validation for hospital Beds
            RuleFor(hospital => hospital.Beds)
                .Cascade(CascadeMode.StopOnFirstFailure)
                .NotNull()
                    .WithMessage("{PropertyName} is required.")
                .GreaterThan(-1)
                    .WithMessage("{PropertyName} cannot be a negative number.");

            // Validation for hospital Zip Code (US Only)
            RuleFor(hospital => hospital.Zip)
                .Cascade(CascadeMode.StopOnFirstFailure)
                .NotNull()
                    .WithMessage("{PropertyName} is required.")
                .Matches(@"^\d{5}(?:[-\s]\d{4})?$")
                    .WithMessage("{PropertyName} should be in format 12345.");

            // Validation for hospital State
            RuleFor(hospital => hospital.State)
                .Cascade(CascadeMode.StopOnFirstFailure)
                .NotNull()
                    .WithMessage("{PropertyName} is required.")
                .Matches(@"^[A-Z]{2}$")
                    .WithMessage("This is not a valid {PropertyName}.");
            
            // Validation for hospital Name
            RuleFor(hospital => hospital.Name)
                .NotNull()
                    .WithMessage("{PropertyName} is required.");
            
            // Validation for hospital City
            RuleFor(hospital => hospital.City)
                .Cascade(CascadeMode.StopOnFirstFailure)
                .NotNull()
                    .WithMessage("{PropertyName} is required.")
                .Matches(@"^[a-zA-Z]+(?:[\s-][a-zA-Z]+)*$")
                    .WithMessage("This is not a valid {PropertyName}.");

            // Validation for hospital County
            RuleFor(hospital => hospital.County)
                .Cascade(CascadeMode.StopOnFirstFailure)
                .NotNull()
                    .WithMessage("{PropertyName} is required.")
                .Matches(@"^[a-zA-Z]+(?:[\s-][a-zA-Z]+)*$")
                    .WithMessage("This is not a valid {PropertyName}.");
        }
    }
}