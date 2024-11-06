using DesignPatternsCreational.Core.Entities;

namespace DesignPatternsCreational.Infrastructure
{
    public interface ICustomerRepository
    {
        List<Customer> GetBlockedCustomers();
    }
}
