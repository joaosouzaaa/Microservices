using DoctorService.API.Entities;
using DoctorService.API.Enums;
using DoctorService.API.Extensions;
using FluentValidation;

namespace DoctorService.API.Validators;
public sealed class CertificationValidator : AbstractValidator<Certification>
{
    public CertificationValidator()
    {
        RuleFor(c => c.LicenseNumber).Length(20)
            .WithMessage(EMessage.InvalidLength.Description().FormatTo("License Number", "20"));
    }
}
