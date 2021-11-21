using Moq;
using System;
using System.Collections.Generic;
using Xunit;
using Shouldly;
using Hospital.Schedule.Service;
using Hospital.Schedule.Model;
using Hospital.Schedule.Repository;

namespace HospitalTests
{
    public class SurveyTests
    {
        private SurveyService surveyService = new SurveyService(CreateStubRepository());


        [Fact]
        public void Get_all_surveys()
        {            
            List<Survey> surveys = (List<Survey>)surveyService.GetAll();

            Assert.NotEmpty(surveys);
        }

        [Fact]
        public void Get_all_surveys_for_patient()
        {
            List<Survey> patientSurveys = surveyService.GetAllByPatientId(1);

            Assert.Equal(2, patientSurveys.Count);
        }

        [Fact]
        public void Get_all_done_surveys_for_patient()
        {
            List<Survey> patientSurveys = surveyService.GetAllDoneByPatientId(1);

            Assert.Equal(2, patientSurveys.Count);
        }

        [Fact]
        public void Get_all_not_done_surveys_for_patient()
        {
            List<Survey> patientSurveys = surveyService.GetAllNotDoneByPatientId(1);

            Assert.Empty(patientSurveys);
        }


        [Theory]
        [MemberData(nameof(Data))]
        public void Check_matching_member_of_survey_list(int surveyId, int expectedIndex, bool shouldWork)
        {
            List<Survey> surveys = (List<Survey>)surveyService.GetAll(); 
            Survey wantedSurvey = surveyService.GetOneById(surveyId);
            //Survey wantedSurvey = surveyService.GetSurveyById(index);

            if (shouldWork)
                Assert.Equal(surveys[expectedIndex], wantedSurvey);
            else
                Assert.NotEqual(surveys[expectedIndex], wantedSurvey);
        }

        public static IEnumerable<object[]> Data =>
            new List<object[]>
            {
                new object[] { 1, 0, true },
                new object[] { 2, 0, false }
            };



        //[Theory]
        //public void Get_all_surveys_for_appointments_after_some_date(DateTime date)
        //{

        //}



        private static ISurveyRepository CreateStubRepository()
        {
            Random random = new Random();
            List<Survey> surveys = new List<Survey>();
            var stubRepository = new Mock<ISurveyRepository>();

            //surveys.Add(new Survey(1, 1, 1));    //id, patientId, appointmentId
            //surveys.Add(new Survey(2, 1, 2));
            //surveys.Add(new Survey(3, 3, 5));
            //surveys.Add(new Survey(7, 12, 11));

            //foreach (Survey survey in surveys)
            //{
            //    foreach (SurveyQuestion question in survey.SurveyQuestions)
            //        question.Grade = random.Next(1, 6);
            //    survey.Done = true;
            //}


            stubRepository.Setup(m => m.GetAll()).Returns(surveys);
            stubRepository.Setup(m => m.GetById(1)).Returns(surveys[0]);
            stubRepository.Setup(m => m.GetAllByPatientId(1)).Returns(surveys.GetRange(0, 2));
            stubRepository.Setup(m => m.GetAllDoneByPatientId(1)).Returns(surveys.GetRange(0, 2));
            stubRepository.Setup(m => m.GetAllNotDoneByPatientId(1)).Returns(new List<Survey>());

            return stubRepository.Object;
        }
    }
}
