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

        public void RemoveById(int id)
        {
            Context.Set<Room>().Remove(Context.Set<Room>().Find(id));
            Context.SaveChanges();
        }

        public List<Room> GetRoomsByFloorId(int id)
        {
            return Context.Set<Room>().Where(c => c.FloorId == id).ToList();
        }

        public List<Room> GetSearchedRooms(string searchText)
        {
            return Context.Set<Room>().Where(c => c.Name.ToLower().StartsWith(searchText.ToLower())).OrderBy(x => x.Id).ToList();
        }
    }
}
