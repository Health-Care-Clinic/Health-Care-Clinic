using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Pharmacy;
using Pharmacy.Model;
using RestSharp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Pharmacy.Adapter;
using Pharmacy.DTO;

namespace Pharmacy_API.Controllers
{
    [Route("benu/[controller]")]
    [ApiController]
    public class FeedbackReplyController : ControllerBase
    {
        private readonly PharmacyDbContext _dbContext;

        public FeedbackReplyController(PharmacyDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        [HttpPost]
        public IActionResult SendFeedbackReply(FeedbackReplyDTO dto)
        {
            if (dto.Text.Length <= 0)
            {
                return BadRequest();
            }

            FeedbackReply newFeedbackReply = FeedbackReplyAdapter.FeedbackReplyDtoToFeedbackReply(dto);

            _dbContext.FeedbackReplies.Add(newFeedbackReply);
            _dbContext.SaveChanges();

            ApiKey apiKey = _dbContext.ApiKeys.SingleOrDefault(apiKey => apiKey.Id == newFeedbackReply.ReceiverId);

            var client = new RestSharp.RestClient(apiKey.BaseUrl);
            var request = new RestRequest("hospital/feedbackreply/receive");
            request.AddJsonBody(FeedbackReplyAdapter.FeedbackReplyToFeedbackReplyDto(newFeedbackReply));
            IRestResponse response = client.Post(request);

            return Ok("success");
        }
    }
}
