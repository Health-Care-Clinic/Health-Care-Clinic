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
using Xunit;

namespace HospitalUnitTests.Graphical_editor
{
    public class CheckRoomsTests
    {
        private DbContextOptions<HospitalDbContext> CreateStubRepository()
        {
            var options = new DbContextOptionsBuilder<HospitalDbContext>()
            .UseInMemoryDatabase(databaseName: "Rooms1")
            .Options;

            using (var context = new HospitalDbContext(options))
            {
                context.Rooms.Add(new Room { Id = 1, Name = "Operation room 1", Type = Room.RoomType.OperationRoom, PositionAndDimension = new PositionAndDimension(10,100,100,200), FloorId = 1 });
                context.Rooms.Add(new Room { Id = 2, Name = "Operation room 2", Type = Room.RoomType.OperationRoom, PositionAndDimension = new PositionAndDimension(110, 100, 190, 110), FloorId = 1 });
                context.Rooms.Add(new Room { Id = 3, Name = "Room for appointments", Type = Room.RoomType.RoomForAppointments, PositionAndDimension = new PositionAndDimension(212, 120, 150, 150), FloorId = 2 });
                context.SaveChanges();
            }

            return options;
        }

        [Fact]
        public void Check_is_room1_next_to_room2()
        {
            var options = CreateStubRepository();

            using (var context = new HospitalDbContext(options))
            {
                RoomRepository roomRepository = new RoomRepository(context);
                RoomService roomService = new RoomService(roomRepository);
                RoomController roomController = new RoomController(roomService);
                Boolean ret = roomController.IsFirstRoomNextToSecond(1, 2);
                foreach (Room r in context.Rooms)
                {
                    context.Rooms.Remove(r);
                    context.SaveChanges();
                }
                ret.ShouldBeTrue();
            }
        }

        private void ClearStubRepository(HospitalDbContext context)
        {
            foreach (Room r in context.Rooms)
            {
                context.Rooms.Remove(r);
                context.SaveChanges();
            }
        }
    }
}
