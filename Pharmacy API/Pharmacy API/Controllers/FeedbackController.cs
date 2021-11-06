using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Pharmacy;
using Pharmacy.Model;
using Pharmacy_API.Adapter;
using Pharmacy_API.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Pharmacy_API.Controllers
{
    [Route("benu/[controller]")]
    [ApiController]
    public class FeedbackController : ControllerBase
    {
        private readonly PharmacyDbContext _dbContext;

        public FeedbackController(PharmacyDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        [HttpPost("receive")]
        public IActionResult ReceiveFeedback(FeedbackDTO dto)
        {
            if (dto.Text.Length <= 0)
            {
                return BadRequest();
            }

            Feedback receivedFeedback = FeedbackAdapter.FeedbackDtoToFeedback(dto);

            _dbContext.Feedbacks.Add(receivedFeedback);
            _dbContext.SaveChanges();

            return Ok("success");
        }
    }
}
