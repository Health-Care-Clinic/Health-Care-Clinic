using Hospital.Schedule.Model;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Hospital.Shared_model.Model
{
    public class Appointment
    {
        [Key]
        public int Id { get; set; }

        public int PatientId { get; set; }

        public int DoctorId { get; set; }

        public int RoomId { get; set; }
        public bool isCancelled { get; set; }

        public bool isDone { get; set; }
        public DateTime Date { get; set; }

        public int SurveyId { get; set; }

        public Appointment()
        {
        }

        public Appointment(int id, int patientId, int doctorId, int roomId, bool isCancelled, bool isDone, DateTime date, int surveyId)
        {
            Id = id;
            PatientId = patientId;
            DoctorId = doctorId;
            RoomId = roomId;
            this.isCancelled = isCancelled;
            this.isDone = isDone;
            Date = date;
            SurveyId = surveyId;
        }
    }
}
