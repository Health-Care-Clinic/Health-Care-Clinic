using Hospital.Schedule.Model;
using Hospital.Schedule.Repository;
using Hospital.Shared_model.Interface;
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

        public IEnumerable<Survey> GetAll()
        {
            return (List<Survey>)surveyRepository.GetAll();
        }

        public List<Survey> GetAllByPatientId(int patientId)
        {
            List<Survey> surveysForPatient = new List<Survey>();

            foreach (Survey survey in surveyRepository.GetAll())
                if (survey.PatientId == patientId)
                    surveysForPatient.Add(survey);

            return surveysForPatient;

            //return surveyRepository.GetAllByPatientId(patientId);
        }

        public List<Survey> GetAllDoneByPatientId(int patientId)
        {
            List<Survey> doneSurveysForPatient = new List<Survey>();

            foreach (Survey survey in GetAllByPatientId(patientId))
                if (survey.Done)
                    doneSurveysForPatient.Add(survey);

            return doneSurveysForPatient;

            //return surveyRepository.GetAllDoneByPatientId(patientId);
        }

        public List<Survey> GetAllNotDoneByPatientId(int patientId)
        {
            List<Survey> doneSurveysForPatient = new List<Survey>();

            foreach (Survey survey in GetAllByPatientId(patientId))
                if (!survey.Done)
                    doneSurveysForPatient.Add(survey);

            return doneSurveysForPatient;
            //return surveyRepository.GetAllNotDoneByPatientId(patientId);
        }


        public Survey GetOneById(int id)
        {
            //Survey wantedSurvey = surveyRepository.GetById(id);
            //IEnumerable<Survey> surveys = surveyRepository.GetById(id);
            //Survey wantedSurvey = surveys[id];

            return surveyRepository.GetById(id);
        }


        public void Remove(Survey entity)
        {
            throw new NotImplementedException();
        }
    }
}
