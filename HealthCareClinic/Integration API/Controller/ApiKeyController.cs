using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ClinicCore.DTOs;
using Integration;
using Integration.ApiKeys.Model;
using Integration.ApiKeys.Model;
using Integration.ApiKeys.Service;
using Integration_API.Adapter;
using Integration_API.DTO;
using Microsoft.AspNetCore.Mvc;
using RestSharp;

namespace Integration_API.Controller
{
    [ApiController]
    [Route("hospital/[controller]")]
    public class ApiKeyController : ControllerBase
    {
        private readonly IntegrationDbContext _dbContext;

        public ApiKeyController(IntegrationDbContext integrationDbContext)
        {
            _dbContext = integrationDbContext;
        }


        [HttpPost]
        public IActionResult Register(ApiKeyDTO dto)
        {
            if (dto.Name.Length <= 0 || dto.BaseUrl.Length <= 0)
            {
                return BadRequest();
            }

            ApiKey apiKey = _dbContext.ApiKeys.SingleOrDefault(apiKey => apiKey.BaseUrl == dto.BaseUrl);

            if (apiKey != null)
            {
                return BadRequest("Already exists!");
            }

            ApiKey newApiKey = ApiKeyAdapter.ApiKeyDtoToApiKey(dto);
            Guid g = Guid.NewGuid();
            newApiKey.Key = g.ToString();
            newApiKey.Category = "Pharmacy";

            _dbContext.ApiKeys.Add(newApiKey);
            _dbContext.SaveChanges();

            String message = newApiKey.Key;
            _dbContext.Messages.Add(new Message("Hospital", message, newApiKey.Name));
            _dbContext.SaveChanges();

            
            var client = new RestSharp.RestClient(newApiKey.BaseUrl);
            var request = new RestRequest("benu/apikey/receive");
            newApiKey.Name = "Hospital";
            newApiKey.BaseUrl = $"{this.Request.Scheme}://{this.Request.Host}";
            newApiKey.Category = "Hospital";
            request.AddJsonBody(ApiKeyAdapter.ApiKeyToApiKeyDto(newApiKey));
            IRestResponse response = client.Post(request);

            return Ok("success");
        }

        [HttpPost("receive")]
        public IActionResult ReceiveApiKey(ApiKeyDTO dto)
        {
            if (dto.Key.Length <= 0 || dto.Name.Length <= 0)
            {
                return BadRequest();
            }

            var url = $"{this.Request.Scheme}://{this.Request.Host}{this.Request.PathBase}";

            ApiKey receivedApiKey = ApiKeyAdapter.ApiKeyDtoToApiKey(dto);

            _dbContext.ApiKeys.Add(receivedApiKey);
            _dbContext.SaveChanges();

            return Ok("success");
        }


        [HttpGet]
        public IActionResult Get()
        {
            return Ok("radi");
        }

        [HttpGet("pharmacies")]
        public IActionResult GetPharmacies()
        {
            List<ApiKeyDTO> pharmacies = new List<ApiKeyDTO>();
            _dbContext.ApiKeys.Where(apiKey => apiKey.Category.Equals("Pharmacy")).ToList().ForEach(apiKey => pharmacies.Add(ApiKeyAdapter.ApiKeyToApiKeyDto(apiKey)));
            return Ok(pharmacies);
        }
    }
}
