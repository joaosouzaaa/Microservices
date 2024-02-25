using System.ComponentModel;

namespace AppointmentService.API.Enums;
public enum EMessage : ushort
{
    [Description("{0} has to be greater than {1}.")]
    GreaterThan,

    [Description("{0} already exists.")]
    Exists
}
