using ClinicCore.Storages;
using Hospital.Mapper;
using Hospital.Rooms_and_equipment.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Hospital.Rooms_and_equipment.Repository
{
    public class EquipmentRepository : Repository<Equipment>, IEquipmentRepository
    {
        public EquipmentRepository(HospitalDbContext context) : base(context)
        {
        }

        public HospitalDbContext HospitalDbContext
        {
            get { return Context as HospitalDbContext; }
        }

        public List<Equipment> GetEquipmentByRoomId(int id)
        {
            return Context.Set<Equipment>().Where(c => c.RoomId == id).ToList();
        }

        public List<Equipment> GetEquipmentByName(string name)
        {
            return Context.Set<Equipment>().Where(c => c.Name.ToLower().Contains(name.ToLower())).ToList();
        }

    }


}
