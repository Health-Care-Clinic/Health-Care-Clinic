using Hospital.Rooms_and_equipment.Model;
using System;
using System.Collections.Generic;
using System.Text;
using ClinicCore.Storages;

namespace Hospital.Rooms_and_equipment.Repository
{
    public interface IRenovationRepository : IRepository<Renovation>
    {
        public void RemoveById(int id);
    }
}
