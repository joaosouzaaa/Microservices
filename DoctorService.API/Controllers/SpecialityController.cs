using DoctorService.API.DataTransferObjects.Speciality;
using DoctorService.API.Interfaces.Services;
using DoctorService.API.Settings.NotificationSettings;
using Microsoft.AspNetCore.Mvc;

namespace DoctorService.API.Controllers;
[Route("api/[controller]")]
[ApiController]
public sealed class SpecialityController(ISpecialityService specialityService) : ControllerBase
{
    [HttpPost("add")]
    [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(bool))]
    [ProducesResponseType(StatusCodes.Status400BadRequest, Type = typeof(List<Notification>))]
    [ProducesResponseType(StatusCodes.Status500InternalServerError)]
    public Task<bool> AddAsync([FromBody] SpecialitySave specialitySave) =>
        specialityService.AddAsync(specialitySave);

    [HttpDelete("delete")]
    [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(bool))]
    [ProducesResponseType(StatusCodes.Status400BadRequest, Type = typeof(List<Notification>))]
    [ProducesResponseType(StatusCodes.Status500InternalServerError)]
    public Task<bool> DeleteAsync([FromQuery] int id) =>
        specialityService.DeleteAsync(id);

    [HttpGet("get-all")]
    [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(List<SpecialityResponse>))]
    [ProducesResponseType(StatusCodes.Status500InternalServerError)]
    public Task<List<SpecialityResponse>> GetAllAsync() =>
        specialityService.GetAllAsync();
}
