using System;
using System.Text;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using Pharmacy;
using Pharmacy.ApiKeys.Model;
using Pharmacy.Interfaces.Service;
using Pharmacy.Promotions.Model;
using RabbitMQ.Client;

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
