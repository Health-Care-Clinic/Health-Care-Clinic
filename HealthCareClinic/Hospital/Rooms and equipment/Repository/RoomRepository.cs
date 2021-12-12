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

        public void ChangeMergedDimensions(int roomId, float x, float width)
        {
            Context.Set<Room>().Find(roomId).X = x;
            Context.Set<Room>().Find(roomId).Width = width;
            Save();
        }

        public void ChangeDividedDimensions(int roomId, float x, float y, float width, float height)
        {
            Context.Set<Room>().Find(roomId).X = x;
            Context.Set<Room>().Find(roomId).Y = y;
            Context.Set<Room>().Find(roomId).Width = width;
            Context.Set<Room>().Find(roomId).Height = height;
            Save();
        }


    }
}
