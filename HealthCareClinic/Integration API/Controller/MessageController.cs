using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Integration;
using Integration.ApiKeys.Model;
using Integration.DTO;
using Microsoft.AspNetCore.Mvc;
using RestSharp;

namespace Integration_API.Controller
{
    [ApiController]
    [Route("hospital/[controller]")]
    public class MessageController : ControllerBase
    {
        private readonly IntegrationDbContext _dbContext;

        public MessageController(IntegrationDbContext dbContext)
        {
            _dbContext = dbContext;
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
            ApiKey apiKey = _dbContext.ApiKeys.FirstOrDefault(apiKey => apiKey.Name.Equals(to));
            var url = $"{this.Request.Scheme}://{this.Request.Host}{this.Request.PathBase}";
            ApiKey myApiKey = _dbContext.ApiKeys.FirstOrDefault(apiKey => apiKey.BaseUrl.Equals(url));

            if (apiKey == null)
            {
                return BadRequest();
            }

            var client = new RestSharp.RestClient(apiKey.BaseUrl);
            var request = new RestRequest("benu/message");
            request.AddJsonBody(toSend);
            request.AddHeader("ApiKey", myApiKey.Key);
            IRestResponse response = client.Post(request);

            _dbContext.Messages.Add(new Message("Hospital", message, to));
            _dbContext.SaveChanges();

            return Ok("successfully sent");
        }


        [HttpPost]
        public IActionResult ReceiveMessage(MessageDTO dto)
        {
            if (!Request.Headers.TryGetValue("ApiKey", out var headerApiKey))
            {
                return BadRequest("Api key was not provided!");
            }

            ApiKey apiKey = _dbContext.ApiKeys.FirstOrDefault(apiKey => apiKey.Key.Equals(headerApiKey));

            if (apiKey.Name == null)
            {
                return BadRequest("Api key is not valid!");
            }

            if (dto.MessageText.Length <= 0)
            {
                return BadRequest();
            }

            _dbContext.Messages.Add(new Message(apiKey.Name, dto.MessageText, "Hospital"));
            _dbContext.SaveChanges();

            return Ok("success");
        }
    }
}
