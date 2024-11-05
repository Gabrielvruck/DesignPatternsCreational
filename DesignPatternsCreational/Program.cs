using DesignPatternsCreational.Infrastructure;
using DesignPatternsCreational.Infrastructure.Deliveries;
using DesignPatternsCreational.Infrastructure.Payments;
using DesignPatternsCreational.Infrastructure.Payments.Decorators;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddScoped<IPaymentService, CreditCardService>();
builder.Services.AddScoped<IPaymentService, PaymentSlipService>();
builder.Services.AddScoped<IDeliveryService, NationalDeliveryService>();
builder.Services.AddScoped<IDeliveryService, InternationalDeliveryService>();
builder.Services.AddScoped<ExternalPaymentSlipService>();
builder.Services.AddScoped<IExternalPaymentSlipService, ExternalPaymentSlipServiceDecorator>();
builder.Services.AddScoped<IPaymentService, PaymentServiceDecorator>();

builder.Services.AddSingleton<IPaymentServiceFactory, PaymentServiceFactory>();
builder.Services.AddSingleton<IOrderAbstractFactory, InternationalOrderAbstractFactory>();
builder.Services.AddSingleton<IOrderAbstractFactory, NationalOrderAbstractFactory>();



var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
