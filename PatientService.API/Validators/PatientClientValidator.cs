using FluentValidation;
using PatientService.API.Entities;
using PatientService.API.Enums;
using PatientService.API.Extensions;

namespace PatientService.API.Validators;
public sealed class PatientClientValidator : AbstractValidator<PatientClient>
{
    public PatientClientValidator()
    {
        RuleFor(p => p.ContactInfo).SetValidator(new ContactInfoValidator());

        RuleFor(p => p.Name).Length(1, 100).NotEmpty()
            .WithMessage(EMessage.InvalidLength.Description().FormatTo("Name", "1 to 100"));

        RuleFor(p => p.Address).Length(1, 200).NotEmpty()
            .WithMessage(EMessage.InvalidLength.Description().FormatTo("Address", "1 to 200"));
    }
}
