using Hospital.Mapper;
using Hospital.Schedule.Model;
using Hospital.Shared_model.Model;
using Hospital.Shared_model.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Hospital.Schedule.Repository
{
    public class SurveyRepository : Repository<Survey>, ISurveyRepository
    {
        public SurveyRepository(HospitalDbContext context) : base(context)
        {
        }

        public HospitalDbContext HospitalDbContext
        {
            get { return Context as HospitalDbContext; }
        }

        public Survey GenerateSurveyForAppointment()
        {
            Survey generatedSurvey = new Survey(1);
            Add(generatedSurvey);

            return generatedSurvey;
        }

        public List<Survey> GetAllByPatientId(int patientId)
        {
            return HospitalDbContext.Surveys.Where(survey => survey.Appointment.PatientId == patientId).ToList();
        }

        public List<string> GetDistinctQuestionCategoriesNames()
        {
            return HospitalDbContext.SurveyCategories.Select(category => category.Name).Distinct().ToList();
        }

        public List<string> GetDistinctQuestionContentsForCategory(string categoryName)
        {
            return HospitalDbContext.SurveyQuestions.Where(question => 
                question.SurveyCategory.Name.Equals(categoryName)).Select(question => question.Content).Distinct().ToList();
        }

        public double GetAverageGradeForQuestionCategory(string categoryName)
        {
            double averageGradeForQuestionCategory = HospitalDbContext.SurveyQuestions.Where(question => 
                question.SurveyCategory.Survey.Done == true && question.SurveyCategory.Name.Equals(categoryName))
                    .Average(q => q.Grade);

            return averageGradeForQuestionCategory;
        }

        public int GetNumberOfGradesForQuestion(string questionContent, int grade)
        {
            int numberOfGradesForQuestion = HospitalDbContext.SurveyQuestions.Where(question =>
                question.SurveyCategory.Survey.Done == true && question.Content.Equals(questionContent) && 
                question.Grade == grade).Count();

            return numberOfGradesForQuestion;
        }

        public double GetAverageGradeForQuestion(string questionContent)
        {
            double averageGradeForQuestion = HospitalDbContext.SurveyQuestions.Where(question =>
                question.SurveyCategory.Survey.Done == true && question.Content.Equals(questionContent)).Average(q => q.Grade);

            return averageGradeForQuestion;
        }

        public List<Survey> GetAllDoneByPatientId(int patientId)
        {
            return HospitalDbContext.Surveys.Where(survey => survey.Appointment.PatientId == patientId && survey.Done == true).ToList();
        }

        public List<Survey> GetAllNotDoneByPatientId(int patientId)
        {
            return HospitalDbContext.Surveys.Where(survey => survey.Appointment.PatientId == patientId && survey.Done == false).ToList();
        }

        public void ModifyGrade(int questionId, int newGrade)
        {
            List<SurveyQuestion> wantedQuestion = new List<SurveyQuestion>();
            wantedQuestion = HospitalDbContext.SurveyQuestions.Where(question => question.Id == questionId).ToList();
            wantedQuestion[0].Grade = newGrade;
            wantedQuestion[0].SurveyCategory.Survey.Done = true;
            Save();
        }
    }
}
