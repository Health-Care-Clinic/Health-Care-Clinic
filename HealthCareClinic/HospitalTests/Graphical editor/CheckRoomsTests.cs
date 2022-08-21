using Hospital.Graphical_editor.Model;
using Hospital.Mapper;
using Hospital.Rooms_and_equipment.Model;
using Hospital.Rooms_and_equipment.Repository;
using Hospital.Rooms_and_equipment.Service;
using Hospital_API.Controller;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Shouldly;
using System;
using System.Collections.Generic;
using System.Text;
using Moq;
using Xunit;
using Hospital_API.Adapter;

namespace HospitalUnitTests.Graphical_editor
{
    public class CheckRoomsTests
    {

        [Fact]
        public void Check_is_room1_next_to_room2_when_true()
        {
            var rooms = new List<Room>();
            var room1 = new Room { Id = 1, Name = "Operation room 1", Type = Room.RoomType.OperationRoom, PositionAndDimension = new PositionAndDimension(10, 100, 100, 200), FloorId = 1 };
            var room2 = new Room { Id = 2, Name = "Operation room 2", Type = Room.RoomType.OperationRoom, PositionAndDimension = new PositionAndDimension(110, 100, 190, 110), FloorId = 1 };
            rooms.Add(room1);
            rooms.Add(room2);
            var roomService = new Mock<IRoomService>();
            RoomController roomController = new RoomController(roomService.Object);
            roomService.Setup(r => r.GetAll()).Returns(rooms);
            roomService.Setup(s => s.checkRooms(room1, room2)).Returns(true);

            var isFirstNextToSecond = roomController.IsFirstRoomNextToSecond(1, 2);

            isFirstNextToSecond.ShouldBeTrue();
        }

        [Fact]
        public void Check_is_room1_next_to_room2_when_false()
        {
            var rooms = new List<Room>();
            var room1 = new Room { Id = 1, Name = "Operation room 1", Type = Room.RoomType.OperationRoom, PositionAndDimension = new PositionAndDimension(10, 100, 100, 200), FloorId = 1 };
            var room2 = new Room { Id = 2, Name = "Operation room 2", Type = Room.RoomType.OperationRoom, PositionAndDimension = new PositionAndDimension(110, 100, 190, 110), FloorId = 2 };
            rooms.Add(room1);
            rooms.Add(room2);
            var roomService = new Mock<IRoomService>();
            RoomController roomController = new RoomController(roomService.Object);
            roomService.Setup(r => r.GetAll()).Returns(rooms);
            roomService.Setup(s => s.checkRooms(room1, room2)).Returns(false);

            var isFirstNextToSecond = roomController.IsFirstRoomNextToSecond(1, 2);

            isFirstNextToSecond.ShouldBeFalse();
        }
    }
}
