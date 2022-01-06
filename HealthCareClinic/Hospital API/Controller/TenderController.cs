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
using Hospital_API.Adapter;
using Hospital_API.DTO;

namespace Hospital_API.Controller
{
    [Route("api/[controller]")]
    [ApiController]
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
            List<TenderDTO> tendersDTO = TenderAdapter.TendersToTendersDTO((List<Tender>)_tenderService.GetAll());

            return Ok(tendersDTO);
        }

        [HttpGet("responses")]
        public IActionResult GetAllResponses()
        {
            return Ok(_tenderResponseService.GetAll());
        }

        [HttpPost]
        public IActionResult SendTender(TenderDTO dto)
        {
            Tender tender = TenderAdapter.TenderDTOToTender(dto);
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
                
                Console.WriteLine(" [x] Sent \n\tDate Range: {0} - {1}\n\tDescription: {2}", tender.DateRange.Start.ToShortDateString(),
                    tender.DateRange.End.ToShortDateString(), tender.Description);
                _tenderService.Add(tender);
                
            }
            return Ok("success");
        }
    }
}
