namespace Hospital_API.DTO
{
    public class AppointmentDTO
    {
        public int Id { get; set; }

        public int PatientId { get; set; }

        public int DoctorId { get; set; }

        public int RoomId { get; set; }

        public bool isCancelled { get; set; }

        public bool isDone { get; set; }
        public string Date { get; set; }

        public int SurveyId { get; set; }

        public AppointmentDTO(int id, int patientId, int doctorId, int roomId, bool isCancelled, bool isDone, string date, int surveyId)
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

        public AppointmentDTO()
        {
        }
    }
}