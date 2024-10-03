using DesignPatternsCreational.Core.Enums;
using DesignPatternsCreational.Infrastructure.Deliveries;
using DesignPatternsCreational.Infrastructure.Payments;

namespace DesignPatternsCreational.Infrastructure
{
    public class InternationalOrderAbstractFactory : IOrderAbstractFactory
    {
        public readonly IPaymentService _paymentService;
        public readonly IDeliveryService _deliveryService;
        public InternationalOrderAbstractFactory(CreditCardService creditCardService, InternationalDeliveryService internationalDeliveryService)
        {
            _paymentService = creditCardService;
            _deliveryService = internationalDeliveryService;
        }

        public IDeliveryService GetDeliveryService()
        {
            return _deliveryService;
        }

        public IPaymentService GetPaymentService(PaymentMethod method)
        {
            return _paymentService;
        }
    }
}
