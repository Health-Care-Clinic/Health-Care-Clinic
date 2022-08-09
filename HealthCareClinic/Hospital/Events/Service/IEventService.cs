using ClinicCore.Service;
using Hospital.Events.Model;
using System;
using System.Collections.Generic;
using System.Text;

namespace Hospital.Events.Service
{
    public interface IEventService : IService<Event>
    {
    }
}
