using Hospital.Schedule.Model;
using Hospital.Shared_model.Interface;
using System;
using System.Collections.Generic;
using System.Text;

namespace Hospital.Schedule.Service
{
    public interface ISurveyService : IService<Survey>
    {
        public List<Survey> GetAllByPatientId(int patientId);
        public List<Survey> GetAllDoneByPatientId(int patientId);
        public List<Survey> GetAllNotDoneByPatientId(int patientId);
    }
}
