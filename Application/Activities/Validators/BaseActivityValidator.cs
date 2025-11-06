using System;
using Application.Activities.DTOs;
using FluentValidation;

namespace Application.Activities.Validators;

public class BaseActivityValidator<T, TDto> 
    : AbstractValidator<T> where TDto : BaseActivityDto
{
    public BaseActivityValidator(Func<T, TDto> selector)
    {
        RuleFor(x => selector(x).Title).NotEmpty().WithMessage("Title is required")
            .MaximumLength(100).WithMessage("Title must not exceed 100 chars");
        RuleFor(x => selector(x).Description).NotEmpty().WithMessage("Description is required");
        RuleFor(x => selector(x).Date)
            .GreaterThan(DateTime.UtcNow).WithMessage("Date must be in the future");
        RuleFor(x => selector(x).Category).NotEmpty().WithMessage("Category is required");
        RuleFor(x => selector(x).City).NotEmpty().WithMessage("City is required");
        RuleFor(x => selector(x).Venue).NotEmpty().WithMessage("Venue is required");
        RuleFor(x => selector(x).Latitude).InclusiveBetween(-90,90)
           .NotEmpty().WithMessage("Latitude is required")
           .InclusiveBetween(-180,180) 
           .WithMessage("Latitude should be between -90 till 90");
        RuleFor(x => selector(x).Longitude)
            .NotEmpty().WithMessage("Longitude is required")
            .InclusiveBetween(-180,180).WithMessage("Longitude should be between -180 till 180");
    }
}
