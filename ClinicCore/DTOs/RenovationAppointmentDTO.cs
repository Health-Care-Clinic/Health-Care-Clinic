using System;

namespace ClinicCore.DTOs
{
    public class RenovationAppointmentDTO
    {
       
        public DateTime DateStart { get; set; }
        public int RoomIdSource { get; set; }
        public int RoomIdDestination { get; set; }

        public RenovationAppointmentDTO(DateTime dateStart, int roomIdSource, int roomIdDestination)
        {
            DateStart = dateStart;
            RoomIdSource = roomIdSource;
            RoomIdDestination = roomIdDestination;
        }
    }
}
