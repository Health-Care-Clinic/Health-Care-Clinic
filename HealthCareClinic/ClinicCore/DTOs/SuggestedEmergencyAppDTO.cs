using DTOs;
using System;
using System.Collections.Generic;

namespace Model
{
    public class SuggestedEmergencyAppDTO
    {
        public DoctorAppointmentDTO SuggestedAppointment { get; set; }
        public List<DoctorAppointmentDTO> ConflictingAppointments { get; set; } 
        public List<RescheduledAppointmentDTO> RescheduledAppointments { get; set; }
        public int TotalReshedulePeriodInHours { get; set; }
        public bool ConflictingIsUrgent { get; set; }

        public SuggestedEmergencyAppDTO(DoctorAppointmentDTO appointment)
        {
            SuggestedAppointment = appointment;
            ConflictingAppointments = new List<DoctorAppointmentDTO>();
            RescheduledAppointments = new List<RescheduledAppointmentDTO>();
        }

        public void CalculateTotalReschedulePeriod()
        {
            TotalReshedulePeriodInHours = 0;
            if (ConflictingAppointments.Count > 0)
                for (int i = 0; i < ConflictingAppointments.Count; i++)
                {
                    TimeSpan period = RescheduledAppointments[i].NewDocAppointment.AppointmentStart - ConflictingAppointments[i].AppointmentStart;
                    int days = (int)period.TotalHours;
                    TotalReshedulePeriodInHours += days;
                }
        }

        public void CheckIfConflictingIsUrgent()
        {
            bool valueSet = false;
            foreach(DoctorAppointmentDTO conflictiong in ConflictingAppointments)
            {
                if (conflictiong.IsUrgent)
                {
                    this.ConflictingIsUrgent = true;
                    valueSet = true;
                    break;
                }
            }

            if (!valueSet)
            {
                this.ConflictingIsUrgent = false;
            }
            
            return;

        }

    }
}
