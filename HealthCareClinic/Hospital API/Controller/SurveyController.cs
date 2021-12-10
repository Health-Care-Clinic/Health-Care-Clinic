using Hospital.Schedule.Model;
using Hospital.Schedule.Service;
using Hospital_API.Adapter;
using Hospital_API.DTO;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Hospital_API.Controller
{
    [Route("api/[controller]")]
    [ApiController]
    public class SurveyController : ControllerBase
    {
        private readonly ISurveyService surveyService;

        public SurveyController(ISurveyService surveyService)
        {
            this.surveyService = surveyService;
        }

        [HttpGet("new/{id?}")]
        public IActionResult GetEmptySurveyForAppointment(int appId)
        {
            Survey survey = surveyService.GetSurveyForAppointment(appId); //promenio iz GenerateSurveyForAppointment u GetSurveyForAppointment
            SurveyDTO result = SurveyAdapter.SurveyToDto(survey);

            return Ok(result);
        }

        [HttpPut("{id?}")]
        public IActionResult SubmitSurvey(List<SurveyQuestionDTO> questionDto)
        {
            foreach (SurveyQuestionDTO question in questionDto)
                if (question.Grade < 1 || question.Grade > 5)
                    return BadRequest();
                else
                    surveyService.ModifyGrade(question.Id, question.Grade);

            return Ok();
        }

        [HttpGet("statistics")]
        public IActionResult GetStatistics()
        {
            SurveyStatistics result = surveyService.GenerateSurveyStatistics();
            
            return Ok(result);
        }
    }
}
