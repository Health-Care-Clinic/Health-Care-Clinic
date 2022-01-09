using ClinicCore.DTOs;
using ClinicCore.Utils;
using DTOs;
using Model;
using Service;
using System;
using System.Collections.Generic;

namespace ClinicCore.Service
{
    public abstract class EmergencyAppointments
    {
        public List<SuggestedEmergencyAppDTO> GenerateEmergencyAppointments(EmergencyAppointmentDTO emerAppointmentDTO)
        {
            List<DoctorAppointment> appointments = new List<DoctorAppointment>();

            List<Doctor> doctors = DoctorService.Instance.GetDoctorsBySpecialty(emerAppointmentDTO.Specialty);

            foreach (Doctor doc in doctors)
            {
                appointments.AddRange(GenerateAppointments(emerAppointmentDTO, doc));
            }

            List<SuggestedEmergencyAppDTO> suggestedAppointments = FormEmergencyAppDTOs(appointments, emerAppointmentDTO.DurationInMinutes);
            suggestedAppointments.Sort((x, y) => x.TotalReshedulePeriodInHours.CompareTo(y.TotalReshedulePeriodInHours));
            suggestedAppointments = CheckIfConflictingIsUrgent(suggestedAppointments);
            CheckIfConflictingIsStarted(suggestedAppointments);

            return suggestedAppointments;
        }

        public abstract List<DoctorAppointment> GenerateAppointments(EmergencyAppointmentDTO emerAppointmentDTO, Doctor doc);

        private List<SuggestedEmergencyAppDTO> FormEmergencyAppDTOs(List<DoctorAppointment> appointments, int durationInMinutes)
        {
            List<SuggestedEmergencyAppDTO> suggestedAppointments = new List<SuggestedEmergencyAppDTO>();
            foreach (DoctorAppointment appointment in appointments)
            {
                SuggestedEmergencyAppDTO appDTO = new SuggestedEmergencyAppDTO(DoctorAppointmentManagementService.Instance.FormDoctorAppointmentDTO(appointment));

                List<DoctorAppointmentDTO> ca = FindConflictingAppointments(appointment);
                foreach (DoctorAppointmentDTO da in ca)
                    appDTO.ConflictingAppointments.Add(da);
                List<RescheduledAppointmentDTO> ra = FindNextFreeAppointments(FindConflictingAppointments(appointment), durationInMinutes);
                foreach (RescheduledAppointmentDTO da in ra)
                    appDTO.RescheduledAppointments.Add(da);
                appDTO.CalculateTotalReschedulePeriod();

                suggestedAppointments.Add(appDTO);

            }

            return suggestedAppointments;
        }

        private List<DoctorAppointmentDTO> FindConflictingAppointments(DoctorAppointment appointment)
        {
            List<DoctorAppointmentDTO> conflictingAppointments = new List<DoctorAppointmentDTO>();
            foreach (DoctorAppointment app in DoctorAppointmentService.Instance.AllAppointments)
            {
                if ((appointment.Doctor.Id.Equals(app.Doctor.Id) || appointment.Room.Equals(app.Room)))
                {
                    if (CheckAppointmentDates(appointment, app))
                        conflictingAppointments.Add(DoctorAppointmentManagementService.Instance.FormDoctorAppointmentDTO(app));
                }
            }

            return conflictingAppointments;
        }

        private bool CheckAppointmentDates(DoctorAppointment newAppointment, DoctorAppointment appointment)
        {
            bool isOverlaping = false;
            if (AreAppointmentsOverlaping(newAppointment, appointment))
            {
                isOverlaping = true;
            }
            return isOverlaping;
        }
        private bool AreAppointmentsOverlaping(DoctorAppointment newAppointment, DoctorAppointment appointment)
        {
            return (newAppointment.AppointmentStart >= appointment.AppointmentStart && newAppointment.AppointmentStart < appointment.AppointmentEnd)
                || (newAppointment.AppointmentEnd > appointment.AppointmentStart && newAppointment.AppointmentEnd <= appointment.AppointmentEnd)
                || (newAppointment.AppointmentStart <= appointment.AppointmentStart && newAppointment.AppointmentEnd >= appointment.AppointmentEnd);
        }

        private List<RescheduledAppointmentDTO> FindNextFreeAppointments(List<DoctorAppointmentDTO> oldAppointments, double emergencyAppDuration)
        {
            DateTime appointmentStart = DateTime.Now.AddMinutes(emergencyAppDuration);
            appointmentStart = UtilityMethods.Instance.RoundUp(appointmentStart, TimeSpan.FromMinutes(30));
            appointmentStart = appointmentStart.AddMinutes(60);
            List<RescheduledAppointmentDTO> newAppointments = new List<RescheduledAppointmentDTO>();

            while (oldAppointments.Count > 0)
            {
                bool rescheduled = false;
                for (int i = 0; i < oldAppointments.Count; i++)
                {
                    TimeSpan appointmentDuration = oldAppointments[i].AppointmentEnd - oldAppointments[i].AppointmentStart;
                    RescheduledAppointmentDTO appointment = new RescheduledAppointmentDTO(oldAppointments[i]);
                    appointment.NewDocAppointment.AppointmentStart = appointmentStart;
                    appointment.NewDocAppointment.AppointmentEnd = appointmentStart.Add(appointmentDuration);
                    if (appointment.NewDocAppointment.AppointmentStart.TimeOfDay >= new TimeSpan(8, 0, 0) && appointment.NewDocAppointment.AppointmentEnd.TimeOfDay < new TimeSpan(20, 0, 0)
                            && DoctorAppointmentManagementService.Instance.VerifyAppointment(appointment.NewDocAppointment))
                    {
                        newAppointments.Add(appointment);
                        oldAppointments.Remove(oldAppointments[i]);
                        appointmentStart = appointmentStart.Add(appointmentDuration);
                        rescheduled = true;
                    }
                }
                if (!rescheduled)
                {
                    appointmentStart = appointmentStart.AddMinutes(30);
                }
            }

            return newAppointments;

        }

        private List<SuggestedEmergencyAppDTO> CheckIfConflictingIsUrgent(List<SuggestedEmergencyAppDTO> suggestedEmergencyApps)
        {
            List<SuggestedEmergencyAppDTO> validSuggestedApp = new List<SuggestedEmergencyAppDTO>();
            foreach (SuggestedEmergencyAppDTO suggested in suggestedEmergencyApps)
            {
                suggested.CheckIfConflictingIsUrgent();
                if (!suggested.ConflictingIsUrgent)
                {
                    validSuggestedApp.Add(suggested);
                }
            }
            return validSuggestedApp;
        }

        private void CheckIfConflictingIsStarted(List<SuggestedEmergencyAppDTO> suggestedEmergencyApps)
        {
            for (int i = 0; i < suggestedEmergencyApps.Count; i++)
            {
                foreach (DoctorAppointmentDTO conflicting in suggestedEmergencyApps[i].ConflictingAppointments)
                {
                    if (conflicting.AppointmentStart < DateTime.Now)
                    {
                        suggestedEmergencyApps.Remove(suggestedEmergencyApps[i]);
                    }
                }
            }
        }
    }
}
