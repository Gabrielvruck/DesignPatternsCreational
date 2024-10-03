using DesignPatternsCreational.Core.Enums;

namespace DesignPatternsCreational.Infrastructure.Payments
{
    public interface IPaymentServiceFactory
    {
        IPaymentService GetService(PaymentMethod paymentMethod);
    }
}
