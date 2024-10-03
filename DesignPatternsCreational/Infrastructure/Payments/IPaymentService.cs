using DesignPatternsCreational.Application.Models;

namespace DesignPatternsCreational.Infrastructure.Payments
{
    public interface IPaymentService
    {
        object Process(OrderInputModel model);
    }
}
