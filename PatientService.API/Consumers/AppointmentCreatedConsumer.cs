using Microsoft.Extensions.Options;
using PatientService.API.Constants;
using PatientService.API.Contracts;
using PatientService.API.Interfaces.Services;
using PatientService.API.Options;
using RabbitMQ.Client;
using RabbitMQ.Client.Events;
using System.Text;
using System.Text.Json;

namespace PatientService.API.Consumers;
public sealed class AppointmentCreatedConsumer(IOptions<RabbitMQCredentialsOptions> rabbitMQOptions, IServiceScopeFactory scopeFactory) : BackgroundService
{
    private readonly RabbitMQCredentialsOptions _rabbitMQCredentialsOptions = rabbitMQOptions.Value;

    protected override async Task ExecuteAsync(CancellationToken stoppingToken)
    {
        var factory = new ConnectionFactory()
        {
            HostName = _rabbitMQCredentialsOptions.HostName,
            Port = _rabbitMQCredentialsOptions.Port,
            UserName = _rabbitMQCredentialsOptions.UserName,
            Password = _rabbitMQCredentialsOptions.Password
        };

        using var connection = factory.CreateConnection();
        using var channel = connection.CreateModel();

        channel.ExchangeDeclare(RabbitMQConstants.AppointmentExchange, ExchangeType.Fanout);

        channel.QueueDeclare(queue: RabbitMQConstants.ApointmentPatientQueue, durable: false, exclusive: false, autoDelete: false, arguments: null);

        channel.QueueBind(RabbitMQConstants.ApointmentPatientQueue, RabbitMQConstants.AppointmentExchange, RabbitMQConstants.ApointmentPatientQueue);

        var consumer = new EventingBasicConsumer(channel);

        consumer.Received += async (sender, eventArgs) =>
        {
            await HandleAppointmentTimeCreatedMessageAsync(eventArgs);
        };

        channel.BasicConsume(queue: RabbitMQConstants.ApointmentPatientQueue, autoAck: true, consumer: consumer);

        while (!stoppingToken.IsCancellationRequested)
        {
            const int millisecondsDelay = 1000;
            await Task.Delay(millisecondsDelay, stoppingToken);
        }
    }

    private async Task HandleAppointmentTimeCreatedMessageAsync(BasicDeliverEventArgs eventArgs)
    {
        var body = eventArgs.Body.ToArray();
        var message = Encoding.UTF8.GetString(body);
        var appointmentTimeCreatedEvent = JsonSerializer.Deserialize<AppointmentTimeCreatedEvent>(message);

        using var scope = scopeFactory.CreateScope();

        var emailService = scope.ServiceProvider.GetRequiredService<IEmailService>();

        await emailService.SendAppointmentEmailAsync(appointmentTimeCreatedEvent!);
    }
}
