﻿using DesignPatternsCreational.Application.Models;
using DesignPatternsCreational.Infrastructure.Payments.Models;

namespace DesignPatternsCreational.Infrastructure.Payments.Adapters
{
    public class PaymentSlipServiceAdapter
    {
        private readonly IExternalPaymentSlipService _externalService;

        public PaymentSlipServiceAdapter(IExternalPaymentSlipService externalService)
        {
            _externalService = externalService;
        }

        public PaymentSlipModel GeneratePaymentSlip(OrderInputModel model)
        {
            var externalModel = _externalService.GeneratePaymentSlip(model);

            var builder = new PaymentSlipBuilder();

            var paymentSlipModel = builder
                .Start()
                .WithPayer(new Payer(externalModel.payer_name, externalModel.payer_doc, externalModel.payer_addr))
                .WithReceiver(new Receiver(externalModel.receiver_name, externalModel.receiver_doc, externalModel.receiver_addr))
                .WithPaymentDocument(externalModel.bar_code, externalModel.number, externalModel.doc_amount)
                .WithDates(externalModel.proc_date, externalModel.exp_date)
                .Build();

            return paymentSlipModel;
        }
    }
}
