using ClinicCore.Storages;
using Hospital.Rooms_and_equipment.Model;
using System;
using System.Collections.Generic;
using System.Text;

namespace Hospital.Rooms_and_equipment.Repository
{
    public interface IRoomRepository : IRepository<Room>
    {
        public void RemoveById(int id);
        public List<Room> GetRoomsByFloorId(int id);
        public List<Room> GetSearchedRooms(string searchText);
    }
}
