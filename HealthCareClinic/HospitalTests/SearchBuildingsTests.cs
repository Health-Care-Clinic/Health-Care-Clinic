using Hospital.Mapper;
using Hospital.Rooms_and_equipment.Model;
using Hospital.Rooms_and_equipment.Repository;
using Hospital.Rooms_and_equipment.Service;
using Hospital_API.Controller;
using Hospital_API.DTO;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Moq;
using Shouldly;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using Xunit;
using static Hospital.Rooms_and_equipment.Model.Building;

namespace HospitalTests
{
    public class SearchBuildingsTests
    {
        private DbContextOptions<HospitalDbContext> CreateStubRepository()
        {
            var options = new DbContextOptionsBuilder<HospitalDbContext>()
            .UseInMemoryDatabase(databaseName: "Buildings")
            .Options;

            using (var context = new HospitalDbContext(options))
            {
                context.Buildings.Add(new Building { Id = 1, Name = "Building1", Type = BuildingType.Hospital, X = 10, Y = 10, Width = 100, Height = 200 });
                context.Buildings.Add(new Building { Id = 2, Name = "Solitaire", Type = BuildingType.Hospital, X = 100, Y = 100, Width = 190, Height = 110 });
                context.Buildings.Add(new Building { Id = 3, Name = "B2", Type = BuildingType.Hospital, X = 212, Y = 120, Width = 150, Height = 150 });
                context.SaveChanges();
            }

            return options;
        }

        [Fact]
        public void Get_buildings_by_name()
        {
            var options = CreateStubRepository();

            using (var context = new HospitalDbContext(options))
            {
                BuildingController buildingController = new BuildingController(context);
                
                OkObjectResult a = buildingController.GetSearchedBuildings("b") as OkObjectResult;
                List<BuildingDTO> buildings = a.Value as List<BuildingDTO>;
                foreach (Building b in context.Buildings)
                {
                    context.Buildings.Remove(b);
                    context.SaveChanges();
                }

                Assert.Equal(2, buildings.Count);
            }
        }

        [Fact]
        public void Get_no_buildings_by_name()
        {
            var options = CreateStubRepository();

            using (var context = new HospitalDbContext(options))
            {
                BuildingController buildingController = new BuildingController(context);
                
                OkObjectResult a = buildingController.GetSearchedBuildings("ek") as OkObjectResult;
                List<BuildingDTO> buildings = a.Value as List<BuildingDTO>;
                foreach (Building b in context.Buildings)
                {
                    context.Buildings.Remove(b);
                    context.SaveChanges();
                }

                Assert.Empty(buildings);
            }
        }

        [Fact]
        public void Search_buildings_by_name()
        {
            var builder = new ConfigurationBuilder().SetBasePath(Directory.GetCurrentDirectory()).AddJsonFile("appsettings.json");
            var configuration = builder.Build();
            var optionsBuilder = new DbContextOptionsBuilder<HospitalDbContext>();
            optionsBuilder.UseNpgsql(configuration.GetConnectionString("HospitalDbConnectionString"));
            var _context = new HospitalDbContext(optionsBuilder.Options);
            BuildingRepository buildingRepository = new BuildingRepository(_context);
            BuildingService buildingService = new BuildingService(buildingRepository);

            int numberOfSearchedBuildings = buildingService.GetSearchedBuildings("building2").Count;

            Assert.Equal(1, numberOfSearchedBuildings);
        }
    }
}
