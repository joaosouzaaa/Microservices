using FluentValidation;
using PatientService.API.Entities;
using PatientService.API.Validators;

namespace PatientService.API.DependencyInjection;
public static class ValidatorsDependencyInjection
{
    public static void AddValidatorsDependencyInjection(this IServiceCollection services)
    {
        services.AddScoped<IValidator<ContactInfo>, ContactInfoValidator>();
        services.AddScoped<IValidator<PatientClient>, PatientClientValidator>();
    }
}
