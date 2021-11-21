using Moq;
using System;
using System.Collections.Generic;
using Xunit;
using Shouldly;
using Hospital.Schedule.Service;
using Hospital.Schedule.Model;
using Hospital.Schedule.Repository;
using Microsoft.Extensions.Configuration;
using System.IO;
using Microsoft.EntityFrameworkCore;
using Hospital.Mapper;
using Hospital_API.Controller;

namespace HospitalTests
{
    public class SurveyTests
    {
        [Fact]      //integration test
        public void Get_empty_survey()
        {
            var builder = new ConfigurationBuilder().SetBasePath(Directory.GetCurrentDirectory()).AddJsonFile("appsettings.json");
            var configuration = builder.Build();
            var optionsBuilder = new DbContextOptionsBuilder<HospitalDbContext>();
            optionsBuilder.UseNpgsql(configuration.GetConnectionString("HospitalDbConnectionString"));
            var _context = new HospitalDbContext(optionsBuilder.Options);

            SurveyRepository surveyRepository = new SurveyRepository(_context);
            SurveyService surveyService = new SurveyService(surveyRepository);
            SurveyController surveyController = new SurveyController(surveyService);

            Survey newSurvey = (Survey)surveyController.GetEmptySurveyForAppointment();

            Assert.NotNull(newSurvey);
        }



        [Fact]
        public void Get_all_surveys()
        {
            SurveyService surveyService = new SurveyService(CreateStubRepository());
            List<Survey> surveys = (List<Survey>)surveyService.GetAll();

            Assert.NotEmpty(surveys);
        }

        [Fact]
        public void Get_all_surveys_for_patient()
        {
            SurveyService surveyService = new SurveyService(CreateStubRepository());
            List<Survey> patientSurveys = surveyService.GetAllByPatientId(1);

            Assert.Equal(2, patientSurveys.Count);
        }

        [Fact]
        public void Get_all_done_surveys_for_patient()
        {
            SurveyService surveyService = new SurveyService(CreateStubRepository());
            List<Survey> patientSurveys = surveyService.GetAllDoneByPatientId(1);

            Assert.Single(patientSurveys);
        }

        [Fact]
        public void Get_all_not_done_surveys_for_patient()
        {
            SurveyService surveyService = new SurveyService(CreateStubRepository());
            List<Survey> patientSurveys = surveyService.GetAllNotDoneByPatientId(1);

            Assert.Single(patientSurveys);
        }


        [Theory]
        [MemberData(nameof(Data))]
        public void Check_matching_member_of_survey_list(int surveyId, int expectedIndex, bool shouldWork)
        {
            SurveyService surveyService = new SurveyService(CreateStubRepository());
            List<Survey> surveys = (List<Survey>)surveyService.GetAll(); 
            Survey wantedSurvey = surveyService.GetOneById(surveyId);

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


        private static ISurveyRepository CreateStubRepository()
        {
            List<Survey> surveys = new List<Survey>();
            var stubRepository = new Mock<ISurveyRepository>();

            surveys.Add(new Survey(1, 1, true));    //id, appointmentid, done
            surveys.Add(new Survey(2, 2, false));
            surveys.Add(new Survey(3, 5, false));
            surveys.Add(new Survey(7, 11, true));

            surveys[0].Appointment.PatientId = 1;
            surveys[1].Appointment.PatientId = 1;
            surveys[2].Appointment.PatientId = 4;
            surveys[3].Appointment.PatientId = 3;


            stubRepository.Setup(m => m.GetAll()).Returns(surveys);
            stubRepository.Setup(m => m.GetById(1)).Returns(surveys[0]);
            stubRepository.Setup(m => m.GetAllByPatientId(1)).Returns(surveys.GetRange(0, 2));
            stubRepository.Setup(m => m.GetAllDoneByPatientId(1)).Returns(surveys.GetRange(0, 1));
            stubRepository.Setup(m => m.GetAllNotDoneByPatientId(1)).Returns(surveys.GetRange(1, 1));

            return stubRepository.Object;
        }
    }
}
