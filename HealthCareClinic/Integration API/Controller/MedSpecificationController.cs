using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Integration;
using Integration.ApiKeys.Model;
using Integration.DTO;
using Integration.Interface.Service;
using Integration.Service;
using Microsoft.AspNetCore.Mvc;
using RestSharp;

namespace Integration_API.Controller
{
    [ApiController]
    [Route("hospital/[controller]")]
    public class MedSpecificationController : ControllerBase
    {
        private readonly IntegrationDbContext _dbContext;
        private readonly FileTransferService _fileTransferService;
        private readonly IApiKeyService _apiKeyService;
        private readonly IMessageService _messageService;
        public MedSpecificationController(IntegrationDbContext dbContext, IApiKeyService apiKeyService, IMessageService messageService)
        {
            _dbContext = dbContext;
            _fileTransferService = new FileTransferService();
            _apiKeyService = apiKeyService;
            _messageService = messageService;
        }

        [HttpGet("specification/{name}")]
        public IActionResult GetSpecification(String name)
        {
            if (System.IO.File.Exists("MedSpecifications" + Path.DirectorySeparatorChar + name + ".txt"))
            {
                new Process()
                {
                    StartInfo = new ProcessStartInfo("MedSpecifications\\" + name + ".txt")
                    {
                        UseShellExecute = true
                    }
                }.Start();
                return StatusCode(200);
            }

            return StatusCode(204);
        }

        // POSALJI ZAHTEV ZA SPECIFIKACIJU LEKA
        [HttpGet("send/spec")]
        public IActionResult SendSpecRequest(string to, string message)
        {
            MessageDTO toSend = new MessageDTO(message);
            ApiKey apiKey = _apiKeyService.GetApiKeyByName(to);
            var url = $"{this.Request.Scheme}://{this.Request.Host}{this.Request.PathBase}";
            ApiKey myApiKey = _apiKeyService.GetMyApiKey(url);

            var client = new RestSharp.RestClient(apiKey.BaseUrl);
            var request = new RestRequest("benu/message/receive/spec");
            request.AddJsonBody(toSend);
            request.AddHeader("ApiKey", myApiKey.Key);
            IRestResponse response = client.Post(request);

            _messageService.SendMessage(message, to);

            return Ok("Successfully sent!");
        }

        // PREUZMI SPECIFIKACIJU SA REBEXA
        [HttpGet("ftp/{fileName}")]
        public IActionResult DownloadFile(String fileName)
        {
            _fileTransferService.DownloadFile(fileName);
            return Ok();
        }
    }
}
