using Hospital.Rooms_and_equipment.Model;
using Hospital_API.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Hospital_API.Adapter
{
    public class RoomAdapter
    {
        public static Room RoomDTOToRoom(RoomDTO dto)
        {
            Room room = new Room();

            room.Id = dto.Id;
            room.Name = dto.Name;
            room.Type = dto.Type;
            room.FloorId = dto.FloorId;
            room.Description = dto.Description;
            room.Width = dto.Width;
            room.Height = dto.Height;
            room.X = dto.X;
            room.Y = dto.Y;

            return room;
        }

        public static RoomDTO RoomToRoomDTO(Room room)
        {
            RoomDTO dto = new RoomDTO();

            dto.Id = room.Id;
            dto.Name = room.Name;
            dto.Type = room.Type;
            dto.Description = room.Description;
            dto.FloorId = room.FloorId;
            dto.Width = room.Width;
            dto.Height = room.Height;
            dto.X = room.X;
            dto.Y = room.Y;

            return dto;
        }
    }
}
