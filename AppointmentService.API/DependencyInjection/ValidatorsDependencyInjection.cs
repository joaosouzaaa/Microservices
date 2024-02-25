using AppointmentService.API.Entities;
using AppointmentService.API.Validators;
using FluentValidation;

namespace AppointmentService.API.DependencyInjection;
public static class ValidatorsDependencyInjection
{
    public static void AddValidatorsDependencyInjection(this IServiceCollection services)
    {
        services.AddScoped<IValidator<AppointmentTime>, AppointmentTimeValidator>();
    }
}
