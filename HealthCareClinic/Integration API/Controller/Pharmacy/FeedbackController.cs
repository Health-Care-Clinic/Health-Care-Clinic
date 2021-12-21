using System.Collections.Generic;
using Integration.Adapter;
using Integration.ApiKeys.Model;
using Integration.DTO;
using Integration.Interface.Service;
using Integration.Pharmacy.Model;
using Microsoft.AspNetCore.Mvc;
using RestSharp;

namespace Integration_API.Controller.Pharmacy
{
    [Route("hospital/[controller]")]
    [ApiController]
    public class FeedbackController : ControllerBase
    {
        private readonly IFeedbackService _feedbackService;
        private readonly IFeedbackReplyService _feedbackReplyService;
        private readonly IApiKeyService _apiKeyService;

        public FeedbackController(IFeedbackService feedbackService, IFeedbackReplyService feedbackReplyService, 
            IApiKeyService apiKeyService)
        {
            _feedbackService = feedbackService;
            _feedbackReplyService = feedbackReplyService;
            _apiKeyService = apiKeyService;
        }

        [HttpGet]
        public IActionResult Get()
        {
            List<Feedback> feedbacks = (List<Feedback>)_feedbackService.GetAll();
            return Ok(feedbacks);
        }

        [HttpGet("{id?}")]
        public IActionResult GetFeedbacksByHospitalId(int id)
        {
            Feedback feedback = _feedbackService.GetFeedbackBySenderId(id);
            if (feedback == null)
            {
                return NotFound();
            }
            
            return Ok(_feedbackService.GetFeedbacksWithReply(id));
        }

        [HttpPost]
        public IActionResult GiveFeedback(FeedbackDTO dto)
        {
            if (dto.Text.Length <= 0)
            {
                return BadRequest();
            }

            ApiKey apiKey = _apiKeyService.GetOneById(dto.ReceiverId);

            if (apiKey == null)
            {
                return NotFound();
            }

            Feedback newFeedback = FeedbackAdapter.FeedbackDtoToFeedback(dto);
            _feedbackService.Add(newFeedback);
            _feedbackService.SaveChanges();
            
            var client = new RestSharp.RestClient(apiKey.BaseUrl);
            var request = new RestRequest("benu/feedback/receive");
            request.AddJsonBody(FeedbackAdapter.FeedbackToFeedbackDto(newFeedback));
            IRestResponse response = client.Post(request);

            return Ok("success");
        }
    }
}
