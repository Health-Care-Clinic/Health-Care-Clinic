using Integration;
using Integration.Pharmacy.Model;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Integration.Adapter;
using Integration.DTO;
using Integration.Interface.Service;

namespace Integration_API.Controller
{
    [Route("hospital/[controller]")]
    [ApiController]
    public class FeedbackReplyController : ControllerBase
    {
        private readonly IFeedbackReplyService _feedbackReplyService;

        public FeedbackReplyController(IFeedbackReplyService feedbackReplyService)
        {
            _feedbackReplyService = feedbackReplyService;
        }

        [HttpPost("receive")]
        public IActionResult ReceiveFeedbackReply(FeedbackReplyDTO dto)
        {
            if (dto.Text.Length <= 0)
            {
                return BadRequest();
            }

            FeedbackReply receivedFeedbackReply = FeedbackReplyAdapter.FeedbackReplyDtoToFeedbackReply(dto);

            _feedbackReplyService.Add(receivedFeedbackReply);
            _feedbackReplyService.SaveChanges();

            return Ok("success");
        }

        [HttpGet]
        public IActionResult Get()
        {
            return Ok("radi");
        }
    }
}
