using ClinicCore.DTOs;
using Model;
using Service;
using System;
using System.Collections.Generic;

namespace ClinicCore.Service
{
    public class EmergencyAppointmentsByDoctor : EmergencyAppointments
    {
        private static EmergencyAppointmentsByDoctor instance = null;
        public static EmergencyAppointmentsByDoctor Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = new EmergencyAppointmentsByDoctor();
                }
                return instance;
            }
        }

        public override List<DoctorAppointment> GenerateAppointments(EmergencyAppointmentDTO emerAppointmentDTO, Doctor doc)
        {
            List<DoctorAppointment> appointments = new List<DoctorAppointment>();
            DoctorAppointment tempAppointment = new DoctorAppointment(false, "", new DateTime(1, 1, 1), new DateTime(1, 1, 1).AddMinutes(emerAppointmentDTO.DurationInMinutes), emerAppointmentDTO.AppointmetType,
                    emerAppointmentDTO.Room.RoomId, 0, true, PatientService.Instance.GetPatientByID(emerAppointmentDTO.Patient.Id), doc, false);
            tempAppointment.Doctor = doc;
            List<DoctorAppointment> allPossibleAppointments = SuggestedAppointmentService.Instance.GenerateAppointmentsForDoctor(emerAppointmentDTO.RequestedDates, tempAppointment);
            appointments.AddRange(allPossibleAppointments);
            return appointments;
        }
        
    }
}
