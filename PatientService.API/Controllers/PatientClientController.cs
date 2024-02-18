using Microsoft.AspNetCore.Mvc;
using PatientService.API.DataTransferObjects.PatientClient;
using PatientService.API.Interfaces.Services;
using PatientService.API.Settings.NotificationSettings;

namespace PatientService.API.Controllers;

[Route("api/[controller]")]
[ApiController]
public sealed class PatientClientController(IPatientClientService patientClientService) : ControllerBase
{
    [HttpPost("add")]
    [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(bool))]
    [ProducesResponseType(StatusCodes.Status400BadRequest, Type = typeof(List<Notification>))]
    [ProducesResponseType(StatusCodes.Status500InternalServerError)]
    public Task<bool> AddAsync([FromBody] PatientClientSave patientClientSave) =>
        patientClientService.AddAsync(patientClientSave);

    [HttpPut("update")]
    [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(bool))]
    [ProducesResponseType(StatusCodes.Status400BadRequest, Type = typeof(List<Notification>))]
    [ProducesResponseType(StatusCodes.Status500InternalServerError)]
    public Task<bool> UpdateAsync([FromBody] PatientClientUpdate patientClientUpdate) =>
        patientClientService.UpdateAsync(patientClientUpdate);

    [HttpGet("get-by-id")]
    [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(bool))]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(StatusCodes.Status500InternalServerError)]
    public Task<PatientClientResponse?> GetByIdAsync([FromQuery] int id) =>
        patientClientService.GetByIdAsync(id);
}
