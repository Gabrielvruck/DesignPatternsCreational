using DesignPatternsCreational.Application.Models;

namespace DesignPatternsCreational.Infrastructure.Payments
{
    public class CreditCardService : IPaymentService
    {
        public object Process(OrderInputModel model)
        {
            return "Transação aprovada";
        }
    }
}
