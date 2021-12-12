using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Integration;
using Integration.ApiKeys.Model;
using Integration.DTO;
using Integration.Interface.Service;
using Microsoft.AspNetCore.Mvc;
using RestSharp;

namespace Integration_API.Controller
{
    [ApiController]
    [Route("hospital/[controller]")]
    public class MessageController : ControllerBase
    {
        private readonly IMessageService _messageService;
        private readonly IApiKeyService _apiKeyService;

        public MessageController(IMessageService messageService, IApiKeyService apiKeyService)
        {
            _messageService = messageService;
            _apiKeyService = apiKeyService;
        }

        [HttpGet]
        public IActionResult Get()
        {
            return Ok();
        }

        [HttpGet("send")]
        public IActionResult SendMessage(string to, string message)
        {
            MessageDTO toSend = new MessageDTO(message);
            ApiKey apiKey = _apiKeyService.GetApiKeyByName(to);
            var url = $"{this.Request.Scheme}://{this.Request.Host}{this.Request.PathBase}";
            ApiKey myApiKey = _apiKeyService.GetMyApiKey(url);

            if (apiKey == null)
            {
                return BadRequest();
            }

            var client = new RestSharp.RestClient(apiKey.BaseUrl);
            var request = new RestRequest("benu/message");
            request.AddJsonBody(toSend);
            request.AddHeader("ApiKey", myApiKey.Key);
            IRestResponse response = client.Post(request);

            _messageService.SendMessage(message, to);

            return Ok("successfully sent");
        }


        [HttpPost]
        public IActionResult ReceiveMessage(MessageDTO dto)
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

            return Ok("success");
        }
    }
}
