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

        [HttpGet("new")]
        public IActionResult GetEmptySurveyForAppointment()
        {
            Survey survey = surveyService.GenerateSurveyForAppointment();
            SurveyDTO result = SurveyAdapter.SurveyToDto(survey);

            return Ok(result);
        }


        [HttpPut("{id?}")]      
        public IActionResult SubmitSurvey(SurveyDTO surveyDto)
        {
            Survey survey = surveyService.GetOneById(surveyDto.Id);
            if (survey == null)
            {
                return NotFound();
            }

            foreach (SurveyCategoryDTO category in surveyDto.SurveyCategories)
                foreach (SurveyQuestionDTO question in category.SurveyQuestions)
                    if (question.Grade < 1 || question.Grade > 5)
                        return BadRequest();


            SurveyAdapter.DtoToSurvey(surveyDto, surveyService);
            return Ok();
        }






        //[HttpPost("submit")]      
        //public IActionResult SubmitSurvey(SurveyDTO surveyDto)
        //{
        //    foreach (SurveyCategoryDTO category in surveyDto.SurveyCategories)
        //        foreach (SurveyQuestionDTO question in category.SurveyQuestions)
        //            if (question.Grade == 0 || surveyDto.Id < 0)
        //                return BadRequest();

        //    //FeedbackMessage feedback = FeedbackMessageAdapter.FeedbackMessageDTOToFeedbackMessage(survey);
        //    SurveyAdapter.DtoToSurvey(surveyDto, surveyService);
        //    //surveyService.Add(survey);

        //    return Ok();
        //}
    }
}
