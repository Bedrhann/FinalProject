﻿using Consumer.Interfaces.MongoDb;
using Consumer.Interfaces.RabbitMq;
using Consumer.Models;
using RabbitMQ.Client;
using RabbitMQ.Client.Events;
using System.Reflection;
using System.Text;
using System.Text.Json;

namespace ShoppingList.Consumer.Services.RabbitMq
{
    public class ConsumerService : IConsumerService
    {
        private readonly IMongoDbService _mongoDb;
        public ConsumerService(IMongoDbService mongoDb) => _mongoDb = mongoDb;

        public void Consume(string queueName, bool IsAcknowledgeAuto, IModel channel)
        {
            var consumer = new EventingBasicConsumer(channel);

            consumer.Received += async (sender, args) =>
            {
                var message = JsonSerializer.Deserialize<ArchivedShopList>(Encoding.UTF8.GetString(args.Body.ToArray()));
                if (message is not null)
                    await _mongoDb.CreateAsync(message);

                foreach (PropertyInfo p in message.GetType().GetProperties())
                    Console.WriteLine(p.Name + " : " + p.GetValue(message));
            };

            channel.BasicConsume(
                queue: queueName,
                autoAck: IsAcknowledgeAuto,
                consumer: consumer);
        }
    }
}