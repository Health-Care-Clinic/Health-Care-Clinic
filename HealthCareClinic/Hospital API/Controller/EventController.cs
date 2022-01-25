using Hospital.Events.Model;
using Hospital.Events.Service;
using Hospital_API.Adapter;
using Hospital_API.DTO;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Hospital_API.Controller
{
    [Route("api/[controller]")]
    [ApiController]
    public class EventController : ControllerBase
    {
        private readonly IEventService _eventService;

        public EventController(IEventService eventService)
        {
            _eventService = eventService;
        }

        [HttpGet("getAllEvents")]
        public IActionResult GetAllEvents()
        {
            List<EventDTO> eventDTOs = EventAdapter.EventsToEventDTOs((List<Event>) _eventService.GetAll());
            return Ok(eventDTOs);
        }

        [HttpPost("createEventSession")]
        public IActionResult CreateEventSession(EventSessionDTO eventSessionDTO)
        {
            EventSession eventSession = new EventSession(eventSessionDTO.ResultedInSucces, eventSessionDTO.UserId);

            _eventService.AddEventSession(eventSession);
            _eventService.AddEvents(EventAdapter.EventSessionDTOToEvents(eventSessionDTO.Events), eventSession.Id);

            return Ok();
        }
    }
}
