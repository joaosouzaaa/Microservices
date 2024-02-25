using AppointmentService.API.Factories;
using Microsoft.Extensions.Configuration;

namespace AppointmentService.UnitTests.FactoriesTests;
public sealed class ConnectionStringFactoryTests
{
    [Fact]
    public void GetConnectionString_ReturnsContainerConnection()
    {
        // A
        const string containerConnection = "test";
        var inMemoryCollection = new Dictionary<string, string>()
        {
            {"ConnectionStrings:ContainerConnection", containerConnection }
        };
        IConfiguration configuration = new ConfigurationBuilder()
            .AddInMemoryCollection(inMemoryCollection!)
            .Build();

        Environment.SetEnvironmentVariable("DOCKER_ENVIROMENT", "APPOINTMENT_DOCKER_ENV");

        // A
        var connectionStringResult = configuration.GetConnectionString();

        // A
        Assert.Equal(containerConnection, connectionStringResult);
    }

    [Fact]
    public void GetConnectionString_ReturnsLocalConnection()
    {
        // A
        const string localConnection = "joao";
        var inMemoryCollection = new Dictionary<string, string>()
        {
            {"ConnectionStrings:LocalConnection", localConnection}
        };
        IConfiguration configuration = new ConfigurationBuilder()
            .AddInMemoryCollection(inMemoryCollection!)
            .Build();

        Environment.SetEnvironmentVariable("DOCKER_ENVIROMENT", "any value");

        // A
        var connectionStringResult = configuration.GetConnectionString();

        // A
        Assert.Equal(localConnection, connectionStringResult);
    }
}
