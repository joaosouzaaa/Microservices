using DoctorService.API.Enums;
using DoctorService.API.Extensions;

namespace DoctorService.UnitTests.ExtensionsTests;
public sealed class MessageExtensionTests
{
    [Fact]
    public void Description_Equals_AsIntended()
    {
        // A
        var messageToGetDescription = EMessage.Required;

        // A
        var messageDescription = messageToGetDescription.Description();

        // A
        Assert.Equal("{0} needs to be filled.", messageDescription);
    }
}
