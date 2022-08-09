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

        public EventService(IEventRepository eventRepository)
        {
            _eventRepository = eventRepository;
        }
        public void Add(Event entity)
        {
            _eventRepository.Add(entity);
            _eventRepository.Save();
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
