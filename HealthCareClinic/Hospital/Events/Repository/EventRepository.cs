using ClinicCore.Storages;
using Hospital.Events.Model;
using Hospital.Mapper;
using System;
using System.Collections.Generic;
using System.Text;

namespace Hospital.Events.Repository
{
    public class EventRepository : Repository<Event>, IEventRepository
    {

        public EventRepository(EventsDbContext context) : base(context)
        { 
        }
    }
}
