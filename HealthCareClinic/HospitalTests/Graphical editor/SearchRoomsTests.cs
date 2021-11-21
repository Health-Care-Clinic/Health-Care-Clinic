using Hospital.Mapper;
using Hospital.Rooms_and_equipment.Model;
using Hospital.Rooms_and_equipment.Repository;
using Hospital.Rooms_and_equipment.Service;
using Hospital_API.Controller;
using Hospital_API.DTO;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using Xunit;
using static Hospital.Rooms_and_equipment.Model.Room;

namespace HospitalTests.Graphical_editor
{
    public class SearchRoomsTests
    {
        private DbContextOptions<HospitalDbContext> CreateStubRepository()
        {
            var options = new DbContextOptionsBuilder<HospitalDbContext>()
            .UseInMemoryDatabase(databaseName: "Rooms")
            .Options;

            using (var context = new HospitalDbContext(options))
            {
                context.Rooms.Add(new Room { Id = 1, Name = "Operation room 1", Type = RoomType.OperationRoom, X = 10, Y = 10, Width = 100, Height = 200, FloorId = 1 });
                context.Rooms.Add(new Room { Id = 2, Name = "Operation room 2", Type = RoomType.OperationRoom, X = 100, Y = 100, Width = 190, Height = 110, FloorId = 1 });
                context.Rooms.Add(new Room { Id = 3, Name = "Room for appointments", Type = RoomType.RoomForAppointments, X = 212, Y = 120, Width = 150, Height = 150, FloorId = 2 });
                context.SaveChanges();
            }

            return options;
        }

        [Fact]
        public void Get_rooms_by_name()
        {
            var options = CreateStubRepository();

            using (var context = new HospitalDbContext(options))
            {
                RoomRepository roomRepository = new RoomRepository(context);
                RoomService roomService = new RoomService(roomRepository);
                RoomController roomController = new RoomController(roomService);

                OkObjectResult a = roomController.GetSearchedRooms("op") as OkObjectResult;
                List<RoomDTO> rooms = a.Value as List<RoomDTO>;
                foreach (Room r in context.Rooms)
                {
                    context.Rooms.Remove(r);
                    context.SaveChanges();
                }

                Assert.Equal(2, rooms.Count);
            }
        }

        [Fact]
        public void Get_no_rooms_by_name()
        {
            var options = CreateStubRepository();

            using (var context = new HospitalDbContext(options))
            {
                RoomRepository roomRepository = new RoomRepository(context);
                RoomService roomService = new RoomService(roomRepository);
                RoomController roomController = new RoomController(roomService);

                OkObjectResult a = roomController.GetSearchedRooms("wc") as OkObjectResult;
                List<RoomDTO> rooms = a.Value as List<RoomDTO>;
                foreach (Room r in context.Rooms)
                {
                    context.Rooms.Remove(r);
                    context.SaveChanges();
                }

                Assert.Empty(rooms);
            }
        }

        [Fact]
        public void Search_rooms_by_name()
        {
            var builder = new ConfigurationBuilder().SetBasePath(Directory.GetCurrentDirectory()).AddJsonFile("appsettings.json");
            var configuration = builder.Build();
            var optionsBuilder = new DbContextOptionsBuilder<HospitalDbContext>();
            optionsBuilder.UseNpgsql(configuration.GetConnectionString("HospitalDbConnectionString"));
            var _context = new HospitalDbContext(optionsBuilder.Options);
            RoomRepository roomRepository = new RoomRepository(_context);
            RoomService roomService = new RoomService(roomRepository);

            int numberOfSearchedRooms = roomService.GetSearchedRooms("operation room").Count;

            Assert.Equal(10, numberOfSearchedRooms);
        }
    }
}
