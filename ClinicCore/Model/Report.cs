using Enums;
using Newtonsoft.Json;
using System;

namespace Model
{
    public class Report
    {
        public String Anamnesis { get; set; }
        public bool HaveRecipe { get; set; }

        public bool HaveTest { get; set; }
        public DateTime ReportId { get; set; }

        public String DoctorName { get; set; }
        public String DoctorSurname { get; set; }
        public AppointmentType Type { get; set; }
        public String Cause { get; set; }

        [JsonConstructor]
        public Report(DateTime appointmentDate, String doctorName, String doctorSurname, AppointmentType type, String cause) {
            this.HaveRecipe = false;
            this.HaveTest = false;
            this.ReportId = appointmentDate;
            this.DoctorName = doctorName;
            this.DoctorSurname = doctorSurname;
            this.Type = type;
            this.Cause = cause;
        }

        public Report(DateTime appointmentStart, string doctorName, string doctorSurname, AppointmentType type, string appointmentCause, string anemnesis, int countPresciption, int countTests)
        {
            this.Anamnesis = anemnesis;
            if(countPresciption > 0)
            {
                this.HaveRecipe = true;
            }
            else
            {
                this.HaveRecipe = false;
            }
            if (countTests > 0)
            {
                this.HaveTest = true;
            }
            else
            {
                this.HaveTest = false;
            }
            this.ReportId = appointmentStart;
            this.DoctorName = doctorName;
            this.DoctorSurname = doctorSurname;
            this.Type = type;
            this.Cause = appointmentCause;
        }


    }
}
