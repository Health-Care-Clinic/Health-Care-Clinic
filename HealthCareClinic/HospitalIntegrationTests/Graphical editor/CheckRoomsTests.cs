using Hospital.Mapper;
using Hospital.Rooms_and_equipment.Repository;
using Hospital.Rooms_and_equipment.Service;
using Hospital_API.Controller;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Shouldly;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using Xunit;

namespace HospitalIntegrationTests.Graphical_editor
{
    public class CheckRoomsTests
    {
        [Fact]
        public void Check_is_room1_next_to_room2()
        {
            var builder = new ConfigurationBuilder().SetBasePath(Directory.GetCurrentDirectory()).AddJsonFile("appsettings.json");
            var configuration = builder.Build();
            var optionsBuilder = new DbContextOptionsBuilder<HospitalDbContext>();
            optionsBuilder.UseNpgsql(configuration.GetConnectionString("HospitalDbConnectionString"));
            var _context = new HospitalDbContext(optionsBuilder.Options);
            RoomRepository roomRepository = new RoomRepository(_context);
            RoomService roomService = new RoomService(roomRepository);
            RoomController roomController = new RoomController(roomService);

            Boolean ret = roomController.IsFirstRoomNextToSecond(1,8);

            ret.ShouldBeFalse();
        }
    }
}
