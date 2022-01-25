using Hospital.Events.Model;
using Hospital.Mapper;
using Hospital.Shared_model.Repository;
using System;
using System.Collections.Generic;
using System.Text;

namespace Hospital.Events.Repository
{
    public class EventSessionRepository : Repository<EventSession>, IEventSessionRepository
    {
        public EventSessionRepository(EventsDbContext context) : base(context)
        {
        }
    }
}
