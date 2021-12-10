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
                int appointmentId = 1;

                OkObjectResult a = surveyController.GetEmptySurveyForAppointment(appointmentId) as OkObjectResult;
                SurveyDTO survey = a.Value as SurveyDTO;
                foreach (Survey s in context.Surveys)
                {
                    context.Surveys.Remove(s);
                    context.SaveChanges();
                }

                Assert.NotNull(survey);
                Assert.Equal(1, survey.AppointmentId);
                Assert.Equal(1, survey.Id);
            }

        }

        [Fact]
        public void Gets_survey_statistics()
        {
            var stubDatabase = CreateStubDatabase();

            using (var context = new HospitalDbContext(stubDatabase))
            {
                SurveyRepository surveyRepository = new SurveyRepository(context);
                SurveyService surveyService = new SurveyService(surveyRepository);

                SurveyController surveyController = new SurveyController(surveyService);

                OkObjectResult a = surveyController.GetStatistics() as OkObjectResult;
                SurveyStatistics surveyStatistics = a.Value as SurveyStatistics;

                foreach (Survey s in context.Surveys)
                {
                    context.Surveys.Remove(s);
                    context.SaveChanges();
                }

                Assert.NotNull(surveyStatistics);
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
                {
                    SurveyCategory c1 = new SurveyCategory("Doctor");
                    SurveyCategory c2 = new SurveyCategory("Medical stuff");
                    SurveyCategory c3 = new SurveyCategory("Hospital");

                    survey.SurveyCategories.Add(c1);
                    survey.SurveyCategories.Add(c2);
                    survey.SurveyCategories.Add(c3);
                }

                FillOutGradesForEachQuestionDependingOnCategory(surveys);

                foreach (Survey survey in surveys)
                {
                    foreach (SurveyCategory surveyCategory in survey.SurveyCategories)
                    {
                        foreach (SurveyQuestion surveyQuestion in surveyCategory.SurveyQuestions)
                            context.SurveyQuestions.Add(surveyQuestion);
                        context.SurveyCategories.Add(surveyCategory);
                    }
                    context.Surveys.Add(survey);
                }

                context.SaveChanges();
            }

            return options;
        }

        private static void FillOutGradesForEachQuestionDependingOnCategory(List<Survey> surveys)
        {
            foreach (Survey s in surveys)
            {
                if (s.Done)
                {
                    foreach (SurveyCategory c in s.SurveyCategories)
                    {
                        if (c.Name.Equals("Doctor"))
                        {
                            int grade = 1;
                            foreach (SurveyQuestion q in c.SurveyQuestions)
                            {
                                q.Grade = grade;

                                if (grade < 5)
                                {
                                    grade += 2;
                                }
                            }
                        }
                        else if (c.Name.Equals("Medical stuff"))
                        {
                            int grade = 2;
                            foreach (SurveyQuestion q in c.SurveyQuestions)
                            {
                                q.Grade = grade;

                                if (grade < 4)
                                {
                                    grade += 2;
                                }
                                else
                                {
                                    grade = 5;
                                }
                            }
                        }
                        else if (c.Name.Equals("Hospital"))
                        {
                            int grade = 2;
                            foreach (SurveyQuestion q in c.SurveyQuestions)
                            {
                                q.Grade = grade;

                                if (grade < 4)
                                {
                                    grade++;
                                }
                            }
                        }
                    }
                }
            }
        }
    }
}
