using Hospital.Graphical_editor.Model;
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
            room.PositionAndDimension = new PositionAndDimension(dto.X, dto.Y, dto.Width, dto.Height);

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
            dto.Width = room.PositionAndDimension.Width;
            dto.Height = room.PositionAndDimension.Height;
            dto.X = room.PositionAndDimension.X;
            dto.Y = room.PositionAndDimension.Y;

            return dto;
        }
    }
}
