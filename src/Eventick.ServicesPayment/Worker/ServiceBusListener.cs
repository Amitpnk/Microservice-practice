using Azure.Messaging.ServiceBus;
using Eventick.Integration.MessagingBus;
using Eventick.Services.Payment.Messages;
using Eventick.Services.Payment.Model;
using Eventick.Services.Payment.Services;
using Newtonsoft.Json;

namespace Eventick.Services.Payment.Worker
{
    public class ServiceBusListener : IHostedService, IDisposable
    {
        private readonly ILogger<ServiceBusListener> _logger;
        private readonly IConfiguration _configuration;
        private ServiceBusProcessor _processor;
        private readonly IExternalGatewayPaymentService _externalGatewayPaymentService;
        private readonly IMessageBus _messageBus;
        private readonly string _orderPaymentUpdatedMessageTopic;
        private ServiceBusClient _client;

        public ServiceBusListener(
            IConfiguration configuration,
            ILoggerFactory loggerFactory,
            IExternalGatewayPaymentService externalGatewayPaymentService,
            IMessageBus messageBus)
        {
            _logger = loggerFactory.CreateLogger<ServiceBusListener>();
            _orderPaymentUpdatedMessageTopic = configuration.GetValue<string>("OrderPaymentUpdatedMessageTopic");

            _configuration = configuration;
            _externalGatewayPaymentService = externalGatewayPaymentService;
            _messageBus = messageBus;
        }

        public async Task StartAsync(CancellationToken cancellationToken)
        {
            var connectionString = _configuration.GetValue<string>("ServiceBusConnectionString");
            var topicName = _configuration.GetValue<string>("OrderPaymentRequestMessageTopic");
            var subscriptionName = _configuration.GetValue<string>("subscriptionName");

            _client = new ServiceBusClient(connectionString);
            _processor = _client.CreateProcessor(topicName, subscriptionName, new ServiceBusProcessorOptions
            {
                MaxConcurrentCalls = 3,
                AutoCompleteMessages = false
            });

            _processor.ProcessMessageAsync += ProcessMessageAsync;
            _processor.ProcessErrorAsync += ProcessErrorAsync;

            await _processor.StartProcessingAsync(cancellationToken);

            _logger.LogInformation("ServiceBusListener started.");
        }

        public async Task StopAsync(CancellationToken cancellationToken)
        {
            _logger.LogInformation("ServiceBusListener stopping.");

            if (_processor != null)
            {
                await _processor.CloseAsync(cancellationToken);
                _processor.ProcessMessageAsync -= ProcessMessageAsync;
                _processor.ProcessErrorAsync -= ProcessErrorAsync;
            }

            if (_client != null)
            {
                await _client.DisposeAsync();
            }
        }

        private Task ProcessErrorAsync(ProcessErrorEventArgs args)
        {
            _logger.LogError(args.Exception, "Error while processing queue item in ServiceBusListener.");
            return Task.CompletedTask;
        }

        private async Task ProcessMessageAsync(ProcessMessageEventArgs args)
        {
            try
            {
                var messageBody = args.Message.Body.ToString();
                var orderPaymentRequestMessage = JsonConvert.DeserializeObject<OrderPaymentRequestMessage>(messageBody);

                _logger.LogInformation("Processing message with OrderId: {OrderId}", orderPaymentRequestMessage.OrderId);

                PaymentInfo paymentInfo = new PaymentInfo
                {
                    CardNumber = orderPaymentRequestMessage.CardNumber,
                    CardName = orderPaymentRequestMessage.CardName,
                    CardExpiration = orderPaymentRequestMessage.CardExpiration,
                    Total = orderPaymentRequestMessage.Total
                };

                var result = await _externalGatewayPaymentService.PerformPayment(paymentInfo);

                await args.CompleteMessageAsync(args.Message);

                var orderPaymentUpdateMessage = new OrderPaymentUpdateMessage
                {
                    PaymentSuccess = result,
                    OrderId = orderPaymentRequestMessage.OrderId
                };

                await _messageBus.PublishMessage(orderPaymentUpdateMessage, _orderPaymentUpdatedMessageTopic);

                _logger.LogInformation("Message with OrderId: {OrderId} processed successfully.", orderPaymentRequestMessage.OrderId);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error processing message. Abandoning message.");
                await args.AbandonMessageAsync(args.Message);
            }
        }

        public void Dispose()
        {
            if (_processor != null)
            {
                _processor.CloseAsync().GetAwaiter().GetResult();
                _processor.DisposeAsync().GetAwaiter().GetResult();
            }

            if (_client != null)
            {
                _client.DisposeAsync().GetAwaiter().GetResult();
            }
        }
    }
}