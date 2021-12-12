using Hospital.Shared_model.Model;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Hospital.Schedule.Model
{
    public class Survey
    {
        public static readonly List<string> Categories = new List<string>() { "Doctor", "Medical stuff", "Hospital" };


        [Key]
        public int Id { get; set; }
        //public int PatientId { get; set; }
        //public virtual Patient Patient { get; set; }
        public int AppointmentId { get; set; }        
        public bool Done { get; set; }

        public virtual ICollection<SurveyCategory> SurveyCategories { get; set; }

        [ForeignKey("AppointmentId")]
        public virtual Appointment Appointment { get; set; }

        public Survey()
        {
        }

        public Survey(int appointmentId)
        {
            AppointmentId = appointmentId;
            Done = false;

            SurveyCategories = new List<SurveyCategory>();

            foreach (string category in Categories)
                SurveyCategories.Add(new SurveyCategory(category));
        }

        public Survey(int Id, int AppointmentId)
        {
            this.Id = Id;
            this.AppointmentId = AppointmentId;
        }

        public Survey(int id, int appointmentId, bool done)
        {
            this.Id = id;
            this.AppointmentId = appointmentId;
            Done = done;
            SurveyCategories = new List<SurveyCategory>();
            this.Appointment = new Appointment();
        }
    }
}
