using Hospital.Tendering.Model;
using Hospital.Tendering.Service;
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
        private readonly ITenderService _tenderService;

        public TenderController(ITenderService tenderService)
        {
            _tenderService = tenderService;
        }

        [HttpGet]
        public IActionResult GetAllTenders()
        {
            List<Tender> tenders = (List<Tender>)_tenderService.GetAll();
            return Ok(tenders);
        }

        [HttpPost]
        public IActionResult SendTender(Tender tender)
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
                Console.WriteLine(" [x] Sent \n\tPrice: {0}\n\tDate Range: {1} - {2}\n\tDescription: {3}", tender.TotalPrice.Amount, tender.DateRange.Start.ToShortDateString(),
                    tender.DateRange.End.ToShortDateString(), tender.TenderResponseDescription);
                _tenderService.Add(tender);
            }
            return Ok("success");
        }
    }
}
