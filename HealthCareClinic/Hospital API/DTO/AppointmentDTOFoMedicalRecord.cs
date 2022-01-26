using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Hospital_API.DTO
{
    public class AppointmentDTOForMedicalRecord
    {
        public int Id { get; set; }

        public int PatientId { get; set; }

        public DoctorDTO DoctorDTO { get; set; }

        public int RoomId { get; set; }

        public bool isCancelled { get; set; }

        public bool isDone { get; set; }
        public string Date { get; set; }

        public SurveyDTOForAppointment SurveyDTO { get; set; }

        public  ReportDTO ReportDTO { get; set; }

        public AppointmentDTOForMedicalRecord(int id, int patientId, DoctorDTO doctorDTO, int roomId, bool isCancelled, bool isDone, string date, SurveyDTOForAppointment surveyDTO, ReportDTO report)
        {
            Id = id;
            PatientId = patientId;
            DoctorDTO = doctorDTO;
            RoomId = roomId;
            this.isCancelled = isCancelled;
            this.isDone = isDone;
            Date = date;
            SurveyDTO = surveyDTO;
            ReportDTO = report;
        }

        public AppointmentDTOForMedicalRecord()
        {
        }
    }
}
