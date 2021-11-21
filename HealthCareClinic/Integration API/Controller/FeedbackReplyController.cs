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

namespace Integration_API.Controller
{
    [Route("hospital/[controller]")]
    [ApiController]
    public class FeedbackReplyController : ControllerBase
    {
        private readonly IntegrationDbContext _dbContext;

        public FeedbackReplyController(IntegrationDbContext integrationDbContext)
        {
            _dbContext = integrationDbContext;
        }

        [HttpPost("receive")]
        public IActionResult ReceiveFeedbackReply(FeedbackReplyDTO dto)
        {
            if (dto.Text.Length <= 0)
            {
                return BadRequest();
            }

            FeedbackReply receivedFeedbackReply = FeedbackReplyAdapter.FeedbackReplyDtoToFeedbackReply(dto);

            _dbContext.FeedbackReplies.Add(receivedFeedbackReply);
            _dbContext.SaveChanges();

            return Ok("success");
        }

        [HttpGet]
        public IActionResult Get()
        {
            return Ok("radi");
        }
    }
}
