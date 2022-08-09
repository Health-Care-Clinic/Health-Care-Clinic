using Microsoft.AspNetCore.Mvc;
using Pharmacy.Adapter;
using Pharmacy.DTO;
using Pharmacy.Feedbacks.Model;
using Pharmacy.Interfaces.Service;

namespace Pharmacy_API.Controllers.Feedbacks
{
    [Route("benu/[controller]")]
    [ApiController]
    public class FeedbackController : ControllerBase
    {
        private readonly IFeedbackService _feedbackService;

        public FeedbackController(IFeedbackService feedbackService)
        {
            _feedbackService = feedbackService;
        }

        [HttpPost("receive")]
        public IActionResult ReceiveFeedback(FeedbackDTO dto)
        {
            if (dto.Text.Length <= 0)
            {
                return BadRequest();
            }

            Feedback receivedFeedback = FeedbackAdapter.FeedbackDtoToFeedback(dto);

            _feedbackService.Add(receivedFeedback);
            _feedbackService.SaveChanges();

            return Ok("success");
        }
    }
}
