using Microsoft.EntityFrameworkCore;
using OrdersAPI.Data;
using MassTransit;
using OrdersAPI.Consumer;
var builder = WebApplication.CreateBuilder(args);

builder.Services.AddDbContext<OrdersAPIContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("OrdersAPIContext")));

builder.Services.AddControllers();
builder.Services.AddOpenApi();
builder.Services.AddMassTransit(x =>
{
    x.AddConsumer<ProductCreatedConsumer>();
    x.UsingRabbitMq((context, cfg) =>
    {
        cfg.Host(new Uri("rabbitmq://localhost:4001"), h =>
        {
            h.Username("guest");
            h.Password("guest");
        });
        cfg.ReceiveEndpoint("event-listener", e =>
        {
            e.ConfigureConsumer<ProductCreatedConsumer>(context);
        });
    });
});
var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
}

app.UseHttpsRedirection();
app.UseAuthorization();
app.MapControllers();

app.Run();