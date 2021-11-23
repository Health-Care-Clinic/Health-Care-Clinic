using ClinicCore.Storages;
using Hospital.Rooms_and_equipment.Model;
using System;
using System.Collections.Generic;
using System.Text;

namespace Hospital.Rooms_and_equipment.Repository
{
    public interface IBuildingRepository : IRepository<Building>
    {
        public void Change(Building entity);
        
    }
}
