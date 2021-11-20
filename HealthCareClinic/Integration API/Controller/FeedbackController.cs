using Integration;
using Integration.ApiKeys.Model;
using Integration.Pharmacy.Model;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using RestSharp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Integration.Adapter;
using Integration.DTO;

namespace Integration_API.Controller
{
    [Route("hospital/[controller]")]
    [ApiController]
    public class FeedbackController : ControllerBase
    {
        private readonly IntegrationDbContext _dbContext;

        public FeedbackController(IntegrationDbContext integrationDbContext)
        {
            _dbContext = integrationDbContext;
        }

        [HttpGet]
        public IActionResult Get()
        {
            List<Feedback> feedbacks = _dbContext.Feedbacks.ToList();
            return Ok(feedbacks);
        }

        [HttpGet("{id?}")]
        public IActionResult GetFeedbacksByHospitalId(int id)
        {
            Feedback feedback = _dbContext.Feedbacks.FirstOrDefault(feedback => feedback.SenderId == id);
            if (feedback == null)
            {
                return NotFound();
            }
            List<FeedbackDTO> feedbacks = new List<FeedbackDTO>();
            _dbContext.Feedbacks.Where(feedback => feedback.SenderId == id).ToList().ForEach(feedback => feedbacks.Add(FeedbackAdapter.FeedbackToFeedbackDto(feedback)));
            return Ok(feedbacks);
        }

        [HttpPost]
        public IActionResult GiveFeedback(FeedbackDTO dto)
        {
            if (dto.Text.Length <= 0)
            {
                return BadRequest();
            }

            Feedback newFeedback = FeedbackAdapter.FeedbackDtoToFeedback(dto);

            _dbContext.Feedbacks.Add(newFeedback);
            _dbContext.SaveChanges();

            ApiKey apiKey = _dbContext.ApiKeys.SingleOrDefault(apiKey => apiKey.Id == newFeedback.ReceiverId);
            
            var client = new RestSharp.RestClient(apiKey.BaseUrl);
            var request = new RestRequest("benu/feedback/receive");
            request.AddJsonBody(FeedbackAdapter.FeedbackToFeedbackDto(newFeedback));
            IRestResponse response = client.Post(request);

            return Ok("success");
        }
    }
}
