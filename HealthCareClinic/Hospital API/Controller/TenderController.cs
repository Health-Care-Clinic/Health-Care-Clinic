﻿using Hospital.Tendering.Model;
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
using RestSharp;
using Hospital.Medicines.Service;

namespace Hospital_API.Controller
{
    [Route("api/[controller]")]
    [ApiController]
    public class TenderController : ControllerBase
    {
        private readonly ITenderService _tenderService;
        private readonly ITenderResponseService _tenderResponseService;
        private readonly IMedicineService _medicineService;
        private MailService mailService = new MailService();

        public TenderController(ITenderService tenderService, ITenderResponseService tenderResponseService, IMedicineService medicineService)
        {
            _tenderService = tenderService;
            _tenderResponseService = tenderResponseService;
            _medicineService = medicineService;
        }

        [HttpGet]
        public IActionResult GetAllTenders()
        {
            List<TenderDTO> tendersDTO = TenderAdapter.TendersToTendersDTO((List<Tender>)_tenderService.GetAll());
            foreach (TenderDTO dto in tendersDTO)
            {
                dto.OffersNumber = _tenderResponseService.GetNumberOfOffers(dto.Id);
            }
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
            _tenderService.Add(tender);

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
                
            }
            return Ok();
        }

        [HttpPost("{tenderResponseId?}")]
        public IActionResult ChooseTenderResponse(int tenderResponseId)
        {
            TenderResponse winningTenderResponse = _tenderResponseService.GetOneById(tenderResponseId);
            ICollection<TenderResponse> tenderResponses = _tenderResponseService.GetTenderResponsesByTenderId(winningTenderResponse.TenderId);
            winningTenderResponse.IsWinningBid = true;
            _tenderResponseService.Update(winningTenderResponse);
            foreach(TenderResponse tenderResponse in tenderResponses)
            {
                if (tenderResponse.Id == winningTenderResponse.Id)
                {
                    var client = new RestClient(GetPharmacyUrl(tenderResponse.PharmacyName));
                    var request = new RestRequest("benu/tender/outcome");
                    request.AddJsonBody(tenderResponse);
                    IRestResponse response = client.Post(request);
                    foreach (TenderItem tenderItem in tenderResponse.TenderItems)
                        _medicineService.AddMedicine(tenderItem.Name, tenderItem.Quantity.ToString());
                }
                else
                {
                    var client = new RestClient(GetPharmacyUrl(tenderResponse.PharmacyName));
                    var request = new RestRequest("benu/tender/outcome");
                    request.AddJsonBody(tenderResponse);
                    IRestResponse response = client.Post(request);
                }
            }
            mailService.SendEmail();
            return Ok("success");
        }

        // change
        [HttpGet("pharmacyNames")]
        public IActionResult GetPharmacyNames(string startDate, string endDate)
        {
            return(Ok(_tenderResponseService.GetPharmacyNames(startDate, endDate)));
        }

        // change
        [HttpGet("numberOfWins")]
        public IActionResult GetNumberOfWins(string startDate, string endDate)
        {
            return (Ok(_tenderResponseService.GetNumberOfWins(startDate, endDate)));
        }

        // change
        [HttpGet("numberOfOffers")]
        public IActionResult GetNumberOfOffers(string startDate, string endDate)
        {
            return (Ok(_tenderResponseService.GetNumberOfOffers(startDate, endDate)));
        }

        // change
        [HttpGet("bestOffers")]
        public IActionResult GetBestOffers(string startDate, string endDate)
        {
            return (Ok(_tenderResponseService.GetBestOffers(startDate, endDate)));
        }

        [HttpGet("tenderResponses")]
        public IActionResult GetTenderResponsesById(String tenderId)
        {
            List<TenderResponseDTO> responsesDTO = 
                TenderAdapter.TenderResponsesToTenderResponsesDTO((List<TenderResponse>)_tenderResponseService.GetTenderResponsesByTenderId(Int32.Parse(tenderId)));
            return (Ok(responsesDTO));
        }


        private string GetPharmacyUrl(string pharmacyName)
        {
            return "http://localhost:18089";
        }

        [HttpGet("pharmacyParticipations/{name?}")]
        public IActionResult pharmacyParticipations(String name)
        {
            return (Ok(_tenderResponseService.GetTendersNumberParticipatedByPharmacy(name)));
        }

        [HttpGet("pharmacyWins/{name?}")]
        public IActionResult pharmacyWins(String name)
        {
            return (Ok(_tenderResponseService.GetTendersNumberWonByPharmacy(name)));
        }

        [HttpGet("TenderOffersNumber/{idt?}")]
        public IActionResult offersNumber(int idt)
        {
            return (Ok(_tenderResponseService.GetOffersNumberByTender(idt)));
        }

        [HttpGet("PharmacyOffersForTender/{name?}/{idt?}")]
        public IActionResult pharmacyOffers(String name, int idt)
        {
            return (Ok(_tenderResponseService.GetOfferByTender(idt, name)));
        }

        [HttpPost("send")]
        public IActionResult SendEmail()
        {
            mailService.SendEmail();
            return (Ok());
        }
    }
}
