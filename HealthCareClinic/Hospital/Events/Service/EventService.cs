using Hospital.Events.Model;
using Hospital.Events.Repository;
using System;
using System.Collections.Generic;
using System.Text;

namespace Hospital.Events.Service
{
    public class EventService : IEventService
    {
        private readonly IEventRepository _eventRepository;
        private readonly IEventSessionRepository _eventSessionRepository;

        public EventService(IEventRepository eventRepository, IEventSessionRepository eventSessionRepository)
        {
            _eventRepository = eventRepository;
            _eventSessionRepository = eventSessionRepository;
        }
        public void Add(Event entity)
        {
            _eventRepository.Add(entity);
        }

        public void AddEvents(List<Event> events, int sessionId)
        {
            foreach (Event e in events)
            {
                e.SessionId = sessionId;
                Add(e);
            }
        }

        public void AddEventSession(EventSession eventSession)
        {
            _eventSessionRepository.Add(eventSession);
        }

        public IEnumerable<Event> GetAll()
        {
            return _eventRepository.GetAll();
        }

        public Event GetOneById(int id)
        {
            throw new NotImplementedException();
        }

        public void Remove(Event entity)
        {
            throw new NotImplementedException();
        }
    }
}
