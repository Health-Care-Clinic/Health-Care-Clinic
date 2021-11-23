using ClinicCore.Storages;
using Hospital.Rooms_and_equipment.Model;
using System;
using System.Collections.Generic;
using System.Text;

namespace Hospital.Rooms_and_equipment.Repository
{
    public interface IFloorRepository : IRepository<Floor>
    {
        public List<Floor> GetFloorsByBuildingId(int id);
    }
}
