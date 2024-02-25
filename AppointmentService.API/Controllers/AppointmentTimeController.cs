using AppointmentService.API.DataTransferObjects.Appointment;
using AppointmentService.API.Interfaces.Services;
using AppointmentService.API.Settings.NotificationSettings;
using Microsoft.AspNetCore.Mvc;

namespace AppointmentService.API.Controllers;
[Route("api/[controller]")]
[ApiController]
public sealed class AppointmentTimeController(IAppointmentTimeService appointmentTimeService) : ControllerBase
{
    [HttpPost("add")]
    [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(bool))]
    [ProducesResponseType(StatusCodes.Status400BadRequest, Type = typeof(List<Notification>))]
    [ProducesResponseType(StatusCodes.Status500InternalServerError)]
    public Task<bool> AddAsync([FromBody] AppointmentTimeSave appointmentTimeSave) =>
        appointmentTimeService.AddAsync(appointmentTimeSave);
}
