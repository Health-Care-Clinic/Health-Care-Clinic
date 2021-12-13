using Hospital.Schedule.Model;
using Hospital.Schedule.Repository;
using Hospital.Shared_model.Interface;
using Hospital.Shared_model.Model;
using System;
using System.Collections.Generic;
using System.Text;

namespace Hospital.Schedule.Service
{
    public class SurveyService : ISurveyService
    {
        private ISurveyRepository surveyRepository;

        public SurveyService(ISurveyRepository surveyRepository)
        {
            this.surveyRepository = surveyRepository;
        }

        public void Add(Survey entity)
        {
            this.surveyRepository.Add(entity);
        }

        public Survey GenerateSurveyForAppointment(int id)
        {
            return surveyRepository.GenerateSurveyForAppointment(id);
        }
        public Survey GetSurveyForAppointment(int id)
        {
            return surveyRepository.GetSurveyForAppointment(id);
        }

        public IEnumerable<Survey> GetAll()
        {
            return (List<Survey>)surveyRepository.GetAll();
        }

        public List<Survey> GetAllByPatientId(int patientId)
        {
            //List<Survey> surveysForPatient = new List<Survey>();

            //foreach (Survey survey in surveyRepository.GetAll())
            //    if (survey.PatientId == patientId)
            //        surveysForPatient.Add(survey);

            //return surveysForPatient;

            return surveyRepository.GetAllByPatientId(patientId);
        }

        public SurveyStatistics GenerateSurveyStatistics()
        {
            SurveyStatistics surveyStatistics = new SurveyStatistics();

            surveyStatistics.SurveyCategoriesStatistics = new List<SurveyCategoryStatistics>();
            foreach (string categoryName in GetDistinctQuestionCategoriesNames())
            {
                SurveyCategoryStatistics oneCategoryStatistics = new SurveyCategoryStatistics();

                oneCategoryStatistics.Name = categoryName;
                oneCategoryStatistics.AverageGrade = GetAverageGradeForQuestionCategory(categoryName);

                oneCategoryStatistics.SurveyQuestionsStatistics = new List<SurveyQuestionStatistics>();
                List<string> distinctQuestionContentsForCategory = GetDistinctQuestionContentsForCategory(categoryName);
                foreach (string questionContent in distinctQuestionContentsForCategory)
                {
                    SurveyQuestionStatistics oneQuestionStatistics = new SurveyQuestionStatistics();

                    oneQuestionStatistics.Content = questionContent;
                    oneQuestionStatistics.NumberOfAssignsForEachGrade = 
                        GetNumberOfAssignsForEachGradeForQuestionInCategory(questionContent, distinctQuestionContentsForCategory);
                    oneQuestionStatistics.AverageGrade = GetAverageGradeForQuestion(questionContent);
                    oneQuestionStatistics.SurveyCategoryName = categoryName;

                    oneCategoryStatistics.SurveyQuestionsStatistics.Add(oneQuestionStatistics);
                }

                surveyStatistics.SurveyCategoriesStatistics.Add(oneCategoryStatistics);
            }

            return surveyStatistics;
        }

        public List<string> GetDistinctQuestionCategoriesNames()
        {
            return surveyRepository.GetDistinctQuestionCategoriesNames();
        }

        public List<string> GetDistinctQuestionContentsForCategory(string categoryName)
        {
            return surveyRepository.GetDistinctQuestionContentsForCategory(categoryName);
        }

        public List<int> GetNumberOfAssignsForEachGradeForQuestionInCategory(string questionContent, 
            List<string> distinctQuestionsContentsForCategory)
        {
            List<int> numberOfEachGradeForQuestion = new List<int>();

            foreach (string qC in distinctQuestionsContentsForCategory)
            {
                if (questionContent.Equals(qC))
                {
                    for (int g = 1; g < 6; g++)
                    {
                        int numberOfGradeAssigns = GetNumberOfGradesForQuestion(questionContent, g);
                        numberOfEachGradeForQuestion.Add(numberOfGradeAssigns);
                    }

                    break;
                }
            }

            return numberOfEachGradeForQuestion;
        }

        public double GetAverageGradeForQuestionCategory(string categoryName)
        {
            return surveyRepository.GetAverageGradeForQuestionCategory(categoryName);
        }

        public int GetNumberOfGradesForQuestion(string questionContent, int grade)
        {
            return surveyRepository.GetNumberOfGradesForQuestion(questionContent, grade);
        }

        public double GetAverageGradeForQuestion(string questionContent)
        {
            return surveyRepository.GetAverageGradeForQuestion(questionContent);
        }

        public List<Survey> GetAllDoneByPatientId(int patientId)
        {
            //List<Survey> doneSurveysForPatient = new List<Survey>();

            //foreach (Survey survey in GetAllByPatientId(patientId))
            //    if (survey.Done)
            //        doneSurveysForPatient.Add(survey);

            //return doneSurveysForPatient;

            return surveyRepository.GetAllDoneByPatientId(patientId);
        }

        public List<Survey> GetAllNotDoneByPatientId(int patientId)
        {
            //List<Survey> doneSurveysForPatient = new List<Survey>();

            //foreach (Survey survey in GetAllByPatientId(patientId))
            //    if (!survey.Done)
            //        doneSurveysForPatient.Add(survey);

            //return doneSurveysForPatient;
            return surveyRepository.GetAllNotDoneByPatientId(patientId);
        }

        public Survey GetOneById(int id)
        {
            //Survey wantedSurvey = surveyRepository.GetById(id);
            //IEnumerable<Survey> surveys = surveyRepository.GetById(id);
            //Survey wantedSurvey = surveys[id];

            return surveyRepository.GetById(id);
        }

        public void ModifyGrade(int questionId, int newGrade)
        {
            surveyRepository.ModifyGrade(questionId, newGrade);
        }

        public void Remove(Survey entity)
        {
            throw new NotImplementedException();
        }
    }
}
