using Hospital.Schedule.Model;
using Hospital.Shared_model.Interface;
using Hospital.Shared_model.Model;
using System;
using System.Collections.Generic;
using System.Text;

namespace Hospital.Schedule.Service
{
    public interface ISurveyService : IService<Survey>
    {
        List<Survey> GetAllByPatientId(int patientId);
        SurveyStatistics GenerateSurveyStatistics();
        List<string> GetDistinctQuestionCategoriesNames();
        List<string> GetDistinctQuestionContentsForCategory(string categoryName);
        List<int> GetNumberOfAssignsForEachGradeForQuestionInCategory(string questionContent, 
            List<string> distinctQuestionsContentsForCategory);
        double GetAverageGradeForQuestionCategory(string categoryName);
        int GetNumberOfGradesForQuestion(string questionContent, int grade);
        double GetAverageGradeForQuestion(string questionContent);
        List<Survey> GetAllDoneByPatientId(int patientId);
        List<Survey> GetAllNotDoneByPatientId(int patientId);
        Survey GenerateSurveyForAppointment();
        void ModifyGrade(int id, int grade);
    }
}
