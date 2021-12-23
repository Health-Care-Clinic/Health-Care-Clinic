using Hospital.Tendering.Model;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using RabbitMQ.Client;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hospital_API.Controller
{
    [Route("api/[controller]")]
    [ApiController]
    public class TenderController : ControllerBase
    {
        [HttpPost]
        public IActionResult ReceiveFeedback(Tender tender)
        {
            tender = new Tender(null, new Price(500), new DateRange(DateTime.Now, DateTime.Now.AddDays(7)), "Test slanja tendera.");
            var factory = new ConnectionFactory() { HostName = "localhost" };

            using (var connection = factory.CreateConnection())
            using (var channel = connection.CreateModel())
            {
                channel.QueueDeclare(queue: "tender",
                                        durable: false,
                                        exclusive: false,
                                        autoDelete: false,
                                        arguments: null);

                var body = Encoding.UTF8.GetBytes(JsonConvert.SerializeObject(tender));

                channel.BasicPublish(exchange: "",
                                        routingKey: "tender",
                                        basicProperties: null,
                                        body: body);
                Console.WriteLine(" [x] Sent {0}", tender.TenderResponseDescription);
            }
            return Ok("success");
        }
    }
}
