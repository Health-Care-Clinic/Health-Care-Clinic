using Hospital.Schedule.Model;
using Hospital.Shared_model.Interface;
using System;
using System.Collections.Generic;
using System.Text;

namespace Hospital.Schedule.Repository
{
    public interface ISurveyRepository : IRepository<Survey>
    {
        List<Survey> GetAllByPatientId(int patientId);
        public List<Survey> GetAllDoneByPatientId(int patientId);
        public List<Survey> GetAllNotDoneByPatientId(int patientId);
    }
}
