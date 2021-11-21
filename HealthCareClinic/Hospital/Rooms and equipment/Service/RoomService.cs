using Hospital.Mapper;
using Hospital.Rooms_and_equipment.Model;
using Hospital.Rooms_and_equipment.Repository;
using System;
using System.Collections.Generic;
using System.Text;

namespace Hospital.Rooms_and_equipment.Service
{
    public class RoomService : IRoomService
    {
        private IRoomRepository _roomRepository;

        public RoomService(IRoomRepository roomRepository)
        {
            this._roomRepository = roomRepository;
        }
        public void Add(Room entity)
        {
            _roomRepository.Add(entity);
        }

        public IEnumerable<Room> GetAll()
        {
            return _roomRepository.GetAll();
        }

        public Room GetOneById(int id)
        {
            return _roomRepository.GetById(id);
        }

        public void Remove(Room entity)
        {
            _roomRepository.Remove(entity);
        }

        public List<Room> GetRoomsByFloorId(int id)
        {
            return _roomRepository.GetRoomsByFloorId(id);
        }

        public List<Room> GetSearchedRooms(string searchText)
        {
            return _roomRepository.GetSearchedRooms(searchText);
        }
    }
}
