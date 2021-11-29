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
using Microsoft.AspNetCore.Mvc;
using Hospital_API.DTO;
using Hospital.Shared_model.Model;

namespace HospitalIntegrationTests.Patient_portal
{
    public class SurveyTests
    {
        [Fact]      //integration test
        public void Get_empty_survey()
        {
            var stubDatabase = CreateStubDatabase();

            using (var context = new HospitalDbContext(stubDatabase))
            {
                SurveyRepository surveyRepository = new SurveyRepository(context);
                SurveyService surveyService = new SurveyService(surveyRepository);

                SurveyController surveyController = new SurveyController(surveyService);

                OkObjectResult a = surveyController.GetEmptySurveyForAppointment() as OkObjectResult;
                SurveyDTO survey = a.Value as SurveyDTO;
                foreach (Survey s in context.Surveys)
                {
                    context.Surveys.Remove(s);
                    context.SaveChanges();
                }
                foreach (Appointment app in context.Appointments)
                {
                    context.Appointments
                        .Remove(app);
                    context.SaveChanges();
                }
                Assert.NotNull(survey);
                Assert.Equal(1, survey.AppointmentId);
                Assert.Equal(8, survey.Id);
            }

        }

        private DbContextOptions<HospitalDbContext> CreateStubDatabase()
        {
            var options = new DbContextOptionsBuilder<HospitalDbContext>()
                                .UseInMemoryDatabase(databaseName: "Surveys")
                                .Options;

            using (var context = new HospitalDbContext(options))
            {
                List<Survey> surveys = new List<Survey>();

                surveys.Add(new Survey(1, 1, true));    //id, appointmentid, done
                surveys.Add(new Survey(2, 2, false));
                surveys.Add(new Survey(3, 5, false));
                surveys.Add(new Survey(7, 11, true));

                surveys[0].Appointment.PatientId = 1;
                surveys[1].Appointment.PatientId = 1;
                surveys[2].Appointment.PatientId = 4;
                surveys[3].Appointment.PatientId = 3;


                foreach (Survey survey in surveys)
                    context.Surveys.Add(survey);

                context.SaveChanges();
            }

            return options;
        }
    }
}
