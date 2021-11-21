using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Pharmacy;
using Pharmacy.DTO;
using Pharmacy.Model;
using Pharmacy.Service;
using RestSharp;

namespace Pharmacy_API.Controllers
{
    [ApiController]
    [Route("benu/[controller]")]
    public class MessageController : ControllerBase
    {
        private readonly FileTransferService _fileTransferService = new FileTransferService();
        private readonly IApiKeyService _apiKeyService;
        private readonly IMessageService _messageService;
        private readonly IMedicineService _medicineService;

        public MessageController(PharmacyDbContext dbContext, IApiKeyService apiKeyService, IMessageService messageService,
            IMedicineService medicineService)
        {
            _apiKeyService = apiKeyService;
            _messageService = messageService;
            _medicineService = medicineService;
        }

        [HttpGet]
        public IActionResult Get()
        {
            return Ok();
        }

        [HttpPost("receive/spec")]
        public IActionResult ReceiveSpecification(MessageDTO dto)
        {
            if (!Request.Headers.TryGetValue("ApiKey", out var headerApiKey))
            {
                return BadRequest("Api key was not provided!");
            }

            ApiKey apiKey = _apiKeyService.GetByKey(headerApiKey);

            if (apiKey.Name == null)
            {
                return BadRequest("Api key is not valid!");
            }

            if (dto.MessageText.Length <= 0)
            {
                return BadRequest();
            }

            Message message = new Message(apiKey.Name, dto.MessageText, "Benu");
            _messageService.ReceiveMessage(message);

            var medToSend = _medicineService.GetByName(dto.MessageText);
            string content = medToSend.Name + ", " + medToSend.Quantity;
            string path =
                "C:\\Users\\PC\\OneDrive\\Desktop\\Health-Care-Clinic\\Pharmacy API\\Pharmacy API\\MedSpecifications\\" + medToSend.Name.ToLower() +".txt";
            _fileTransferService.CreateTxtFile(path, content);
            _fileTransferService.UploadFile(medToSend.Name.ToLower());
            return Ok("success");
        }
    }
}
