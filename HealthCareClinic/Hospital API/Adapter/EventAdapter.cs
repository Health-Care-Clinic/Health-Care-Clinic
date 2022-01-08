using Hospital.Events.Model;
using Hospital_API.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Hospital_API.Adapter
{
    public class EventAdapter
    {
        public static Event EventDTOToEvent(EventDTO dto)
        {
            Event ev = new Event();
            ev.Id = dto.Id;
            ev.Timestamp = dto.Timestamp;
            ev.Content = dto.Content;
            ev.UserId = dto.UserId;
            return ev;
        }
        public static EventDTO EventToEventDTO(Event ev)
        {
            EventDTO dto = new EventDTO();
            dto.Id = ev.Id;
            dto.Timestamp = ev.Timestamp;
            dto.Content = ev.Content;
            dto.UserId = ev.UserId;
            return dto;
        }

        public static List<EventDTO> EventsToEventDTOs(List<Event> events)
        {
            List<EventDTO> eventDTOs = new List<EventDTO>();
            foreach (Event ev in events)
            {
                EventDTO dto = EventToEventDTO(ev);
                eventDTOs.Add(dto);
            }
            return eventDTOs;
        }
    }
}
