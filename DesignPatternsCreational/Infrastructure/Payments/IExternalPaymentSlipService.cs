using DesignPatternsCreational.Application.Models;
using DesignPatternsCreational.Infrastructure.Payments.Models;

namespace DesignPatternsCreational.Infrastructure.Payments
{
    public interface IExternalPaymentSlipService
    {
        ExternalPaymentSlipModel GeneratePaymentSlip(OrderInputModel model);
    }
}
