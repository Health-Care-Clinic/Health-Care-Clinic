using Microsoft.AspNetCore.Mvc;
using Pharmacy.Adapter;
using Pharmacy.ApiKeys.Model;
using Pharmacy.DTO;
using Pharmacy.Feedbacks.Model;
using Pharmacy.Interfaces.Service;
using RestSharp;

namespace Pharmacy_API.Controllers.Feedbacks
{
    [Route("benu/[controller]")]
    [ApiController]
    public class FeedbackReplyController : ControllerBase
    {
        private readonly IFeedbackReplyService _feedbackReplyService;
        private readonly IApiKeyService _apiKeyService;

        public FeedbackReplyController(IFeedbackReplyService feedbackReplyService,
            IApiKeyService apiKeyService)
        {
            _feedbackReplyService = feedbackReplyService;
            _apiKeyService = apiKeyService;
        }

        [HttpPost]
        public IActionResult SendFeedbackReply(FeedbackReplyDTO dto)
        {
            if (dto.Text.Length <= 0)
            {
                return BadRequest();
            }

            FeedbackReply newFeedbackReply = FeedbackReplyAdapter.FeedbackReplyDtoToFeedbackReply(dto);

            _feedbackReplyService.Add(newFeedbackReply);
            _feedbackReplyService.SaveChanges();

            ApiKey apiKey = _apiKeyService.GetOneById(newFeedbackReply.ReceiverId);

            var client = new RestSharp.RestClient(apiKey.BaseUrl);
            var request = new RestRequest("hospital/feedbackreply/receive");
            request.AddJsonBody(FeedbackReplyAdapter.FeedbackReplyToFeedbackReplyDto(newFeedbackReply));
            IRestResponse response = client.Post(request);

            return Ok("success");
        }
    }
}
