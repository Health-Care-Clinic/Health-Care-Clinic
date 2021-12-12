using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using Pharmacy;
using Pharmacy.Model;
using Pharmacy.Service;
using RabbitMQ.Client;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Pharmacy.ApiKeys.Model;

namespace Pharmacy_API.Controllers
{
    [Route("benu/[controller]")]
    [ApiController]
    public class PharmacyPromotionController : ControllerBase
    {
        private readonly PharmacyDbContext _dbContext;
        private readonly IApiKeyService _apiKeyService;

        public PharmacyPromotionController(PharmacyDbContext dbContext, IApiKeyService apiKeyService)
        {
            _dbContext = dbContext;
            _apiKeyService = apiKeyService;
        }

        [HttpPost]
        public IActionResult ReceiveFeedback(PharmacyPromotion pharmacyPromotion)
        {
            if (pharmacyPromotion.Content.Length <= 0)
            {
                return BadRequest();
            }

            var factory = new ConnectionFactory() { HostName = "localhost" };
            foreach(ApiKey apiKey in _apiKeyService.GetAll())
            {
                using (var connection = factory.CreateConnection())
                using (var channel = connection.CreateModel())
                {
                    channel.QueueDeclare(queue: apiKey.Key,
                                         durable: false,
                                         exclusive: false,
                                         autoDelete: false,
                                         arguments: null);

                    var body = Encoding.UTF8.GetBytes(JsonConvert.SerializeObject(pharmacyPromotion));

                    channel.BasicPublish(exchange: "",
                                         routingKey: apiKey.Key,
                                         basicProperties: null,
                                         body: body);
                    Console.WriteLine(" [x] Sent {0}", pharmacyPromotion.Content);
                }
            }
            return Ok("success");
        }
    }
}
