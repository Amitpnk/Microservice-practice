using Eventick.Services.Payment.Model;
using System.Threading.Tasks;

namespace Eventick.Services.Payment.Services
{
    public interface IExternalGatewayPaymentService
    {
        Task<bool> PerformPayment(PaymentInfo paymentInfo);
    }
}
