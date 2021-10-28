using DTOs;
using Enums;
using Newtonsoft.Json;
using System;

namespace Model
{
    public class DoctorAppointment : Appointment
    {
        public String NameSurnamePatient { get; set; }
        public String AppTypeText { get; set; }
        public bool IsUrgent { get; set; } = false;


        [JsonConstructor]
        public DoctorAppointment(DateTime date, AppointmentType type, bool reserved, int room, Doctor doc, Patient patient) : base(date, type, reserved, room)
        {
            if (patient != null)
                this.NameSurnamePatient = patient.Name + " " + patient.Surname;
            this.Doctor = doc;
            this.Patient = patient;
        }
        
        public DoctorAppointment()
        {
        }
        
        public DoctorAppointment(DateTime dateStart, DateTime dateEnd, AppointmentType type, int room, Doctor doc, Patient patient) : base(dateStart, dateEnd, type, room)
        {
            this.NameSurnamePatient = patient.Name + " " + patient.Surname;
            this.Doctor = doc;
            this.Patient = patient;
        }

        public DoctorAppointment(DoctorAppointment docApp) 
        {
            this.Reserved = docApp.Reserved;
            this.AppointmentCause = docApp.AppointmentCause;
            this.AppointmentStart = docApp.AppointmentStart;
            this.AppointmentEnd = docApp.AppointmentEnd;
            this.Type = docApp.Type;
            this.Room = docApp.Room;
            this.Doctor = docApp.Doctor;
            this.Patient = docApp.Patient;
            this.AppTypeText = docApp.AppTypeText;
        }

        public DoctorAppointment(DoctorAppointmentDTO doctorAppointment) : base(doctorAppointment.AppointmentStart, doctorAppointment.AppointmentEnd, doctorAppointment.Type, doctorAppointment.Room)
        {
            this.NameSurnamePatient = doctorAppointment.Patient.Name + " " + doctorAppointment.Patient.Surname;
            //this.Doctor = doctorAppointment.Doctor;
            //this.Patient = doctorAppointment.Patient;
            this.Id = doctorAppointment.Id;
        }

        public DoctorAppointment(bool reserved, string appointmentCause, DateTime appointmentStart, DateTime appointmentEnd, 
            AppointmentType type, int room, int id, bool isUrgent, Patient patient, Doctor doctor, bool isFinished) : base(reserved, appointmentCause, appointmentStart, appointmentEnd, type, room, id)
        {
            IsUrgent = isUrgent;
            Patient = patient;
            Doctor = doctor;
            IsFinished = isFinished;
        }

        public void SetAdmitted(Patient patient)
        {
            throw new NotImplementedException();
        }
        public Patient Patient { get; set; }


        public Doctor Doctor { get; set; }

        public bool IsFinished { get; set; } = false;

    }
}
