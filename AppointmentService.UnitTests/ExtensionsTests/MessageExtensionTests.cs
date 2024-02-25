using AppointmentService.API.Enums;
using AppointmentService.API.Extensions;

namespace AppointmentService.UnitTests.ExtensionsTests;
public sealed class MessageExtensionTests
{
    [Fact]
    public void Description_Equals_AsIntended()
    {
        // A
        var messageToGetDescription = EMessage.GreaterThan;

        // A
        var messageDescription = messageToGetDescription.Description();

        // A
        Assert.Equal("{0} has to be greater than {1}.", messageDescription);
    }
}
