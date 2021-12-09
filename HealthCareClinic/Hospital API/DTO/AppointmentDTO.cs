namespace Hospital_API.DTO
{
    public class AppointmentDTO
    {
        public int Id { get; set; }

        public int PatientId { get; set; }

        public DoctorDTO DoctorDTO { get; set; }

        public int RoomId { get; set; }

        public bool isCancelled { get; set; }

        public bool isDone { get; set; }
        public string Date { get; set; }

        public SurveyDTOForAppointment SurveyDTO { get; set; }

        public AppointmentDTO(int id, int patientId, DoctorDTO doctoDTO, int roomId, bool isCancelled, bool isDone, string date, SurveyDTOForAppointment surveyDTO)
        {
            Id = id;
            PatientId = patientId;
            DoctorDTO = doctoDTO;
            RoomId = roomId;
            this.isCancelled = isCancelled;
            this.isDone = isDone;
            Date = date;
            SurveyDTO = surveyDTO;
        }

        public AppointmentDTO()
        {
        }
    }
}