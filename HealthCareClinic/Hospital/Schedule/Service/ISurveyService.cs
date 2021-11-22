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
        public List<Survey> GetAllByPatientId(int patientId);
        public List<Survey> GetAllDoneByPatientId(int patientId);
        public List<Survey> GetAllNotDoneByPatientId(int patientId);
        public Survey GenerateSurveyForAppointment();
        public void ModifyGrade(int id, int grade);
    }
}
