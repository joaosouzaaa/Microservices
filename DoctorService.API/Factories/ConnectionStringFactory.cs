using DoctorService.API.Factories;

namespace DoctorService.API.Factories;
public static class ConnectionStringFactory
{
    public static string GetConnectionString(this IConfiguration configuration)
    {
        if (Environment.GetEnvironmentVariable("DOCKER_ENVIROMENT") == "DOCTOR_DOCKER_ENV")
            return configuration.GetConnectionString("ContainerConnection")!;

        return configuration.GetConnectionString("LocalConnection")!;
    }
}
