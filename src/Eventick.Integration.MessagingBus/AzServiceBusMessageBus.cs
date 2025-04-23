using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using Azure.Messaging.ServiceBus;
using Eventick.Integration.Messages;

namespace Eventick.Integration.MessagingBus
{
    public class AzServiceBusMessageBus : IMessageBus
    {
        private readonly string connectionString;

        public AzServiceBusMessageBus()
        {
            // Read connection string from configuration (e.g., appsettings.json or environment variables)
            connectionString = Environment.GetEnvironmentVariable("ServiceBusConnectionString")
                               ?? throw new InvalidOperationException("Service Bus connection string is not configured.");
        }

        public async Task PublishMessage(IntegrationBaseMessage message, string topicName)
        {
            // Create a ServiceBusClient
            await using var client = new ServiceBusClient(connectionString);

            // Create a sender for the topic
            ServiceBusSender sender = client.CreateSender(topicName);

            try
            {
                // Serialize the message to JSON
                var jsonMessage = JsonSerializer.Serialize(message);

                // Create a ServiceBusMessage
                var serviceBusMessage = new ServiceBusMessage(Encoding.UTF8.GetBytes(jsonMessage))
                {
                    CorrelationId = Guid.NewGuid().ToString()
                };

                // Send the message
                await sender.SendMessageAsync(serviceBusMessage);
                Console.WriteLine($"Sent message to topic: {topicName}");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error sending message: {ex.Message}");
                throw;
            }
        }
    }
}
