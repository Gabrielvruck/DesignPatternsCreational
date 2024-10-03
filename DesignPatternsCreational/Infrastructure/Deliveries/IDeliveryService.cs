using DesignPatternsCreational.Application.Models;

namespace DesignPatternsCreational.Infrastructure.Deliveries
{
    public interface IDeliveryService
    {
        void Deliver(OrderInputModel model);
    }
}
