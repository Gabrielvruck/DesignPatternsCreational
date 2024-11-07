using DesignPatternsCreational.Core.Enums;
using DesignPatternsCreational.Infrastructure.Integrations;
using DesignPatternsCreational.Infrastructure.Payments.Decorators;

namespace DesignPatternsCreational.Infrastructure.Payments
{
    public class PaymentServiceFactory : IPaymentServiceFactory
    {
        private readonly CreditCardService _creditCardService;
        private readonly PaymentSlipService _paymentSlipService;
        private readonly ICoreCrmIntegrationService _crmService;
        private readonly IAntiFraudFacade _antiFraudFacade;
        public PaymentServiceFactory(CreditCardService creditCardService,PaymentSlipService paymentSlipService, ICoreCrmIntegrationService crmService, IAntiFraudFacade antiFraudFacade)
        {
            _creditCardService = creditCardService;
            _paymentSlipService = paymentSlipService;
            _crmService = crmService;
            _antiFraudFacade = antiFraudFacade;
        }

        public IPaymentService GetService(PaymentMethod paymentMethod)
        {
            IPaymentService paymentService;

            switch (paymentMethod)
            {
                case PaymentMethod.CreditCard:
                    paymentService = _creditCardService;

                    break;
                case PaymentMethod.PaymentSlip:
                    paymentService = _paymentSlipService;

                    break;
                default:
                    throw new InvalidOperationException();
            }

            return new PaymentServiceDecorator(paymentService, _crmService, _antiFraudFacade);
        }
    }
}
