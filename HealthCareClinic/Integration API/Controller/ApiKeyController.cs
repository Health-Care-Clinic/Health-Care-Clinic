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
    [Route("api/[controller]")]
    public class ApiKeyController : ControllerBase
    {
        private readonly IntegrationDbContext _dbContext;

        public ApiKeyController(IntegrationDbContext integrationDbContext)
        {
            _dbContext = integrationDbContext;
        }


        [HttpPost]
        public IActionResult Add(ApiKeyDTO dto)
        {

            ApiKey apiKey = ApiKeyAdapter.ApiKeyDtoToApiKey(dto);
            Guid g = Guid.NewGuid();
            apiKey.Key = g.ToString();

            _dbContext.ApiKeys.Add(apiKey);
            _dbContext.SaveChanges();

            return Ok(this.SendApiKey(apiKey.Name, apiKey.Key));
        }

        [HttpGet("send")]
        public IActionResult SendApiKey(String to, String message)
        {
            
            ApiKey apiKey = _dbContext.ApiKeys.FirstOrDefault(apiKey => apiKey.Name.Equals(to));
            message = apiKey.Key;
            MessageDTO toSend = new MessageDTO(message);

            //var client = new RestSharp.RestClient(apiKey.BaseUrl);
            //var request = new RestRequest(apiKey.Name.ToLower() + "/message");
            //request.AddJsonBody(toSend);
            //IRestResponse response = client.Post(request);

            _dbContext.Messages.Add(new Message("Hospital", message, to));
            _dbContext.SaveChanges();

            return Ok();
        }

        [HttpGet]
        public IActionResult Get()
        {
            return Ok();
        }
    }
}
