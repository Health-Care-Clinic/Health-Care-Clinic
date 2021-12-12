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
        public Boolean checkRooms(Room room1, Room room2);
        public void ChangeRoomDimensionsMerge(int firstRoomId, int secondRoomId);
        public void ChangeRoomDimensionsDivide(int firstRoomId, int secondRoomId);
    }
}
