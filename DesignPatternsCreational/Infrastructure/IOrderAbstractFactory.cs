using DesignPatternsCreational.Core.Enums;
using DesignPatternsCreational.Infrastructure.Deliveries;
using DesignPatternsCreational.Infrastructure.Payments;

namespace DesignPatternsCreational.Infrastructure
{
    public interface IOrderAbstractFactory
    {
        IPaymentService GetPaymentService(PaymentMethod method);
        IDeliveryService GetDeliveryService();
    }
}
