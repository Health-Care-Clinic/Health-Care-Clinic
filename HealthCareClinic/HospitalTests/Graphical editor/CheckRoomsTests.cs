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
                context.Rooms.Add(new Room { Id = 1, Name = "Operation room 1", Type = Room.RoomType.OperationRoom, X = 10, Y = 100, Width = 100, Height = 200, FloorId = 1 });
                context.Rooms.Add(new Room { Id = 2, Name = "Operation room 2", Type = Room.RoomType.OperationRoom, X = 110, Y = 100, Width = 190, Height = 110, FloorId = 1 });
                context.Rooms.Add(new Room { Id = 3, Name = "Room for appointments", Type = Room.RoomType.RoomForAppointments, X = 212, Y = 120, Width = 150, Height = 150, FloorId = 2 });
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
