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
            var factory = new ConnectionFactory() { HostName = Environment.GetEnvironmentVariable("RABBITMQ_HOST") ?? "localhost", Port = 5672 };

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
                Console.WriteLine(" [x] Received \n\tId: {0}\n\tDate Range: {1} - {2}\n\tDescription: {3}", tender.Id, tender.DateRange.Start.ToShortDateString(),
                                    tender.DateRange.End.ToShortDateString(), tender.Description);

                using (var scope = Services.CreateScope())
                {
                    var tenderRepository =
                        scope.ServiceProvider
                            .GetRequiredService<ITenderRepository>();

                    tenderRepository.Add(tender);
                    tenderRepository.Save();
                    SendTenderResponse(tender);
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

        private void SendTenderResponse(Tender tender)
        {
            TenderResponse tenderResponse;
            using (var scope = Services.CreateScope())
            {
                var tenderResponseService = scope.ServiceProvider
                            .GetRequiredService<ITenderResponseService>();
                tenderResponse = tenderResponseService.CreateResponseFromTender(tender);
                tenderResponseService.Add(tenderResponse);
            }

            var factory = new ConnectionFactory() { HostName = "localhost" };

            using (var connection = factory.CreateConnection())
            using (var channel = connection.CreateModel())
            {
                channel.QueueDeclare(queue: "tenderResponse",
                                        durable: false,
                                        exclusive: false,
                                        autoDelete: false,
                                        arguments: null);

                var body = Encoding.UTF8.GetBytes(JsonConvert.SerializeObject(tenderResponse));

                channel.BasicPublish(exchange: "",
                                        routingKey: "tenderResponse",
                                        basicProperties: null,
                                        body: body);
                Console.WriteLine(" [x] Sent \n\tDescription: {0}", tenderResponse.Description);
                
            }
        }
    }
}
