using ClinicCore.DTOs;
using Enums;
using System;

namespace DTOs
{
    public class DoctorAppointmentDTO
    {
        public Boolean Reserved { get; set; }
        public String AppointmentCause { get; set; }
        public DateTime AppointmentStart { get; set; }
        public DateTime AppointmentEnd { get; set; }
        public AppointmentType Type { get; set; }
        public int Room { get; set; }
        public int Id { get; set; }
        public String NameSurnamePatient { get; set; }
        public String AppTypeText { get; set; }
        public bool IsUrgent { get; set; } = false;
        public PatientDTO Patient { get; set; }
        public DoctorDTO Doctor { get; set; }
        public bool IsFinished { get; set; } = false;

        public DoctorAppointmentDTO(bool reserved, string appointmentCause, DateTime appointmentStart, 
            DateTime appointmentEnd, AppointmentType type, int room, int id, bool isUrgent, PatientDTO patient, DoctorDTO doctor, bool isFinished)
        {
            Reserved = reserved;
            AppointmentCause = appointmentCause;
            AppointmentStart = appointmentStart;
            AppointmentEnd = appointmentEnd;
            Type = type;
            Room = room;
            Id = id;
            IsUrgent = isUrgent;
            Patient = patient;
            Doctor = doctor;
            IsFinished = isFinished;

            if (patient != null)
                NameSurnamePatient = Patient.Name + " " + Patient.Surname;
            if (Type.Equals(AppointmentType.CheckUp))
                AppTypeText = "Pregled";
            else if (Type.Equals(AppointmentType.Operation))
                AppTypeText = "Operacija";

            if (appointmentEnd < DateTime.Now)
                IsFinished = true;
        }
        public DoctorAppointmentDTO(DoctorAppointmentDTO docAppointmentDTO)
        {
            Reserved = docAppointmentDTO.Reserved;
            AppointmentCause = docAppointmentDTO.AppointmentCause;
            AppointmentStart = docAppointmentDTO.AppointmentStart;
            AppointmentEnd = docAppointmentDTO.AppointmentEnd;
            Type = docAppointmentDTO.Type;
            Room = docAppointmentDTO.Room;
            Id = docAppointmentDTO.Id;
            NameSurnamePatient = docAppointmentDTO.NameSurnamePatient;
            AppTypeText = docAppointmentDTO.AppTypeText;
            IsUrgent = docAppointmentDTO.IsUrgent;
            Patient = docAppointmentDTO.Patient;
            Doctor = docAppointmentDTO.Doctor;
            IsFinished = docAppointmentDTO.IsFinished;
        }

        public DoctorAppointmentDTO()
        { 
        }
    }
}
