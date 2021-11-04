using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Pharmacy;
using Pharmacy.Model;
using Pharmacy_API.Adapter;
using Pharmacy_API.DTO;
using RestSharp;

namespace Pharmacy_API.Controllers
{
    [ApiController]
    [Route("benu/[controller]")]
    public class ApiKeyController : ControllerBase
    {
        private readonly PharmacyDbContext _dbContext;

        public ApiKeyController(PharmacyDbContext dbContext)
        {
            _dbContext = dbContext;
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

            _dbContext.ApiKeys.Add(newApiKey);
            _dbContext.SaveChanges();

            String message = newApiKey.Key;
            _dbContext.Messages.Add(new Message("Benu", message, newApiKey.Name));
            _dbContext.SaveChanges();

            var client = new RestSharp.RestClient(newApiKey.BaseUrl);
            var request = new RestRequest("hospital/apikey/receive");
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
    }
}
