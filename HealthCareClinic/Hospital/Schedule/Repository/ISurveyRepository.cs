using Hospital.Schedule.Model;
using Hospital.Shared_model.Interface;
using Hospital.Shared_model.Model;
using System;
using System.Collections.Generic;
using System.Text;

namespace Hospital.Schedule.Repository
{
    public interface ISurveyRepository : IRepository<Survey>
    {
        List<Survey> GetAllByPatientId(int patientId);
        List<string> GetDistinctQuestionCategoriesNames();
        List<string> GetDistinctQuestionContentsForCategory(string categoryName);
        double GetAverageGradeForQuestionCategory(string categoryName);
        int GetNumberOfGradesForQuestion(string questionContent, int grade);
        double GetAverageGradeForQuestion(string questionContent);
        List<Survey> GetAllDoneByPatientId(int patientId);
        List<Survey> GetAllNotDoneByPatientId(int patientId);
        Survey GenerateSurveyForAppointment();
        void ModifyGrade(int questionId, int newGrade);
    }
}
