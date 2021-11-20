using Hospital.Mapper;
using Hospital.Schedule.Model;
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


        public List<Survey> GetAllByPatientId(int patientId)
        {
            //return HospitalDbContext.Surveys.Where(survey => survey.PatientId == patientId).ToList()
            return null;
        }

        public List<Survey> GetAllDoneByPatientId(int patientId)
        {
            //return HospitalDbContext.Surveys.Where(survey => survey.PatientId == patientId && survey.Done == true).ToList();
            return null;
        }

        public List<Survey> GetAllNotDoneByPatientId(int patientId)
        {
            //return HospitalDbContext.Surveys.Where(survey => survey.PatientId == patientId && survey.Done == false).ToList();
            return null;
        }
    }
}
