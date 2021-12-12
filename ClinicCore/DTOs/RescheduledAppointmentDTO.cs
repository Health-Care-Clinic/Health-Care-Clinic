using DTOs;

namespace Model
{
    public class RescheduledAppointmentDTO
    {
        public DoctorAppointmentDTO NewDocAppointment { get; set; } = new DoctorAppointmentDTO();
        public DoctorAppointmentDTO OldDocAppointment { get; set; } = new DoctorAppointmentDTO();

        public RescheduledAppointmentDTO(DoctorAppointmentDTO doctorAppointment)
        {
            NewDocAppointment.Reserved = doctorAppointment.Reserved;
            NewDocAppointment.AppointmentCause = doctorAppointment.AppointmentCause;
            NewDocAppointment.AppointmentStart = doctorAppointment.AppointmentStart;
            NewDocAppointment.AppointmentEnd = doctorAppointment.AppointmentEnd;
            NewDocAppointment.Type = doctorAppointment.Type;
            NewDocAppointment.Room = doctorAppointment.Room;
            NewDocAppointment.Doctor = doctorAppointment.Doctor;
            NewDocAppointment.Patient = doctorAppointment.Patient;
            NewDocAppointment.AppTypeText = doctorAppointment.AppTypeText;

            OldDocAppointment = new DoctorAppointmentDTO(NewDocAppointment);
        }
    }
}
