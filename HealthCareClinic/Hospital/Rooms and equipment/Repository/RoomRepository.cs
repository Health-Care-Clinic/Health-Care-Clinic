using ClinicCore.Storages;
using Hospital.Mapper;
using Hospital.Rooms_and_equipment.Model;
using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.EntityFrameworkCore;
using System.Linq;

namespace Hospital.Rooms_and_equipment.Repository
{
    public class RoomRepository : Repository<Room>, IRoomRepository
    {
        public RoomRepository(HospitalDbContext context) : base(context)
        {
        }

        public HospitalDbContext HospitalDbContext
        {
            get { return Context as HospitalDbContext; }
        }

        public List<Room> GetRoomsByFloorId(int id)
        {
            return Context.Set<Room>().Where(c => c.FloorId == id).ToList();
        }
    }
}
