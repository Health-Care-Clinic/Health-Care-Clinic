using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using Pharmacy.Interfaces.Service;
using Pharmacy.Tendering.Model;
using Pharmacy_API.Adapter;
using Pharmacy_API.DTO;
using RabbitMQ.Client;
using System;
using System.Collections.Generic;
using System.Text;

namespace Pharmacy_API.Controllers.Tendering
{
    [ApiController]
    [Route("benu/[controller]")]
    public class TenderController : ControllerBase
    {
        private readonly ITenderService _tenderService;
        private readonly ITenderResponseService _tenderResponseService;

        public TenderController(ITenderService tenderService, ITenderResponseService tenderResponseService)
        {
            _tenderService = tenderService;
            _tenderResponseService = tenderResponseService;
        }

        [HttpGet]
        public IActionResult GetAllTenders()
        {
            return Ok((List<Tender>)_tenderService.GetAll());
        }

        [HttpGet("responses")]
        public IActionResult GetAllResponses()
        {
            return Ok((List<TenderResponse>)_tenderResponseService.GetAll());
        }

        [HttpPost]
        public IActionResult HospitalTenderRequest(Tender tender)
        {
            TenderResponse tenderResponse = _tenderResponseService.CreateResponseFromTender(tender);

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
                _tenderResponseService.Add(tenderResponse);
            }
            return Ok("success");
        }

        [HttpPost("outcome")]
        public IActionResult TenderOutcome([FromBody] TenderResponse tenderResponse)
        {
            if (tenderResponse.IsWinningBid)
            {
                _tenderResponseService.UpdateByTenderId(tenderResponse);
                Console.WriteLine("Vasa ponuda je prihvacena.");
            }
            else
            {
                Console.WriteLine("Nazalost ste izgubili.");
            }
            return Ok("success");
        }
    }
}
