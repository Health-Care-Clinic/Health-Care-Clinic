using ClinicCore.Storages;
using Hospital.Events.Model;
using System;
using System.Collections.Generic;
using System.Text;

namespace Hospital.Events.Repository
{
    public interface IEventRepository : IRepository<Event>
    {
    }
}
