using ClinicCore.Storages;
using Hospital.Mapper;
using Hospital.Rooms_and_equipment.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Hospital.Rooms_and_equipment.Repository
{
    public class FloorRepository : Repository<Floor>, IFloorRepository
    {
        public FloorRepository(HospitalDbContext context) : base(context)
        {
        }

        public HospitalDbContext HospitalDbContext
        {
            get { return Context as HospitalDbContext; }
        }

        public List<Floor> GetFloorsByBuildingId(int id)
        {
            return Context.Set<Floor>().Where(c => c.BuildingId == id).ToList();
        }
    }


}
