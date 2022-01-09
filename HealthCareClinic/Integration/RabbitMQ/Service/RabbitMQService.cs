using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Integration.ApiKeys.Model;
using Integration.Interface.Repository;
using Integration.Promotions.Model;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Newtonsoft.Json;
using RabbitMQ.Client;
using RabbitMQ.Client.Events;

namespace Integration.RabbitMQ.Service
{
    public class RabbitMQService : BackgroundService
    {
        IConnection connection;
        IModel channel;
        public IServiceProvider Services { get; }

        public RabbitMQService(IServiceProvider services)
        {
            Services = services;
        }

        public override Task StartAsync(CancellationToken cancellationToken)
        {
            var factory = new ConnectionFactory() { HostName = Environment.GetEnvironmentVariable("RABBITMQ_HOST") ?? "localhost" };
            List<ApiKey> apiKeys;
            using (var scope = Services.CreateScope())
            {
                var apiKeyRepository =
                    scope.ServiceProvider
                        .GetRequiredService<IApiKeyRepository>();

                apiKeys = (List<ApiKey>)apiKeyRepository.GetAll();
            }

            foreach (ApiKey apiKey in apiKeys)
            {
                connection = factory.CreateConnection();
                channel = connection.CreateModel();
                channel.QueueDeclare(queue: apiKey.Key,
                                        durable: false,
                                        exclusive: false,
                                        autoDelete: false,
                                        arguments: null);

                var consumer = new EventingBasicConsumer(channel);
                consumer.Received += (model, ea) =>
                {
                    byte[] body = ea.Body.ToArray();
                    var jsonMessage = Encoding.UTF8.GetString(body);
                    PharmacyPromotion pharmacyPromotion;
                    pharmacyPromotion = JsonConvert.DeserializeObject<PharmacyPromotion>(jsonMessage);

                    Console.WriteLine(" [x] Received {0}", pharmacyPromotion.Content);
                    using (var scope = Services.CreateScope())
                    {
                        var pharmacyPromotionRepository =
                            scope.ServiceProvider
                                .GetRequiredService<IPharmacyPromotionRepository>();

                        pharmacyPromotionRepository.Add(pharmacyPromotion);
                        pharmacyPromotionRepository.Save();
                    }
                };
                channel.BasicConsume(queue: apiKey.Key,
                                        autoAck: true,
                                        consumer: consumer);
            }

            return base.StartAsync(cancellationToken);
        }

        public override Task StopAsync(CancellationToken cancellationToken)
        {
            channel.Close();
            connection.Close();
            return base.StopAsync(cancellationToken);
        }

        protected override Task ExecuteAsync(CancellationToken stoppingToken)
        {
            return Task.CompletedTask;
        }
    }
}
