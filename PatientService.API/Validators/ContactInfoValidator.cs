using FluentValidation;
using PatientService.API.Entities;
using PatientService.API.Enums;
using PatientService.API.Extensions;

namespace PatientService.API.Validators;
public sealed class ContactInfoValidator : AbstractValidator<ContactInfo>
{
    public ContactInfoValidator()
    {
        RuleFor(c => c.PhoneNumber).Length(11)
            .WithMessage(EMessage.InvalidLength.Description().FormatTo("Phone number", "11"));

        RuleFor(c => c.Email).EmailAddress().Length(1, 100)
            .WithMessage(EMessage.InvalidFormat.Description().FormatTo("Email"));
    }
}
