using System;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using Azure.Messaging.ServiceBus;
using Eventick.Integration.Messages;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;

namespace Eventick.Integration.MessagingBus
{
    public class ServiceBusSettings
    {
        public const string SectionName = "ServiceBus";
        public string ConnectionString { get; set; }
    }

    public class AzServiceBusMessageBus : IMessageBus, IAsyncDisposable
    {
        private readonly ServiceBusClient _client;
        private readonly ILogger<AzServiceBusMessageBus> _logger;

        public AzServiceBusMessageBus(IOptions<ServiceBusSettings> serviceBusSettings, ILogger<AzServiceBusMessageBus> logger)
        {
            if (string.IsNullOrWhiteSpace(serviceBusSettings.Value.ConnectionString))
            {
                throw new ArgumentException("Service Bus connection string is not configured.", nameof(serviceBusSettings));
            }
            
            _client = new ServiceBusClient(serviceBusSettings.Value.ConnectionString);
            _logger = logger;
        }

        public async Task PublishMessage(IntegrationBaseMessage message, string topicName)
        {
            if (message == null)
            {
                throw new ArgumentNullException(nameof(message));
            }

            if (string.IsNullOrWhiteSpace(topicName))
            {
                throw new ArgumentException("Topic name cannot be null or empty.", nameof(topicName));
            }

            await using var sender = _client.CreateSender(topicName);

            try
            {
                var jsonMessage = JsonSerializer.Serialize(message);
                var serviceBusMessage = new ServiceBusMessage(Encoding.UTF8.GetBytes(jsonMessage))
                {
                    CorrelationId = Guid.NewGuid().ToString(),
                    ContentType = "application/json"
                };

                await sender.SendMessageAsync(serviceBusMessage);
                _logger.LogInformation("Message sent to topic {TopicName}", topicName);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error sending message to topic {TopicName}", topicName);
                throw;
            }
        }

        public async ValueTask DisposeAsync()
        {
            await _client.DisposeAsync();
        }
    }
}