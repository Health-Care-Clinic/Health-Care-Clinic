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

        //public int SurveyId { get; set; }
        //[ForeignKey("SurveyId")]
        //public virtual Survey Survey { get; set; }

        //public int SurveyId { get; set; }
        public virtual ICollection<Survey> Surveys { get; set; }

        public Appointment()
        {
        }
    }
}
