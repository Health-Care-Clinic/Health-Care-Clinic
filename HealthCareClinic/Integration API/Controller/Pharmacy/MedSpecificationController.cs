using System;
using Integration.ApiKeys.Model;
using Integration.DTO;
using Integration.Interface.Service;
using Integration.Service;
using Microsoft.AspNetCore.Mvc;
using RestSharp;

namespace Integration_API.Controller.Pharmacy
{
    [ApiController]
    [Route("hospital/[controller]")]
    public class MedSpecificationController : ControllerBase
    {
        private readonly FileTransferService _fileTransferService;
        private readonly IApiKeyService _apiKeyService;
        private readonly IMessageService _messageService;
        public MedSpecificationController(IApiKeyService apiKeyService, IMessageService messageService)
        {
            _fileTransferService = new FileTransferService();
            _apiKeyService = apiKeyService;
            _messageService = messageService;
        }

        [HttpGet("send/spec")]
        public IActionResult SendSpecRequest(string to, string message)
        {
            MessageDTO toSend = new MessageDTO(message);
            ApiKey apiKey = _apiKeyService.GetApiKeyByName(to);
            string url = $"{this.Request.Scheme}://{this.Request.Host}{this.Request.PathBase}";
            ApiKey myApiKey = _apiKeyService.GetMyApiKey(url);

            _messageService.SendMessage(message, to);

            var client = new RestSharp.RestClient(apiKey.BaseUrl);
            var request = new RestRequest("benu/message/receive/spec");
            request.AddJsonBody(toSend);
            request.AddHeader("ApiKey", myApiKey.Key);
            IRestResponse response = client.Post(request);

            return Ok("Successfully sent!");
        }

        [HttpGet("ftp")]
        public IActionResult DownloadFile(String fileName)
        {
            _fileTransferService.DownloadFile(fileName);
            return Ok();
        }
    }
}
