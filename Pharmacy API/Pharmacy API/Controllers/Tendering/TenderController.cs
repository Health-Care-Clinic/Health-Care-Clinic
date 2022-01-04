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
    public class TenderController: ControllerBase
    {
        private readonly ITenderService _tenderService;
       
        public TenderController(ITenderService tenderService)
        {
            _tenderService = tenderService;
          
        }

        [HttpGet]
        public IActionResult GetAllTenders()
        {
            List<Tender> tenders = new List<Tender>();
            foreach (var tender in (List<Tender>)_tenderService.GetAll())
            {
                if (tender.TenderResponseDescription == null)
                {
                    tenders.Add(tender);
                }
            }

            //List<TenderDTO> tendersDTO = TenderAdapter.TendersToTendersDTO(tenders);

            return Ok(tenders);
        }

        [HttpGet("responses")]
        public IActionResult GetAllResponses()
        {
            List<Tender> responses = new List<Tender>();
            foreach (var tender in (List<Tender>)_tenderService.GetAll())
            {
                if (tender.TenderResponseDescription != null)
                {
                    responses.Add(tender);
                }
            }

            //List<TenderDTO> tendersDTO = TenderAdapter.TendersToTendersDTO(responses);

            return Ok(responses);
        }

        [HttpPost]
        public IActionResult HospitalTenderRequest(Tender tender)
        {
            Tender tenderResponse = _tenderService.GetDataForTender(tender);

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
                Console.WriteLine(" [x] Sent \n\tDescription: {0}", tenderResponse.TenderResponseDescription);
                _tenderService.Add(tenderResponse);
            }
            return Ok("success");
        }
    }
}
