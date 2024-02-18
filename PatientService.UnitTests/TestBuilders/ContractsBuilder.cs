using PatientService.API.Contracts;

namespace PatientService.UnitTests.TestBuilders;
public sealed class ContractsBuilder
{
    public static ContractsBuilder NewObject() =>
        new();

    public AppointmentTimeCreatedEvent AppointmentTimeCreatedEventBuild() =>
        new(DateTime.Now,
            12,
            9);
}
