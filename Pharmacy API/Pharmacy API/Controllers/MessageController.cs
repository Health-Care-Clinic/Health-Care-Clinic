using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Pharmacy;
using Pharmacy.Model;
using Pharmacy_API.DTO;
using RestSharp;

namespace Pharmacy_API.Controllers
{
    [ApiController]
    [Route("benu/[controller]")]
    public class MessageController : ControllerBase
    {
        private readonly PharmacyDbContext _dbContext;

        public MessageController(PharmacyDbContext dbContext)
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
            var request = new RestRequest("hospital/message");
            request.AddJsonBody(toSend);
            request.AddHeader("ApiKey", myApiKey.Key);
            IRestResponse response = client.Post(request);

            _dbContext.Messages.Add(new Message("Benu", message, to));
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

            _dbContext.Messages.Add(new Message(apiKey.Name, dto.MessageText, "Benu"));
            _dbContext.SaveChanges();

            return Ok("success");
        }
    }
}
