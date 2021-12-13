using ClinicCore.DTOs;
using Enums;
using Model;
using Service;
using System;
using System.Collections.Generic;

namespace ClinicCore.Service
{
    public class SuggestedAppointmentService
    {
        private static SuggestedAppointmentService instance = null;
        public static SuggestedAppointmentService Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = new SuggestedAppointmentService();
                }
                return instance;
            }
        }

        public List<DoctorAppointment> GenerateAppointmentsForDoctor(List<DateTime> dates, DoctorAppointment tempAppointment)
        {
            List<DoctorAppointment> appointmentList = new List<DoctorAppointment>();
            DateTime lastTimeCreated = DateTime.Now;

            foreach (DateTime d in dates)
            {
                if (d.Date == DateTime.Now.Date)
                {
                    if (DateTime.Now.Minute < 15)
                    {
                        lastTimeCreated = new DateTime(d.Year, d.Month, d.Day, DateTime.Now.Hour, 15, 00);
                    }
                    else if (DateTime.Now.Minute < 30)
                    {
                        lastTimeCreated = new DateTime(d.Year, d.Month, d.Day, DateTime.Now.Hour, 30, 00);
                    }
                    else if (DateTime.Now.Minute < 45)
                    {
                        lastTimeCreated = new DateTime(d.Year, d.Month, d.Day, DateTime.Now.Hour, 45, 00);
                    }
                    else if (DateTime.Now.Minute >= 45)
                    {
                        lastTimeCreated = new DateTime(d.Year, d.Month, d.Day, DateTime.Now.Hour + 1, 00, 00);
                    }

                }
                else
                {
                    lastTimeCreated = new DateTime(d.Year, d.Month, d.Day, 8, 00, 00);
                }

                DoctorAppointment newAppointment;
                while (lastTimeCreated.TimeOfDay < new DateTime(DateTime.Now.Date.Year, DateTime.Now.Date.Month, DateTime.Now.Date.Day, 20, 00, 00).TimeOfDay)
                {
                    if (tempAppointment.Type == AppointmentType.CheckUp)
                    {
                        newAppointment = new DoctorAppointment(new DateTime(d.Year, d.Month, d.Day, lastTimeCreated.Hour, lastTimeCreated.Minute, 0), AppointmentType.CheckUp, false, tempAppointment.Room, tempAppointment.Doctor, tempAppointment.Patient);
                        newAppointment.IsUrgent = tempAppointment.IsUrgent;
                        appointmentList.Add(newAppointment);
                        lastTimeCreated = lastTimeCreated.AddMinutes(15);
                    }
                    else
                    {
                        int duration = (int)tempAppointment.AppointmentEnd.Subtract(tempAppointment.AppointmentStart).TotalMinutes;
                        if (duration != 0)
                        {
                            DateTime startTime = new DateTime(d.Year, d.Month, d.Day, lastTimeCreated.Hour, lastTimeCreated.Minute, 0);
                            newAppointment = new DoctorAppointment(startTime, AppointmentType.Operation, false, tempAppointment.Room, tempAppointment.Doctor, tempAppointment.Patient);
                            newAppointment.AppointmentEnd = startTime.AddMinutes(duration);
                            newAppointment.IsUrgent = tempAppointment.IsUrgent;
                            appointmentList.Add(newAppointment);
                            lastTimeCreated = lastTimeCreated.AddMinutes(15);
                        }
                        else
                        {
                            return appointmentList;
                        }
                    }
                }
            }
            return appointmentList;
        }

        private List<DoctorAppointment> GenerateAppointmentForPatient(PossibleAppointmentForPatientDTO possibleAppointment)
        {
            int slotStart = 8;
            int slotLength = 3;
            if (possibleAppointment.TimeSlot == null)
            {
                slotStart = 8;
            }
            else if (possibleAppointment.TimeSlot.Equals("0"))
            {
                slotStart = 8;
            }
            else if (possibleAppointment.TimeSlot.Equals("1"))
            {
                slotStart = 11;
            }
            else if (possibleAppointment.TimeSlot.Equals("2"))
            {
                slotStart = 14;
            }
            else if (possibleAppointment.TimeSlot.Equals("3"))
            {
                slotStart = 17;
            }
            List<DoctorAppointment> allPossibleAppointments = new List<DoctorAppointment>();
            DateTime possibleAppointmentTime = SetPossibleAppointmentTime(possibleAppointment.Date, slotStart);

            if (possibleAppointment.Priority == true)
            {
                foreach (Doctor doc in DoctorService.Instance.AllDoctors)
                {
                    while (possibleAppointmentTime.Hour < slotStart + slotLength)
                    {
                        allPossibleAppointments.Add(new DoctorAppointment(new DateTime(possibleAppointment.Date.Year, possibleAppointment.Date.Month, possibleAppointment.Date.Day, possibleAppointmentTime.Hour, possibleAppointmentTime.Minute, 0), AppointmentType.CheckUp, false, doc.PrimaryRoom, doc, possibleAppointment.Patient));
                        possibleAppointmentTime = possibleAppointmentTime.AddMinutes(30);
                    }
                    possibleAppointmentTime = SetPossibleAppointmentTime(possibleAppointment.Date, slotStart);
                }
            }
            else
            {
                while (possibleAppointmentTime.Hour < slotStart + slotLength)
                {
                    allPossibleAppointments.Add(new DoctorAppointment(new DateTime(possibleAppointment.Date.Year, possibleAppointment.Date.Month, possibleAppointment.Date.Day, possibleAppointmentTime.Hour, possibleAppointmentTime.Minute, 0), AppointmentType.CheckUp, false, possibleAppointment.Doctor.PrimaryRoom, possibleAppointment.Doctor, possibleAppointment.Patient));
                    possibleAppointmentTime = possibleAppointmentTime.AddMinutes(30);
                }
            }
            return allPossibleAppointments;
        }

        private DateTime SetPossibleAppointmentTime(DateTime date, int slotStart)
        {
            if (date.Date == DateTime.Now.Date)
            {
                return new DateTime(date.Year, date.Month, date.Day, DateTime.Now.Hour, 30, 00);
            }
            else
            {
                return new DateTime(date.Year, date.Month, date.Day, slotStart, 00, 00);
            }
        }

        public List<DoctorAppointment> SuggestAppointmentsToPatient(PossibleAppointmentForPatientDTO possibleAppointment)
        {
            List<DoctorAppointment> availableAppointments = new List<DoctorAppointment>();
            List<DoctorAppointment> allPossibleAppointments = GenerateAppointmentForPatient(possibleAppointment);
            foreach (DoctorAppointment doctorAppointment in allPossibleAppointments)
            {
                bool isFree = VerifyAppointmentService.Instance.VerifyAppointment(doctorAppointment);
                if (isFree)
                {
                    availableAppointments.Add(doctorAppointment);
                }
            }
            return availableAppointments;
        }

        public List<DoctorAppointment> SuggestAppointmetsToDoctor(List<DateTime> dates, DoctorAppointment tempAppointment)
        {
            List<DoctorAppointment> allAppointments = new List<DoctorAppointment>();

            allAppointments = GetAvailableAppointmentsByDoctor(dates, tempAppointment);
            allAppointments.AddRange(DoctorAppointmentService.Instance.GetAllByDoctorAndDates(tempAppointment.Doctor.Id, dates));

            return allAppointments;
        }

        public List<DoctorAppointment> GetAvailableAppointmentsByDoctor(List<DateTime> dates, DoctorAppointment tempAppointment)
        {
            List<DoctorAppointment> availableAppointments = new List<DoctorAppointment>();
            List<DoctorAppointment> allPossibleAppointments = SuggestedAppointmentService.Instance.GenerateAppointmentsForDoctor(dates, tempAppointment);
            foreach (DoctorAppointment doctorAppointment in allPossibleAppointments)
            {
                bool isFree = VerifyAppointmentService.Instance.VerifyAppointment(doctorAppointment);
                if (isFree)
                {
                    isFree = VerifyAppointmentService.Instance.VerifyAppointmentByPatient(doctorAppointment, tempAppointment.Patient.Id);
                }
                if (isFree)
                {
                    availableAppointments.Add(doctorAppointment);
                }
            }
            return availableAppointments;
        }
    }
}
