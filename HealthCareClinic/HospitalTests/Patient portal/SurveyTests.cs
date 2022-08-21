using Hospital.Schedule.Model;
using Hospital.Schedule.Repository;
using Hospital.Schedule.Service;
using Moq;
using System.Collections.Generic;
using Xunit;

namespace HospitalUnitTests.Patient_portal
{
    public class SurveyTests
    {
        [Fact]
        public void Get_all_surveys()
        {
            var stubRepository = new Mock<ISurveyRepository>();
            stubRepository.Setup(m => m.GetAll()).Returns(getSurveys());
            SurveyService surveyService = new SurveyService(stubRepository.Object);

            var allSurveys = (List<Survey>)surveyService.GetAll();

            Assert.Single(allSurveys);
        }

        private static List<Survey> getSurveys()
        {
            var surveys = new List<Survey>();
            surveys.Add(new Mock<Survey>().Object);
            return surveys;
        }

        [Fact]
        public void Get_all_surveys_for_patient()
        {
            var stubRepository = new Mock<ISurveyRepository>();
            var patientId = 1;
            stubRepository.Setup(m => m.GetAllByPatientId(patientId)).Returns(getSurveys());
            SurveyService surveyService = new SurveyService(stubRepository.Object);

            var patientSurveys = surveyService.GetAllByPatientId(patientId);

            Assert.Single(patientSurveys);
        }

        [Fact]
        public void Get_all_done_surveys_for_patient()
        {
            var stubRepository = new Mock<ISurveyRepository>();
            var patientId = 1;
            stubRepository.Setup(m => m.GetAllDoneByPatientId(patientId)).Returns(getSurveys());
            SurveyService surveyService = new SurveyService(stubRepository.Object);

            var patientSurveys = surveyService.GetAllDoneByPatientId(patientId);

            Assert.Single(patientSurveys);
        }

        [Fact]
        public void Get_all_not_done_surveys_for_patient()
        {
            var stubRepository = new Mock<ISurveyRepository>();
            var patientId = 1;
            stubRepository.Setup(m => m.GetAllNotDoneByPatientId(patientId)).Returns(getSurveys());
            SurveyService surveyService = new SurveyService(stubRepository.Object);

            var patientSurveys = surveyService.GetAllNotDoneByPatientId(patientId);

            Assert.Single(patientSurveys);
        }

        [Fact]
        public void Gets_distinct_question_categories_names()
        {
            var stubRepository = new Mock<ISurveyRepository>();
            var surveyCategoriesNames = new List<string> { "Doctor", "Medical stuff", "Hospital" };
            stubRepository.Setup(m => m.GetDistinctQuestionCategoriesNames()).Returns(surveyCategoriesNames);
            SurveyService surveyService = new SurveyService(stubRepository.Object);

            List<string> distinctQuestionCategoriesNames = surveyService.GetDistinctQuestionCategoriesNames();

            Assert.Equal(surveyCategoriesNames.Count, distinctQuestionCategoriesNames.Count);
            Assert.Equal(surveyCategoriesNames[0], distinctQuestionCategoriesNames[0]);
        }

        [Fact]
        public void Gets_distinct_question_contents_for_category()
        {
            var stubRepository = new Mock<ISurveyRepository>();
            var categoryName = "Doctor";
            var question = "Doctor category question";
            var questions = new List<string>();
            questions.Add(question);
            stubRepository.Setup(m => m.GetDistinctQuestionContentsForCategory(categoryName)).Returns(questions);
            SurveyService surveyService = new SurveyService(stubRepository.Object);

            List<string> distinctQuestionContentsForCategory = surveyService.GetDistinctQuestionContentsForCategory(categoryName);

            Assert.Contains(question, distinctQuestionContentsForCategory);
        }

        [Fact]
        public void Gets_average_grade_for_question_category()
        {
            var stubRepository = new Mock<ISurveyRepository>();
            var categoryName = "Doctor";
            var averageGrade = 5;
            stubRepository.Setup(m => m.GetAverageGradeForQuestionCategory(categoryName)).Returns(averageGrade);
            SurveyService surveyService = new SurveyService(stubRepository.Object); 

            double averageGradeForQuestionCategory = surveyService.GetAverageGradeForQuestionCategory(categoryName);

            Assert.Equal(averageGrade, averageGradeForQuestionCategory);
        }

        [Fact]
        public void Gets_number_of_grades_for_single_question()
        {
            var stubRepository = new Mock<ISurveyRepository>();
            var questionContent = "Question content";
            var grade = 5;
            var nubmberOfGrades = 1;
            stubRepository.Setup(m => m.GetNumberOfGradesForQuestion(questionContent, grade)).Returns(nubmberOfGrades);
            SurveyService surveyService = new SurveyService(stubRepository.Object);

            int numberOfGradesForQuestion = surveyService.GetNumberOfGradesForQuestion(questionContent, grade);

            Assert.Equal(nubmberOfGrades, numberOfGradesForQuestion);
        }
    }
}
