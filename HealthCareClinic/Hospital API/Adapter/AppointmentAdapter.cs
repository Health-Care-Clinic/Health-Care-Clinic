using Hospital.Shared_model.Model;
using Hospital_API.DTO;
using System;

namespace Hospital_API.Adapter
{
    public class AppointmentAdapter
    {
        public static AppointmetDTO AppointmentToAppointmentDTO(Appointment appointment)
        {
            AppointmetDTO dto = new AppointmetDTO();

            dto.Id = appointment.Id;
            dto.DoctorId = appointment.DoctorId;
            dto.PatientId = appointment.PatientId;
            dto.RoomId = appointment.RoomId;
            dto.isCancelled = appointment.isCancelled;
            dto.isDone = appointment.isDone;
            dto.Date = ConvertToString(appointment.Date);
            dto.SurveyId = appointment.SurveyId;

            return dto;
        }

        private static String ConvertToString(DateTime date)
        {
            String dateAsString = date.ToString();

            return dateAsString;
        }
    }
}