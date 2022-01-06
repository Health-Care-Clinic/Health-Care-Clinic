using Enums;
using Model;
using Service;
using System;
using System.Collections.Generic;


namespace ClinicCore.Service
{
    public class VerifyAppointmentService
    {
        private static VerifyAppointmentService instance = null;
        public static VerifyAppointmentService Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = new VerifyAppointmentService();
                }
                return instance;
            }
        }

        public bool VerifyAppointment(DoctorAppointment doctorAppointment)
        {
            List<Appointment> docAppsByRoom = new List<Appointment>(DoctorAppointmentService.Instance.GetAllByRoom(doctorAppointment.Room));
            List<Appointment> classicAppsByRoom = AppointmentService.Instance.GetAppByRoom(doctorAppointment.Room);
            List<Appointment> appsByDoctor = new List<Appointment>(DoctorAppointmentService.Instance.GetAllByDoctor(doctorAppointment.Doctor.Id));
            Boolean isVerified = true;

            if (!AppointmentService.Instance.CheckAppointment(docAppsByRoom, doctorAppointment.AppointmentStart, doctorAppointment.AppointmentEnd))
                isVerified = false;
            if (!AppointmentService.Instance.CheckAppointment(classicAppsByRoom, doctorAppointment.AppointmentStart, doctorAppointment.AppointmentEnd) && isVerified == true)
                isVerified = false;
            if (!AppointmentService.Instance.CheckAppointment(appsByDoctor, doctorAppointment.AppointmentStart, doctorAppointment.AppointmentEnd) && isVerified == true)
                isVerified = false;
            if (!IsDoctorWorking(doctorAppointment.Doctor, doctorAppointment.AppointmentStart, doctorAppointment.AppointmentEnd) && isVerified == true)
                isVerified = false;

            return isVerified;
        }

        private bool IsDoctorWorking(Doctor doctor, DateTime appointmentStart, DateTime appointmentEnd)
        {
            bool isOnVacation = false;
            bool isWorkingTheRightShift = false;
            if (IsDoctorOnVacation(doctor, appointmentStart, appointmentEnd))
                isOnVacation = true;

            if (doctor.WorkShift.Equals(WorkDayShift.FirstShift))
            {
                if (appointmentStart.TimeOfDay >= new TimeSpan(8, 0, 0) && appointmentEnd.TimeOfDay <= new TimeSpan(14, 0, 0))
                    isWorkingTheRightShift = true;

            }
            else
            {
                if (appointmentStart.TimeOfDay >= new TimeSpan(14, 0, 0) && appointmentEnd.TimeOfDay <= new TimeSpan(20, 0, 0))
                    isWorkingTheRightShift = true;
            }

            return !isOnVacation && isWorkingTheRightShift;
        }

        private bool IsDoctorOnVacation(Doctor doctor, DateTime appointmentStart, DateTime appointmentEnd)
        {
            bool isOnVacation = false;
            DateTime VacationTimeEnd = doctor.VacationTimeStart.AddDays(14);
            if (appointmentStart > doctor.VacationTimeStart && appointmentStart < VacationTimeEnd)
                isOnVacation = true;
            if (appointmentEnd > doctor.VacationTimeStart && appointmentEnd < VacationTimeEnd)
                isOnVacation = true;
            if (appointmentStart < doctor.VacationTimeStart && appointmentEnd > VacationTimeEnd)
                isOnVacation = true;

            return isOnVacation;
        }

        public bool VerifyAppointmentByPatient(DoctorAppointment doctorAppointment, int idPatient)
        {
            bool isFree = true;
            foreach (DoctorAppointment patientAppointment in DoctorAppointmentService.Instance.GetAllByPatient(idPatient))
            {
                if (doctorAppointment.AppointmentStart == patientAppointment.AppointmentStart)
                {
                    isFree = false;
                    break;
                }
            }
            return isFree;
        }
    }
}
