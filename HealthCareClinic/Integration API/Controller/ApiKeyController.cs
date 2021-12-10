using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ClinicCore.DTOs;
using Integration;
using Integration.Adapter;
using Integration.ApiKeys.Model;
using Integration.DTO;
using Integration.Interface.Service;
using Integration.Service;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;
using RestSharp;

namespace Integration_API.Controller
{
    [ApiController]
    [Route("hospital/[controller]")]
    public class ApiKeyController : ControllerBase
    {
        private readonly IntegrationDbContext _dbContext;
        private readonly IApiKeyService _apiKeyService;
        private readonly IMessageService _messageService;

        public ApiKeyController(IntegrationDbContext integrationDbContext, IApiKeyService apiKeyService,
            IMessageService messageService)
        {
            _dbContext = integrationDbContext;
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
            var request = new RestRequest("benu/apikey/receive");
            request.AddJsonBody(ApiKeyAdapter.ApiKeyToApiKeyDto(newApiKey));
            IRestResponse response = client.Post(request);

            return Ok();
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

        [HttpGet("pharmacies")]
        public IActionResult GetPharmacies()
        {
            List<PharmacyDTO> pharmacies = new List<PharmacyDTO>();
            _dbContext.ApiKeys.Where(apiKey => apiKey.Category.Equals("Pharmacy")).ToList().ForEach(apiKey => pharmacies.Add(ApiKeyAdapter.ApiKeyToPharmacyDto(apiKey)));
            return Ok(pharmacies);
        }

        [HttpGet("pharmacy-profiles")]
        public IActionResult GetPharmacyProfiles()
        {
            var pharmacies = _apiKeyService.GetAll();
            return Ok(pharmacies);
        }

        [HttpGet("pharmacy-profiles/{id?}")]
        public IActionResult GetPharmacyProfile(int id)
        {
            var pharmacy = _apiKeyService.GetOneById(id);
            return Ok(pharmacy);
        }

        [HttpPut("pharmacy-profiles")]
        public IActionResult EditPharmacyProfile(ApiKey ak)
        {
            var pharmacy = _apiKeyService.EditPharmacyProfile(ak);
            return Ok(pharmacy);
        }
    }
}
