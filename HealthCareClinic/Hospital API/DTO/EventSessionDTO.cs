using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Hospital_API.DTO
{
    public class EventSessionDTO
    {
        public int Id { get; set; }

        public bool ResultedInSucces { get; set; }

        public int UserId { get; set; }

        public List<EventDTO> Events { get; set; }

        public EventSessionDTO() { }

        public EventSessionDTO(int id, bool success, List<EventDTO> eventDTOs)
        {
            Id = id;
            ResultedInSucces = success;
            Events = eventDTOs;
        }
    }
}
