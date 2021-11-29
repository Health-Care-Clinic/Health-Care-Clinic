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

namespace HospitalUnitTests.Patient_portal
{
    public class SurveyTests
    {
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
        public void Gets_distinct_question_categories_names()
        {
            SurveyService surveyService = new SurveyService(CreateStubRepository());
            List<string> distinctQuestionCategoriesNames = surveyService.GetDistinctQuestionCategoriesNames();

            Assert.Equal(3, distinctQuestionCategoriesNames.Count);
        }

        [Theory]
        [MemberData(nameof(CategoryNameData))]
        public void Gets_distinct_question_contents_for_category(string categoryName)
        {
            SurveyService surveyService = new SurveyService(CreateStubRepository());
            List<string> distinctQuestionContentsForCategory = surveyService.GetDistinctQuestionContentsForCategory(categoryName);

            if (categoryName.Equals("Hospital"))
            {
                Assert.Contains("How would you rate our appointment organisation?", distinctQuestionContentsForCategory);
                Assert.Contains("How would you rate hospitals' hygiene?", distinctQuestionContentsForCategory);
                Assert.Contains("How good were procedure for booking appointment?", distinctQuestionContentsForCategory);
                Assert.Contains("How easy was to use our application?", distinctQuestionContentsForCategory);
                Assert.Contains("Your general grade for whole hospital' service", distinctQuestionContentsForCategory);
            }
            else if (categoryName.Equals("Medical stuff"))
            {
                Assert.Contains("How much our medical staff were polite?", distinctQuestionContentsForCategory);
                Assert.Contains("How would you rate time span that you spend waiting untill doctor attended you?", distinctQuestionContentsForCategory);
                Assert.Contains("How prepared were stuff for emergency situations?", distinctQuestionContentsForCategory);
                Assert.Contains("How good has stuff explained you our procedures?", distinctQuestionContentsForCategory);
                Assert.Contains("Your general grade for medical stuffs' service", distinctQuestionContentsForCategory);
            }
            else if (categoryName.Equals("Doctor"))
            {
                Assert.Contains("How careful did doctor listen you?", distinctQuestionContentsForCategory);
                Assert.Contains("Has doctor been polite?", distinctQuestionContentsForCategory);
                Assert.Contains("Has he explained you your condition enough that you can understand it?", distinctQuestionContentsForCategory);
                Assert.Contains("How would you rate doctors' professionalism?", distinctQuestionContentsForCategory);
                Assert.Contains("Your general grade for doctors' service", distinctQuestionContentsForCategory);
            }
        }

        [Theory]
        [MemberData(nameof(CategoryNameData))]
        public void Gets_average_grade_for_question_category(string categoryName)
        {
            SurveyService surveyService = new SurveyService(CreateStubRepository());
            double averageGradeForQuestionCategory = surveyService.GetAverageGradeForQuestionCategory(categoryName);

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

        [Theory]
        [MemberData(nameof(QuestionContentAndGradeData))]
        public void Gets_number_of_grades_for_single_question(string questionContent, int grade)
        {
            SurveyService surveyService = new SurveyService(CreateStubRepository());
            int numberOfGradesForQuestion = surveyService.GetNumberOfGradesForQuestion(questionContent, grade);

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
                    Assert.Equal(2, numberOfGradesForQuestion);
                    break;
                case 5:
                    Assert.Equal(0, numberOfGradesForQuestion);
                    break;
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

            List<string> surveyCategoriesNames = new List<string> { "Doctor", "Medical stuff", "Hospital" };
            foreach (Survey s in surveys)
            {
                SurveyCategory c1 = new SurveyCategory(surveyCategoriesNames[0]);
                SurveyCategory c2 = new SurveyCategory(surveyCategoriesNames[1]);
                SurveyCategory c3 = new SurveyCategory(surveyCategoriesNames[2]);

                s.SurveyCategories.Add(c1);
                s.SurveyCategories.Add(c2);
                s.SurveyCategories.Add(c3);
            }

            List<string> questionContentsForDoctorCategory = new List<string>
            {
                "How careful did doctor listen you?",
                "Has doctor been polite?",
                "Has he explained you your condition enough that you can understand it?",
                "How would you rate doctors' professionalism?",
                "Your general grade for doctors' service"
            };
            List<string> questionContentsForMedicalStuffCategory = new List<string>
            {
                "How much our medical staff were polite?",
                "How would you rate time span that you spend waiting untill doctor attended you?",
                "How prepared were stuff for emergency situations?",
                "How good has stuff explained you our procedures?",
                "Your general grade for medical stuffs' service"
            };
            List<string> questionContentsForHospitalCategory = new List<string>
            {
                "How would you rate our appointment organisation?",
                "How would you rate hospitals' hygiene?",
                "How good were procedure for booking appointment?",
                "How easy was to use our application?",
                "Your general grade for whole hospital' service"
            };

            FillOutGradesForEachQuestionDependingOnCategory(surveys);

            stubRepository.Setup(m => m.GetAll()).Returns(surveys);
            stubRepository.Setup(m => m.GetById(1)).Returns(surveys[0]);
            stubRepository.Setup(m => m.GetAllByPatientId(1)).Returns(surveys.GetRange(0, 2));
            stubRepository.Setup(m => m.GetAllDoneByPatientId(1)).Returns(surveys.GetRange(0, 1));
            stubRepository.Setup(m => m.GetAllNotDoneByPatientId(1)).Returns(surveys.GetRange(1, 1));

            stubRepository.Setup(m => m.GetDistinctQuestionCategoriesNames())
                .Returns(surveyCategoriesNames);
            stubRepository.Setup(m => m.GetDistinctQuestionContentsForCategory("Doctor"))
                .Returns(questionContentsForDoctorCategory);
            stubRepository.Setup(m => m.GetDistinctQuestionContentsForCategory("Medical stuff"))
                .Returns(questionContentsForMedicalStuffCategory);
            stubRepository.Setup(m => m.GetDistinctQuestionContentsForCategory("Hospital"))
                .Returns(questionContentsForHospitalCategory);
            stubRepository.Setup(m => m.GetAverageGradeForQuestionCategory("Doctor"))
                .Returns(3.8);
            stubRepository.Setup(m => m.GetAverageGradeForQuestionCategory("Medical stuff"))
                .Returns(4.2);
            stubRepository.Setup(m => m.GetAverageGradeForQuestionCategory("Hospital"))
                .Returns(3.4);
            stubRepository.Setup(m => m.GetNumberOfGradesForQuestion("How easy was to use our application?", 1))
                .Returns(0);
            stubRepository.Setup(m => m.GetNumberOfGradesForQuestion("How easy was to use our application?", 2))
                .Returns(0);
            stubRepository.Setup(m => m.GetNumberOfGradesForQuestion("How easy was to use our application?", 3))
                .Returns(0);
            stubRepository.Setup(m => m.GetNumberOfGradesForQuestion("How easy was to use our application?", 4))
                .Returns(2);
            stubRepository.Setup(m => m.GetNumberOfGradesForQuestion("How easy was to use our application?", 5))
                .Returns(0);

            return stubRepository.Object;
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
