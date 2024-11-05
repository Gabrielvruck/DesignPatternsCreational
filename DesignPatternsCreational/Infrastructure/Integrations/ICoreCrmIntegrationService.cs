using DesignPatternsCreational.Application.Models;

namespace DesignPatternsCreational.Infrastructure.Integrations
{
    public interface ICoreCrmIntegrationService
    {
        void Sync(OrderInputModel model);
    }
}
