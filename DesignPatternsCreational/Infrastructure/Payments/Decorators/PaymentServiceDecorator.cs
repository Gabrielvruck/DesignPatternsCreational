using DesignPatternsCreational.Application.Models;
using DesignPatternsCreational.Infrastructure.Integrations;

namespace DesignPatternsCreational.Infrastructure.Payments.Decorators
{
    public class PaymentServiceDecorator : IPaymentService
    {
        private IPaymentService _paymentService;
        private readonly ICoreCrmIntegrationService _crmService;
        private readonly IAntiFraudFacade _antiFraudFacade;
        public PaymentServiceDecorator(IPaymentService paymentService, ICoreCrmIntegrationService crmService, IAntiFraudFacade antiFraudFacade)
        {
            _paymentService = paymentService;
            _crmService = crmService;
            _antiFraudFacade = antiFraudFacade;
        }

        public object Process(OrderInputModel model)
        {
            var antiFraudModel = new AntiFraudModel(model.Customer.Document, model.TotalPrice);
            var antiFraudResult = _antiFraudFacade.Check(antiFraudModel);

            if (antiFraudResult == null || antiFraudResult.CheckResult)
                throw new InvalidOperationException(antiFraudResult?.Comments);

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
