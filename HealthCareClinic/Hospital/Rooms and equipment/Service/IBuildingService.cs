using ClinicCore.Service;
using Hospital.Rooms_and_equipment.Model;
using System;
using System.Collections.Generic;
using System.Text;

namespace Hospital.Rooms_and_equipment.Service
{
    public interface IBuildingService : IService<Building>
    {
        public List<Building> GetSearchedBuildings(string searchText);
    }
}
