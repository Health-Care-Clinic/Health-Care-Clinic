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

        public void RemoveById(int id)
        {
           _roomRepository.RemoveById(id);
        }

        public List<Room> GetRoomsByFloorId(int id)
        {
            return _roomRepository.GetRoomsByFloorId(id);
        }

        public List<Room> GetSearchedRooms(string searchText)
        {
            return _roomRepository.GetSearchedRooms(searchText);
        }

        public Boolean checkRooms(Room room1, Room room2)
        {
            if (room1.FloorId != room2.FloorId)
                return false;

            if (room1.PositionAndDimension.Y != room2.PositionAndDimension.Y)
                return false;
            else {
                if ((room1.PositionAndDimension.X + room1.PositionAndDimension.Width) != room2.PositionAndDimension.X)
                {
                    if ((room2.PositionAndDimension.X + room2.PositionAndDimension.Width) != room1.PositionAndDimension.X)
                        return false;
                }
            }

            return true;
        }

        public void ChangeRoomDimensionsMerge(int firstRoomId, int secondRoomId)
        {
            Room room1 = GetOneById(firstRoomId);
            Room room2 = GetOneById(secondRoomId);

            if ((room1.PositionAndDimension.X + room1.PositionAndDimension.Width) == room2.PositionAndDimension.X)
            {
                _roomRepository.ChangeMergedDimensions(firstRoomId, room1.PositionAndDimension.X, room1.PositionAndDimension.Width + room2.PositionAndDimension.Width);
            }
            else if ((room2.PositionAndDimension.X + room2.PositionAndDimension.Width) == room1.PositionAndDimension.X)
            {
                _roomRepository.ChangeMergedDimensions(firstRoomId, room1.PositionAndDimension.X - room2.PositionAndDimension.Width, room1.PositionAndDimension.Width + room2.PositionAndDimension.Width);
            }

        }

        public void ChangeRoomDimensionsDivide(int firstRoomId, int secondRoomId)
        {
            Room room1 = GetOneById(firstRoomId);

            float x = room1.PositionAndDimension.X;
            float y = room1.PositionAndDimension.Y;
            float width = room1.PositionAndDimension.Width / 2;
            float height = room1.PositionAndDimension.Height;
            _roomRepository.ChangeDividedDimensions(firstRoomId, x, y, width, height);
            _roomRepository.ChangeDividedDimensions(secondRoomId, x + width, y, width, height);

        }

    }
}
