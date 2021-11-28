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

namespace HospitalTests.Patient_portal
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

                Assert.NotNull(survey);
                Assert.Equal(1, survey.AppointmentId);
                Assert.Equal(8, survey.Id);
            }

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

        [Fact]
        public void Gets_distinct_question_categories_names()
        {
            var stubDatabase = CreateStubDatabase();

            using (var context = new HospitalDbContext(stubDatabase))
            {
                SurveyRepository surveyRepository = new SurveyRepository(context);
                SurveyService surveyService = new SurveyService(surveyRepository);

                List<string> distinctQuestionCategoriesNames = surveyService.GetDistinctQuestionCategoriesNames();

                foreach (Survey s in context.Surveys)
                {
                    context.Surveys.Remove(s);
                    context.SaveChanges();
                }

                Assert.Equal(3, distinctQuestionCategoriesNames.Count);
            }
        }

        [Theory]
        [MemberData(nameof(CategoryNameData))]
        public void Gets_distinct_question_contents_for_category(string categoryName)
        {
            var stubDatabase = CreateStubDatabase();

            using (var context = new HospitalDbContext(stubDatabase))
            {
                SurveyRepository surveyRepository = new SurveyRepository(context);
                SurveyService surveyService = new SurveyService(surveyRepository);

                List<string> distinctQuestionCategoriesNames = surveyService.GetDistinctQuestionContentsForCategory(categoryName);

                foreach (Survey s in context.Surveys)
                {
                    context.Surveys.Remove(s);
                    context.SaveChanges();
                }

                if (categoryName.Equals("Hospital"))
                {
                    Assert.Contains("How would you rate our appointment organisation?", distinctQuestionCategoriesNames);
                    Assert.Contains("How would you rate hospitals' hygiene?", distinctQuestionCategoriesNames);
                    Assert.Contains("How good were procedure for booking appointment?", distinctQuestionCategoriesNames);
                    Assert.Contains("How easy was to use our application?", distinctQuestionCategoriesNames);
                    Assert.Contains("Your general grade for whole hospital' service", distinctQuestionCategoriesNames);
                }
                else if (categoryName.Equals("Medical stuff"))
                {
                    Assert.Contains("How much our medical staff were polite?", distinctQuestionCategoriesNames);
                    Assert.Contains("How would you rate time span that you spend waiting untill doctor attended you?", distinctQuestionCategoriesNames);
                    Assert.Contains("How prepared were stuff for emergency situations?", distinctQuestionCategoriesNames);
                    Assert.Contains("How good has stuff explained you our procedures?", distinctQuestionCategoriesNames);
                    Assert.Contains("Your general grade for medical stuffs' service", distinctQuestionCategoriesNames);
                }
                else if (categoryName.Equals("Doctor"))
                {
                    Assert.Contains("How careful did doctor listen you?", distinctQuestionCategoriesNames);
                    Assert.Contains("Has doctor been polite?", distinctQuestionCategoriesNames);
                    Assert.Contains("Has he explained you your condition enough that you can understand it?", distinctQuestionCategoriesNames);
                    Assert.Contains("How would you rate doctors' professionalism?", distinctQuestionCategoriesNames);
                    Assert.Contains("Your general grade for doctors' service", distinctQuestionCategoriesNames);
                }
            }
        }

        [Theory]
        [MemberData(nameof(CategoryNameData))]
        public void Gets_average_grade_for_question_category(string categoryName)
        {
            var stubDatabase = CreateStubDatabase();

            using (var context = new HospitalDbContext(stubDatabase))
            {
                SurveyRepository surveyRepository = new SurveyRepository(context);
                SurveyService surveyService = new SurveyService(surveyRepository);

                double averageGradeForQuestionCategory = surveyService.GetAverageGradeForQuestionCategory(categoryName);

                foreach (Survey s in context.Surveys)
                {
                    context.Surveys.Remove(s);
                    context.SaveChanges();
                }

                if (categoryName.Equals("Hospital"))
                {
                    Assert.Equal(3.4, averageGradeForQuestionCategory);
                }
                else if (categoryName.Equals("Medical stuff"))
                {
                    Assert.Equal(4.2, averageGradeForQuestionCategory);
                }
                else if (categoryName.Equals("Doctor"))
                {
                    Assert.Equal(3.8, averageGradeForQuestionCategory);
                }
            }
        }

        [Theory]
        [MemberData(nameof(QuestionContentAndGradeData))]
        public void Gets_number_of_grades_for_single_question(string questionContent, int grade)
        {
            var stubDatabase = CreateStubDatabase();

            using (var context = new HospitalDbContext(stubDatabase))
            {
                SurveyRepository surveyRepository = new SurveyRepository(context);
                SurveyService surveyService = new SurveyService(surveyRepository);

                int numberOfGradesForQuestion = surveyService.GetNumberOfGradesForQuestion(questionContent, grade);

                foreach (Survey s in context.Surveys)
                {
                    context.Surveys.Remove(s);
                    context.SaveChanges();
                }

                switch (grade)
                {
                    case 1:
                        Assert.Equal(0, numberOfGradesForQuestion);
                        break;
                    case 2:
                        Assert.Equal(0, numberOfGradesForQuestion);
                        break;
                    case 3:
                        Assert.Equal(0, numberOfGradesForQuestion);
                        break;
                    case 4:
                        Assert.Equal(4, numberOfGradesForQuestion);
                        break;
                    case 5:
                        Assert.Equal(0, numberOfGradesForQuestion);
                        break;
                }
            }
        }

        public static IEnumerable<object[]> CategoryNameData()
        {
            var retVal = new List<object[]>();

            retVal.Add(new object[] { "Hospital" });
            retVal.Add(new object[] { "Medical stuff" });
            retVal.Add(new object[] { "Doctor" });

            return retVal;
        }

        public static IEnumerable<object[]> QuestionContentAndGradeData()
        {
            var retVal = new List<object[]>();

            retVal.Add(new object[] { "How easy was to use our application?", 1 });
            retVal.Add(new object[] { "How easy was to use our application?", 2 });
            retVal.Add(new object[] { "How easy was to use our application?", 3 });
            retVal.Add(new object[] { "How easy was to use our application?", 4 });
            retVal.Add(new object[] { "How easy was to use our application?", 5 });

            return retVal;
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

                foreach (Survey s in surveys)
                {
                    SurveyCategory c1 = new SurveyCategory("Doctor");
                    SurveyCategory c2 = new SurveyCategory("Medical stuff");
                    SurveyCategory c3 = new SurveyCategory("Hospital");

                    s.SurveyCategories.Add(c1);
                    s.SurveyCategories.Add(c2);
                    s.SurveyCategories.Add(c3);
                }

                FillOutGradesForEachQuestionDependingOnCategory(surveys);

                foreach (Survey survey in surveys)
                    context.Surveys.Add(survey);

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
