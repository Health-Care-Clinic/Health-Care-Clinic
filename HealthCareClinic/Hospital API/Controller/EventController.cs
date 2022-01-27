using Hospital.Events.Model;
using Hospital.Events.Service;
using Hospital.Rooms_and_equipment.Model;
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

        [HttpPost("createEvent")]
        public IActionResult CreateEvent(EventDTO eventDto)
        {
            Event ev = EventAdapter.EventDTOToEvent(eventDto);

            _eventService.Add(ev);

            return Ok();
        }

        [HttpGet("getMostFrequentEvent")]
        public IActionResult getMostFrequentEvents()
        {
            TransferDTO transferDTO = TransferAdapter.TransferToTransferDTO(_eventService.GetMostFrequentEvent());
            return Ok(transferDTO);
        }
    }
}
