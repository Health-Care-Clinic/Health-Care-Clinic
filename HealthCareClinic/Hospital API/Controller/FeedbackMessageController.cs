using Hospital.Schedule.Model;
using Hospital.Mapper;
using Hospital.Schedule.Service;
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
        private readonly IFeedbackMessageService feedbackMessageService;

        public FeedbackMessageController(IFeedbackMessageService feedbackMessageService)
        {
            this.feedbackMessageService = feedbackMessageService;
        }

        [HttpGet]       // GET /api/feedbackMessage
        public IActionResult Get()
        {
            List<FeedbackMessage> feedbacks = (List<FeedbackMessage>)feedbackMessageService.GetAll();
            List<FeedbackMessageDTO> result = FeedbackMessageAdapter.FeedbackMessageListToFeedbackMessageDTOList(feedbacks);
            
            return Ok(result);
        }

        [HttpGet("published")]       // GET /api/feedbackMessage/published
        public IActionResult GetPublished()
        {
            List<FeedbackMessage> feedbacks = feedbackMessageService.GetPublished();
            List<FeedbackMessageDTO> result = FeedbackMessageAdapter.FeedbackMessageListToFeedbackMessageDTOList(feedbacks);

            return Ok(result);
        }

        [HttpPut("{id?}")]       // PUT /api/feedbackMessage/id
        public IActionResult ModifyPublishable(int id = 0)
        {
            if (id < 0)
            {
                return BadRequest();    // if any of the values is incorrect return bad request
            }
            FeedbackMessage feedbackMessage = feedbackMessageService.GetOneById(id);
            if (feedbackMessage == null)
            {
                return NotFound();
            }
            else
            {
                feedbackMessageService.ModifyPublishable(id);
                return Ok(FeedbackMessageAdapter.FeedbackMessageToFeedbackMessageDTO(feedbackMessage));
            }
        }

        [HttpPost("submit")]      // POST /api/feedbackMessage/submit
        public IActionResult SubmitFeedback(FeedbackMessageDTO dto)
        {
            if (dto.Text == "" || dto.Id < 0)
                return BadRequest();

            FeedbackMessage feedback = FeedbackMessageAdapter.FeedbackMessageDTOToFeedbackMessage(dto);
            feedbackMessageService.Add(feedback);

            return Ok();
        }
    }
}
