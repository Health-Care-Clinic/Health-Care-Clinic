using Integration;
using Integration.Pharmacy.Model;
using Integration_API.Adapter;
using Integration_API.DTO;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

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
            List<FeedbackDTO> feedbacks = new List<FeedbackDTO>();
            _dbContext.Feedbacks.ToList().ForEach(feedback => feedbacks.Add(FeedbackAdapter.FeedbackToFeedbackDto(feedback)));
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

            return Ok("success");
        }
    }
}
