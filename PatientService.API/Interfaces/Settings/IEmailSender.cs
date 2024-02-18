using MimeKit;

namespace PatientService.API.Interfaces.Settings;
public interface IEmailSender
{
    Task SendEmailAsync(MimeMessage mailMessage);
}
