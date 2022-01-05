using Hospital.Tendering.Model;
using Hospital.Tendering.Repository;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Newtonsoft.Json;
using RabbitMQ.Client;
using RabbitMQ.Client.Events;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Hospital.Tendering.Service
{
    public class RabbitMQTenderResponseService : BackgroundService
    {
        IConnection connection;
        IModel channel;
        public IServiceProvider Services { get; }

        public RabbitMQTenderResponseService(IServiceProvider services)
        {
            Services = services;
        }

        public override Task StartAsync(CancellationToken cancellationToken)
        {
            var factory = new ConnectionFactory() { HostName = "localhost" };

            connection = factory.CreateConnection();
            channel = connection.CreateModel();
            channel.QueueDeclare(queue: "tenderResponse",
                                    durable: false,
                                    exclusive: false,
                                    autoDelete: false,
                                    arguments: null);

            var consumer = new EventingBasicConsumer(channel);
            consumer.Received += (model, ea) =>
            {
                byte[] body = ea.Body.ToArray();
                var jsonMessage = Encoding.UTF8.GetString(body);
                Tender tenderResponse;
                tenderResponse = JsonConvert.DeserializeObject<Tender>(jsonMessage);

                Console.WriteLine(" [x] Received \n\tDescription: {0}", tenderResponse.Description);
                using (var scope = Services.CreateScope())
                {
                    var tenderRepository =
                        scope.ServiceProvider
                            .GetRequiredService<ITenderRepository>();

                    tenderRepository.Add(tenderResponse);
                    tenderRepository.Save();
                }
            };
            channel.BasicConsume(queue: "tenderResponse",
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
