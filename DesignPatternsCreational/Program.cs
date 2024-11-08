using DesignPatternsCreational.Application;
using DesignPatternsCreational.Infrastructure;
using DesignPatternsCreational.Infrastructure.Deliveries;
using DesignPatternsCreational.Infrastructure.Payments;
using DesignPatternsCreational.Infrastructure.Payments.Decorators;
using DesignPatternsCreational.Infrastructure.Proxies;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddMemoryCache();
// Add services to the container.

builder.Services.AddControllers();
builder.Services.AddHttpContextAccessor();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddScoped<ICustomerRepository, CustomerRepository>();

builder.Services.AddScoped<CustomerRepositoryProxy>();

builder.Services.AddSingleton<PaymentMethodsFactory>();


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
