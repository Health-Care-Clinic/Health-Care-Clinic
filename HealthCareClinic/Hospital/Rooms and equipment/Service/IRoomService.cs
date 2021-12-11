using ClinicCore.Service;
using Hospital.Rooms_and_equipment.Model;
using System;
using System.Collections.Generic;
using System.Text;

namespace Hospital.Rooms_and_equipment.Service
{
    public interface IRoomService : IService<Room>
    {
        public void RemoveById(int id);
        public List<Room> GetRoomsByFloorId(int id);
        public List<Room> GetSearchedRooms(string searchText);
    }
}
