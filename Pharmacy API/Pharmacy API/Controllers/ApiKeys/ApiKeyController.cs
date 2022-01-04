using Microsoft.AspNetCore.Mvc;
using Pharmacy.Adapter;
using Pharmacy.ApiKeys.Model;
using Pharmacy.DTO;
using Pharmacy.Interfaces.Service;
using RestSharp;

namespace Pharmacy_API.Controllers.ApiKeys
{
    [ApiController]
    [Route("benu/[controller]")]
    public class ApiKeyController : ControllerBase
    {
        private readonly IApiKeyService _apiKeyService;
        private readonly IMessageService _messageService;

        public ApiKeyController(IApiKeyService apiKeyService, IMessageService messageService)
        {
            _apiKeyService = apiKeyService;
            _messageService = messageService;
        }

        [HttpPost]
        public IActionResult Register(ApiKeyDTO dto)
        {
            if (dto.Name.Length <= 0 || dto.BaseUrl.Length <= 0)
            {
                return BadRequest();
            }

            ApiKey newApiKey = _apiKeyService.CreateApiKey(dto);
            _messageService.SendMessage(newApiKey.Key, newApiKey.Name);

            var client = new RestSharp.RestClient(newApiKey.BaseUrl);
            var request = new RestRequest("hospital/apikey/receive");
            request.AddJsonBody(ApiKeyAdapter.ApiKeyToApiKeyDto(newApiKey));
            IRestResponse response = client.Post(request);

            return Ok("Successfully registered!");
        }

        [HttpPost("receive")]
        public IActionResult ReceiveApiKey(ApiKeyDTO dto)
        {
            if (dto.Key.Length <= 0 || dto.Name.Length <= 0)
            {
                return BadRequest();
            }
            _apiKeyService.ReceiveApiKey(dto);
            return Ok("success");
        }

        [HttpGet]
        public IActionResult Get()
        {
            return Ok("success");
        }
    }
}
