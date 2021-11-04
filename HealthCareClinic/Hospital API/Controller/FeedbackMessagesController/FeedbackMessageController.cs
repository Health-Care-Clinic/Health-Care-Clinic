using ClinicCore.Model;
using Hospital.Mapper;
using Hospital_API.Adapter;
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
            List<FeedbackMessage> result = new List<FeedbackMessage>();
            dbContext.FeedbackMessages.ToList().ForEach(feedbackMessage => result.Add(feedbackMessage));
            return Ok(result);
        }
    }
}
