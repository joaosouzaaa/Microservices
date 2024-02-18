using DoctorService.API.Entities;
using DoctorService.API.Validators;
using FluentValidation;

namespace DoctorService.API.DependencyInjection;
public static class ValidatorsDependencyInjection
{
    public static void AddValidatorsDependencyInjection(this IServiceCollection services)
    {
        services.AddScoped<IValidator<Certification>, CertificationValidator>();
        services.AddScoped<IValidator<DoctorAttendant>, DoctorAttendantValidator>();
        services.AddScoped<IValidator<Speciality>, SpecialityValidator>();
    }
}
