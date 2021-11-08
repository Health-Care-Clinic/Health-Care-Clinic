using ClinicCore.Model;
using Hospital.Mapper;
using Hospital_API.Adapter;
using Hospital_API.DTO;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Hospital_API.Controller.FeedbacksController
{
    [Route("api/[controller]")]
    [ApiController]
    public class FeedbackMessageController : ControllerBase
    {
        private readonly HospitalDbContext dbContext;

        public FeedbackMessageController(HospitalDbContext context)
        {
            dbContext = context;
        }

        [HttpGet]       // GET /api/feedbackMessage
        public IActionResult Get()
        {
            List<FeedbackMessageDTO> result = new List<FeedbackMessageDTO>();
            dbContext.FeedbackMessages.ToList().ForEach(feedbackMessage
                => result.Add(FeedbackMessageAdapter.FeedbackMessageToFeedbackMessageDTO(feedbackMessage)));
            return Ok(result);
        }

        [HttpGet("published")]       // GET /api/feedbackMessage/published
        public IActionResult GetPublished()
        {
            List<FeedbackMessage> feedbackMessages = dbContext.FeedbackMessages.Where(feedbackMessage => feedbackMessage.IsPublished == true).ToList();
            List<FeedbackMessageDTO> result = new List<FeedbackMessageDTO>();
            feedbackMessages.ForEach(FeedbackMessage
                => result.Add(FeedbackMessageAdapter.FeedbackMessageToFeedbackMessageDTO(FeedbackMessage)));
            return Ok(result);
        }

        [HttpPost("submit")]      // POST /api/feedbackMessage/submit
        public IActionResult SubmitFeedback(FeedbackMessageDTO dto)
        {
            if (dto.Text == "" || dto.Id < 0)
                return BadRequest();

            FeedbackMessage feedback = FeedbackMessageAdapter.FeedbackMessageDTOToFeedbackMessage(dto);
            dbContext.FeedbackMessages.Add(feedback);
            dbContext.SaveChanges();
            return Ok();
        }
    }
}
