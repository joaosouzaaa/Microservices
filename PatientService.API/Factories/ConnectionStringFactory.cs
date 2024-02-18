using PatientService.API.Factories;

namespace PatientService.API.Factories;
public static class ConnectionStringFactory
{
    public static string GetConnectionString(this IConfiguration configuration)
    {
        if (Environment.GetEnvironmentVariable("DOCKER_ENVIROMENT") == "PATIENT_DOCKER_ENV")
            return configuration.GetConnectionString("ContainerConnection")!;

        return configuration.GetConnectionString("LocalConnection")!;
    }
}
