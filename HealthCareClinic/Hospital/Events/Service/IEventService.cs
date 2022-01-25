using ClinicCore.Service;
using Hospital.Events.Model;
using System;
using System.Collections.Generic;
using System.Text;

namespace Hospital.Events.Service
{
    public interface IEventService : IService<Event>
    {
        void AddEventSession(EventSession eventSession);
        void AddEvents(List<Event> events, int sessionId);
    }
}
