using Hospital.Shared_model.Model;
using Hospital_API.DTO;
using System;

namespace Hospital_API.Adapter
{
    public class AppointmentAdapter
    {
        public static AppointmentDTO AppointmentToAppointmentDTO(Appointment appointment)
        {
            AppointmentDTO dto = new AppointmentDTO();

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

        public static Appointment AppointmentDtoToAppointment(AppointmentDTO appointmentDto)
        {
            Appointment app = new Appointment();

            app.Id = appointmentDto.Id;
            app.DoctorId = appointmentDto.DoctorId;
            app.PatientId = appointmentDto.PatientId;
            app.RoomId = appointmentDto.RoomId;
            app.isCancelled = appointmentDto.isCancelled;
            app.isDone = appointmentDto.isDone;
            app.Date = PatientAdapter.ConvertToDate(appointmentDto.Date);
            app.SurveyId = appointmentDto.SurveyId;

            return app;
        }

        private static String ConvertToString(DateTime date)
        {
            String dateAsString = date.ToString();

            return dateAsString;
        }
    }
}