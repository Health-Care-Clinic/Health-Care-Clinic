using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Newtonsoft.Json;
using Pharmacy.ApiKeys.Model;
using Pharmacy.Interfaces.Repository;
using Pharmacy.Interfaces.Service;
using Pharmacy.Tendering.Model;
using RabbitMQ.Client;
using RabbitMQ.Client.Events;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Pharmacy.Tendering.Service
{
    public class RabbitMQTenderService : BackgroundService
    {
        IConnection connection;
        IModel channel;
        public IServiceProvider Services { get; }

        public RabbitMQTenderService(IServiceProvider services)
        {
            Services = services;
        }

        public override Task StartAsync(CancellationToken cancellationToken)
        {
            var factory = new ConnectionFactory() { HostName = "localhost" };

            connection = factory.CreateConnection();
            channel = connection.CreateModel();
            channel.QueueDeclare(queue: "tender",
                                    durable: false,
                                    exclusive: false,
                                    autoDelete: false,
                                    arguments: null);

            var consumer = new EventingBasicConsumer(channel);
            consumer.Received += (model, ea) =>
            {
                byte[] body = ea.Body.ToArray();
                var jsonMessage = Encoding.UTF8.GetString(body);
                Tender tender;
                tender = JsonConvert.DeserializeObject<Tender>(jsonMessage);

                Console.WriteLine(" [x] Received \n\tPrice: {0}\n\tDate Range: {1} - {2}\n\tDescription: {3}", tender.TotalPrice.Amount, tender.DateRange.Start.ToShortDateString(),
                                    tender.DateRange.End.ToShortDateString(), tender.TenderResponseDescription);
                using (var scope = Services.CreateScope())
                {
                    var tenderRepository =
                        scope.ServiceProvider
                            .GetRequiredService<ITenderRepository>();

                    tenderRepository.Add(tender);
                    tenderRepository.Save();
                }
            };
            channel.BasicConsume(queue: "tender",
                                    autoAck: true,
                                    consumer: consumer);

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
