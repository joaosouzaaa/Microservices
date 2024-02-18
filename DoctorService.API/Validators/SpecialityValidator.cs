using DoctorService.API.Entities;
using DoctorService.API.Enums;
using FluentValidation;

namespace DoctorService.API.Validators;
public sealed class SpecialityValidator : AbstractValidator<Speciality>
{
    public SpecialityValidator()
    {
        RuleFor(s => s.Name).NotEmpty().Length(1, 100)
            .WithMessage(EMessage.InvalidLength.Description().FormatTo("Name", "1 to 100"));
    }
}
