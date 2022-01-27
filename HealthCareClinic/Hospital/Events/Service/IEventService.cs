using ClinicCore.Service;
using Hospital.Events.Model;
using Hospital.Rooms_and_equipment.Model;
using System;
using System.Collections.Generic;
using System.Text;

namespace Hospital.Events.Service
{
    public interface IEventService : IService<Event>
    {
        public Transfer GetMostFrequentEvent();
    }
}
