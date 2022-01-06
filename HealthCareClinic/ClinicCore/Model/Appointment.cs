using ClinicCore.Model;
using Enums;
using System;

namespace Model
{
    public class Appointment: Entity
    {

        public Boolean Reserved { get; set; }

        public String AppointmentCause { get; set; }

        public  DateTime AppointmentStart { get; set; }
       
        public DateTime AppointmentEnd { get; set; }
        
        public AppointmentType Type { get; set; }
        
        public int Room { get; set; }

       

        public Appointment(bool reserved, string appointmentCause, DateTime appointmentStart, DateTime appointmentEnd, AppointmentType type, int room)
        {
            Reserved = reserved;
            AppointmentCause = appointmentCause;
            AppointmentStart = appointmentStart;
            AppointmentEnd = appointmentEnd;
            Type = type;
            Room = room;
        }

        public Appointment(DateTime date, AppointmentType type, bool reserved, int room)
        {
            AppointmentStart = date;
            if (type.Equals(AppointmentType.CheckUp))
            {
                AppointmentEnd = AppointmentStart.AddMinutes(30);
            }
            Type = type;
            Reserved = reserved;
            Room = room;
        }
        
        public Appointment()
        {
        }

        public Appointment(DateTime appointmentstart, DateTime appointmentEnd, AppointmentType type, int room)
        {
            AppointmentStart = appointmentstart;
            AppointmentEnd = appointmentEnd;
            Type = type;
            Room = room;
        }

        public Appointment(bool reserved, string appointmentCause, DateTime appointmentStart, DateTime appointmentEnd, AppointmentType type, int room, int id)
        {
            Reserved = reserved;
            AppointmentCause = appointmentCause;
            AppointmentStart = appointmentStart;
            AppointmentEnd = appointmentEnd;
            Type = type;
            Room = room;
            Id = id;
        }
    }
}
