using System;

namespace ClinicCore.Model
{
    public class PatientHospitalEvaluation
    {
        public int Grade { get; set; }
        public String Comment { get; set; }
        public DateTime EvaluationDate { get; set; }
        public int PatientId { get; set; }

        public PatientHospitalEvaluation(int grade, String comment, DateTime evaluationDate, int patientId)
        {
            this.Grade = grade;
            this.Comment = comment;
            this.EvaluationDate = evaluationDate;
            this.PatientId = patientId;
        }
    }
}
