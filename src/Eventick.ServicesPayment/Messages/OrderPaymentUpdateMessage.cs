using System;
using Eventick.Integration.Messages;

namespace Eventick.Services.Payment.Messages
{
    public class OrderPaymentUpdateMessage: IntegrationBaseMessage
    {
        public Guid OrderId { get; set; }
        public bool PaymentSuccess { get; set; }
    }
}
