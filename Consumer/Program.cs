using Consumer;
using Consumer.Interfaces.MongoDb;
using Consumer.Interfaces.RabbitMq;
using Consumer.Models;
using Consumer.Services.MongoDb;
using ShoppingList.Consumer.Services.RabbitMq;

IHost host = Host.CreateDefaultBuilder(args)
    .ConfigureServices((hostContext, services) =>
    {
        IConfiguration configuration = hostContext.Configuration;

        services.AddTransient<IRabbitMqConnection, RabbitMqConnection>();
        services.AddTransient<IConsumerService, ConsumerService>();
        services.AddSingleton<IMongoDbService, MongoDbService>();

        services.Configure<MongoDbSettings>(
            configuration.GetSection("ShoppingListMongoDb"));

        services.AddHostedService<Worker>();
    })
    .Build();

await host.RunAsync();
