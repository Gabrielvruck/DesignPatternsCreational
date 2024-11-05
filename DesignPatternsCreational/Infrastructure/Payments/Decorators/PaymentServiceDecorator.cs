using DesignPatternsCreational.Application.Models;
using DesignPatternsCreational.Infrastructure.Integrations;

namespace DesignPatternsCreational.Infrastructure.Payments.Decorators
{
    public class PaymentServiceDecorator : IPaymentService
    {
        private IPaymentService _paymentService;
        private readonly ICoreCrmIntegrationService _crmService;

        public PaymentServiceDecorator(IPaymentService paymentService, ICoreCrmIntegrationService crmService)
        {
            _paymentService = paymentService;
            _crmService = crmService;
        }

        public object Process(OrderInputModel model)
        {
            var result = _paymentService.Process(model);

            _crmService.Sync(model);

            return result;
        }

        public object ProcessAdapter(OrderInputModel model)
        {
            throw new NotImplementedException();
        }
    }
}
