using ClinicCore.Storages;
using Hospital.Mapper;
using Hospital.Rooms_and_equipment.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Hospital.Rooms_and_equipment.Repository
{
    public class BuildingRepository : Repository<Building>, IBuildingRepository
    {
        public BuildingRepository(HospitalDbContext context) : base(context)
        {
        }

        public HospitalDbContext HospitalDbContext
        {
            get { return Context as HospitalDbContext; }
        }
        public void Change(Building entity)
        {
            Context.Set<Building>().Find(entity.Id).Name = entity.Name;
            Save();

        }

        public List<Building> GetSearchedBuildings(string searchText)
        {
            return Context.Set<Building>().Where(c => c.Name.ToLower().StartsWith(searchText.ToLower()) && c.Type == Building.BuildingType.Hospital).OrderBy(x => x.Id).ToList();
        }
    }


}
