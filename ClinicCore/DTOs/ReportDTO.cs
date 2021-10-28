using Enums;
using Model;
using System;

namespace DTOs
{
    public class ReportDTO
    {
        public DateTime AppointmentStart { get; set; }
        public string DoctorName { get; set; }
        public string DoctorSurname { get; set; }
        public AppointmentType Type { get; set; }
        public string AppointmentCause { get; set; }
        public string Anemnesis { get; set; }
        public int CountPresciption { get; set; }
        public int CountTests { get; set; }
        public int PatientID { get; set; }

        public ReportDTO(DateTime appointmentStart, string doctorName, string doctorSurname, AppointmentType type, string appointmentCause, string anemnesis, int countPresciption, int patientID)
        {
            AppointmentStart = appointmentStart;
            DoctorName = doctorName;
            DoctorSurname = doctorSurname;
            Type = type;
            AppointmentCause = appointmentCause;
            Anemnesis = anemnesis;
            CountPresciption = countPresciption;
            PatientID = patientID;
        }

        public ReportDTO(Report report)
        {
            AppointmentStart = report.ReportId;
            DoctorName = report.DoctorName;
            DoctorSurname = report.DoctorSurname;
            Type = report.Type;
            AppointmentCause = report.Cause;
            Anemnesis = report.Anamnesis;
            if(report.HaveRecipe == true)
            {
                CountPresciption = 1;
            }
            if(report.HaveTest == true)
            {
                CountTests = 1;
            }
        }
    }
}
