using DesignPatternsCreational.Application.Configurations;
using DesignPatternsCreational.Application.Models;
using DesignPatternsCreational.Infrastructure;
using DesignPatternsCreational.Infrastructure.Payments;
using Microsoft.AspNetCore.Mvc;

namespace DesignPatternsCreational.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrdersController : ControllerBase
    {
        private readonly IPaymentServiceFactory paymentServiceFactory;

        public OrdersController(IPaymentServiceFactory paymentServiceFactory)
        {
            this.paymentServiceFactory = paymentServiceFactory;
        }

        [HttpPost("FactoryMethod")]
        public IActionResult FactoryMethod(OrderInputModel model)
        {
            var paymentService = paymentServiceFactory.GetService(model.PaymentInfo.PaymentMethod);
            paymentService.Process(model);

            return NoContent();
        }

        // - Abstract Factory
        [HttpPost("AbstractFactory")]
        public IActionResult AbstractFactory(OrderInputModel model, [FromServices] InternationalOrderAbstractFactory internationalOrderAbstractFactory, [FromServices] NationalOrderAbstractFactory nationalOrderAbstractFactory)
        {
            IOrderAbstractFactory abstractFactory;
            if (model.IsInternational != null && model.IsInternational.Value)
            {
                abstractFactory = internationalOrderAbstractFactory;
            }
            else
            {
                abstractFactory = nationalOrderAbstractFactory;
            }

            var paymentResult = abstractFactory.GetPaymentService(model.PaymentInfo.PaymentMethod).Process(model);

            return NoContent();

        }

        [HttpPost("Prototype")]
        public IActionResult Prototype(OrderInputModel model)
        {
            var customerData = model.Customer.ReturnDataAsString();
            var customerCopy = model.Customer.Clone();
            var customerCopyData = (customerCopy as CustomerInputModel).ReturnDataAsString();

            return Ok(new { customerData, customerCopyData });
        }

        [HttpPost("Singleton")]
        public IActionResult Singleton()
        {
            return Ok(BusinessHours.GetInstance());
        }
    }
}
