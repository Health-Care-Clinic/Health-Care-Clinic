using ClinicCore.DTOs;
using ClinicCore.Utils;
using Model;
using Service;
using System;
using System.Collections.Generic;

namespace ClinicCore.Service
{
    public class EmergencyAppointmentsBySecretary : EmergencyAppointments
    {
        private static EmergencyAppointmentsBySecretary instance = null;
        public static EmergencyAppointmentsBySecretary Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = new EmergencyAppointmentsBySecretary();
                }
                return instance;
            }
        }

        public override List<DoctorAppointment> GenerateAppointments(EmergencyAppointmentDTO emerAppointmentDTO, Doctor doc)
        {
            List<DoctorAppointment> appointments = new List<DoctorAppointment>();
            DateTime appointmentStart = UtilityMethods.Instance.RoundUp(DateTime.Now, TimeSpan.FromMinutes(15));
            for (int i = 0; i < 4; i++)
            {
                appointments.Add(new DoctorAppointment(appointmentStart, appointmentStart.AddMinutes(emerAppointmentDTO.DurationInMinutes), emerAppointmentDTO.AppointmetType,
                    emerAppointmentDTO.Room.RoomId, doc, PatientService.Instance.GetPatientByID(emerAppointmentDTO.Patient.Id)));
                appointmentStart = appointmentStart.AddMinutes(15);
            }
            return appointments;
        }
    }
}
