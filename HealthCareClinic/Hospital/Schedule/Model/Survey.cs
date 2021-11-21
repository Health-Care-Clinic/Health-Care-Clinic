using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Hospital.Schedule.Model
{
    public class Survey
    {
        [Key]
        public int Id { get; set; }
        public int PatientId { get; set; }
        //public virtual Patient Patient { get; set; }
        public int AppointmentId { get; set; }
        //public virtual Appointment Appointment { get; set; }
        public bool Done { get; set; }
        public List<SurveyQuestion> SurveyQuestions { get; set; }

        public Survey() { }

        public Survey(int id, int patientId, int appointmentId)
        {
            Id = id;
            PatientId = patientId;
            AppointmentId = appointmentId;
            Done = false;
            GenerateSurveyQuestionsWithNoGrades();
        }

        private void GenerateSurveyQuestionsWithNoGrades()
        {
            SurveyQuestions = new List<SurveyQuestion>();

            //questions for doctor
            SurveyQuestions.Add(new SurveyQuestion("How careful did doctor listen you?", 0));
            SurveyQuestions.Add(new SurveyQuestion("Has doctor been polite?", 0));
            SurveyQuestions.Add(new SurveyQuestion("Has he explained you your condition enough that you can understand it?", 0));
            SurveyQuestions.Add(new SurveyQuestion("How would you rate doctors' professionalism?", 0));
            SurveyQuestions.Add(new SurveyQuestion("Your general grade for doctors' service", 0));

            //questions for medical stuff
            SurveyQuestions.Add(new SurveyQuestion("How much our medical staff were polite?", 0));
            SurveyQuestions.Add(new SurveyQuestion("How would you rate time span that you spend waiting untill doctor attended you?", 0));
            SurveyQuestions.Add(new SurveyQuestion("How prepared were stuff for emergency situations?", 0));
            SurveyQuestions.Add(new SurveyQuestion("How good has stuff explained you our procedures?", 0));
            SurveyQuestions.Add(new SurveyQuestion("Your general grade for medical stuffs' service", 0));

            //questions for hospital service
            SurveyQuestions.Add(new SurveyQuestion("How would you rate our appointment organisation?", 0));
            SurveyQuestions.Add(new SurveyQuestion("How would you rate hospitals' hygiene?", 0));
            SurveyQuestions.Add(new SurveyQuestion("How good were procedure for booking appointment?", 0));
            SurveyQuestions.Add(new SurveyQuestion("How easy was to use our application?", 0));
            SurveyQuestions.Add(new SurveyQuestion("Your general grade for whole hospital' service", 0));
        }
    }
}
