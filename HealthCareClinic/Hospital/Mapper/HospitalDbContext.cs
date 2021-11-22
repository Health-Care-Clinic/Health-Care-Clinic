using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Hospital.Schedule.Model;

using Hospital.Rooms_and_equipment.Model;
using Microsoft.EntityFrameworkCore;
using static Hospital.Rooms_and_equipment.Model.Building;
using static Hospital.Rooms_and_equipment.Model.Equipment;
using static Hospital.Rooms_and_equipment.Model.Room;
using Hospital.Shared_model.Model;

namespace Hospital.Mapper
{
    public class HospitalDbContext : DbContext
    {
        public DbSet<FeedbackMessage> FeedbackMessages { get; set; }

        public DbSet<Building> Buildings { get; set; }

        public DbSet<Floor> Floors { get; set; }

        public DbSet<Room> Rooms { get; set; }

        public DbSet<Survey> Surveys { get; set; }
        public DbSet<SurveyCategory> SurveyCategories { get; set; }
        public DbSet<SurveyQuestion> SurveyQuestions { get; set; }

        public DbSet<Appointment> Appointments { get; set; }

        public DbSet<Equipment> Equipments { get; set; }
        public HospitalDbContext(DbContextOptions<HospitalDbContext> options) : base(options) { }

        // only for testing purposes
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Equipment>().HasData(
                new Equipment { Id = 1, Name = "Bed", Type = EquipmentType.Static, Quantity = 5, RoomId = 1 },
                new Equipment { Id = 2, Name = "Needle", Type = EquipmentType.Dynamic, Quantity = 25, RoomId = 1 },
                new Equipment { Id = 3, Name = "TV", Type = EquipmentType.Static, Quantity = 1, RoomId = 1 },
                new Equipment { Id = 4, Name = "Bandage", Type = EquipmentType.Dynamic, Quantity = 10, RoomId = 1 },
                new Equipment { Id = 5, Name = "Blanket", Type = EquipmentType.Static, Quantity = 5, RoomId = 1 },

                new Equipment { Id = 6, Name = "Bed", Type = EquipmentType.Static, Quantity = 2, RoomId = 2 },
                new Equipment { Id = 7, Name = "Needle", Type = EquipmentType.Dynamic, Quantity = 3, RoomId = 2 },
                new Equipment { Id = 8, Name = "TV", Type = EquipmentType.Static, Quantity = 3, RoomId = 4 },
                new Equipment { Id = 9, Name = "Bandage", Type = EquipmentType.Dynamic, Quantity = 5, RoomId = 4 },
                new Equipment { Id = 10, Name = "Blanket", Type = EquipmentType.Static, Quantity = 2, RoomId = 4 },

                new Equipment { Id = 11, Name = "Bed", Type = EquipmentType.Static, Quantity = 25, RoomId = 8 },
                new Equipment { Id = 12, Name = "Needle", Type = EquipmentType.Dynamic, Quantity = 3, RoomId = 9 },
                new Equipment { Id = 13, Name = "TV", Type = EquipmentType.Static, Quantity = 4, RoomId = 9 },
                new Equipment { Id = 14, Name = "Bandage", Type = EquipmentType.Dynamic, Quantity = 6, RoomId = 11 },
                new Equipment { Id = 15, Name = "Blanket", Type = EquipmentType.Static, Quantity = 5, RoomId = 11 },

                new Equipment { Id = 16, Name = "Bed", Type = EquipmentType.Static, Quantity = 26, RoomId = 15 },
                new Equipment { Id = 17, Name = "Needle", Type = EquipmentType.Dynamic, Quantity = 23, RoomId = 17 },
                new Equipment { Id = 18, Name = "TV", Type = EquipmentType.Static, Quantity = 1, RoomId = 17 },
                new Equipment { Id = 19, Name = "Bandage", Type = EquipmentType.Dynamic, Quantity = 120, RoomId = 17 },
                new Equipment { Id = 20, Name = "Blanket", Type = EquipmentType.Static, Quantity = 52, RoomId = 18 },

                new Equipment { Id = 21, Name = "Bed", Type = EquipmentType.Static, Quantity = 1, RoomId = 20 },
                new Equipment { Id = 22, Name = "Needle", Type = EquipmentType.Dynamic, Quantity = 1, RoomId = 22 },
                new Equipment { Id = 23, Name = "TV", Type = EquipmentType.Static, Quantity = 1, RoomId = 22 },
                new Equipment { Id = 24, Name = "Bandage", Type = EquipmentType.Dynamic, Quantity = 1, RoomId = 23 },
                new Equipment { Id = 25, Name = "Blanket", Type = EquipmentType.Static, Quantity = 1, RoomId = 23 },

                new Equipment { Id = 26, Name = "Bed", Type = EquipmentType.Static, Quantity = 3, RoomId = 26 },
                new Equipment { Id = 27, Name = "Needle", Type = EquipmentType.Dynamic, Quantity = 2, RoomId = 26 },
                new Equipment { Id = 28, Name = "TV", Type = EquipmentType.Static, Quantity = 2, RoomId = 29 },
                new Equipment { Id = 29, Name = "Bandage", Type = EquipmentType.Dynamic, Quantity = 4, RoomId = 30 },
                new Equipment { Id = 30, Name = "Blanket", Type = EquipmentType.Static, Quantity = 4, RoomId = 30 },

                new Equipment { Id = 31, Name = "Bed", Type = EquipmentType.Static, Quantity = 7, RoomId = 36 },
                new Equipment { Id = 32, Name = "Needle", Type = EquipmentType.Dynamic, Quantity = 4, RoomId = 36 },
                new Equipment { Id = 33, Name = "TV", Type = EquipmentType.Static, Quantity = 3, RoomId = 40 },
                new Equipment { Id = 34, Name = "Bandage", Type = EquipmentType.Dynamic, Quantity = 1, RoomId = 40 },
                new Equipment { Id = 35, Name = "Blanket", Type = EquipmentType.Static, Quantity = 9, RoomId = 40 },

                new Equipment { Id = 36, Name = "Bed", Type = EquipmentType.Static, Quantity = 9, RoomId = 43 },
                new Equipment { Id = 37, Name = "Needle", Type = EquipmentType.Dynamic, Quantity = 9, RoomId = 43 },
                new Equipment { Id = 38, Name = "TV", Type = EquipmentType.Static, Quantity = 3, RoomId = 45 },
                new Equipment { Id = 39, Name = "Bandage", Type = EquipmentType.Dynamic, Quantity = 9, RoomId = 47 },
                new Equipment { Id = 40, Name = "Blanket", Type = EquipmentType.Static, Quantity = 9, RoomId = 47 },

                new Equipment { Id = 41, Name = "Bed", Type = EquipmentType.Static, Quantity = 7, RoomId = 50 },
                new Equipment { Id = 42, Name = "Needle", Type = EquipmentType.Dynamic, Quantity = 4, RoomId = 51 },
                new Equipment { Id = 43, Name = "TV", Type = EquipmentType.Static, Quantity = 1, RoomId = 52 },
                new Equipment { Id = 44, Name = "Bandage", Type = EquipmentType.Dynamic, Quantity = 11, RoomId = 55 },
                new Equipment { Id = 45, Name = "Blanket", Type = EquipmentType.Static, Quantity = 15, RoomId = 55 },

                new Equipment { Id = 46, Name = "Bed", Type = EquipmentType.Static, Quantity = 13, RoomId = 60 },
                new Equipment { Id = 47, Name = "Needle", Type = EquipmentType.Dynamic, Quantity = 13, RoomId = 60 },
                new Equipment { Id = 48, Name = "TV", Type = EquipmentType.Static, Quantity = 2, RoomId = 62 },
                new Equipment { Id = 49, Name = "Bandage", Type = EquipmentType.Dynamic, Quantity = 13, RoomId = 62 },
                new Equipment { Id = 50, Name = "Blanket", Type = EquipmentType.Static, Quantity = 13, RoomId = 65 },

                new Equipment { Id = 51, Name = "Bed", Type = EquipmentType.Static, Quantity = 17, RoomId = 65 },
                new Equipment { Id = 52, Name = "Needle", Type = EquipmentType.Dynamic, Quantity = 17, RoomId = 66 },
                new Equipment { Id = 53, Name = "TV", Type = EquipmentType.Static, Quantity = 2, RoomId = 68 },
                new Equipment { Id = 54, Name = "Bandage", Type = EquipmentType.Dynamic, Quantity = 17, RoomId = 69 },
                new Equipment { Id = 55, Name = "Blanket", Type = EquipmentType.Static, Quantity = 17, RoomId = 69 }
                );

            modelBuilder.Entity<Room>().HasData(
                new Room { Id = 1, Type = RoomType.OperationRoom, Name = "Operation room", Description = "Room description...", X = 320f, Y = 30f, Width = 400f, Height = 140f, FloorId = 1 },
                new Room { Id = 2, Type = RoomType.RoomForAppointments, Name = "Room for appointments", Description = "Room description...", X = 320, Y = 260, Width = 380, Height = 140, FloorId = 1 },
                new Room { Id = 3, Type = RoomType.RoomForAppointments, Name = "Room for appointments", Description = "Room description...", X = 50, Y = 260, Width = 270, Height = 140, FloorId = 1 },
                new Room { Id = 4, Type = RoomType.RoomForAppointments, Name = "Room for appointments", Description = "Room description...", X = 700, Y = 260, Width = 300, Height = 140, FloorId = 1 },
                new Room { Id = 5, Type = RoomType.RoomForAppointments, Name = "Room for appointments", Description = "Room description...", X = 50, Y = 30, Width = 270, Height = 140, FloorId = 1 },
                new Room { Id = 6, Type = RoomType.RoomForAppointments, Name = "Room for appointments", Description = "Room description...", X = 720, Y = 30, Width = 280, Height = 140, FloorId = 1 },
                new Room { Id = 7, Type = RoomType.WC, Name = "WC", Description = "Room description...", X = 50, Y = 170, Width = 150, Height = 90, FloorId = 1 },
                new Room { Id = 8, Type = RoomType.OperationRoom, Name = "Operation room", Description = "Room description...", X = 320f, Y = 30f, Width = 400f, Height = 140f, FloorId = 2 },
                new Room { Id = 9, Type = RoomType.RoomForAppointments, Name = "Room for appointments", Description = "Room description...", X = 320, Y = 260, Width = 380, Height = 140, FloorId = 2 },
                new Room { Id = 10, Type = RoomType.RoomForAppointments, Name = "Room for appointments", Description = "Room description...", X = 50, Y = 260, Width = 270, Height = 140, FloorId = 2 },
                new Room { Id = 11, Type = RoomType.RoomForAppointments, Name = "Room for appointments", Description = "Room description...", X = 700, Y = 260, Width = 300, Height = 140, FloorId = 2 },
                new Room { Id = 12, Type = RoomType.RoomForAppointments, Name = "Room for appointments", Description = "Room description...", X = 50, Y = 30, Width = 270, Height = 140, FloorId = 2 },
                new Room { Id = 13, Type = RoomType.RoomForAppointments, Name = "Room for appointments", Description = "Room description...", X = 720, Y = 30, Width = 280, Height = 140, FloorId = 2 },
                new Room { Id = 14, Type = RoomType.WC, Name = "WC", Description = "Room description...", X = 50, Y = 170, Width = 150, Height = 90, FloorId = 2 },
                new Room { Id = 15, Type = RoomType.OperationRoom, Name = "Operation room", Description = "Room description...", X = 320f, Y = 30f, Width = 400f, Height = 140f, FloorId = 3 },
                new Room { Id = 16, Type = RoomType.RoomForAppointments, Name = "Room for appointments", Description = "Room description...", X = 320, Y = 260, Width = 380, Height = 140, FloorId = 3 },
                new Room { Id = 17, Type = RoomType.RoomForAppointments, Name = "Room for appointments", Description = "Room description...", X = 50, Y = 260, Width = 270, Height = 140, FloorId = 3 },
                new Room { Id = 18, Type = RoomType.RoomForAppointments, Name = "Room for appointments", Description = "Room description...", X = 700, Y = 260, Width = 300, Height = 140, FloorId = 3 },
                new Room { Id = 19, Type = RoomType.RoomForAppointments, Name = "Room for appointments", Description = "Room description...", X = 50, Y = 30, Width = 270, Height = 140, FloorId = 3 },
                new Room { Id = 20, Type = RoomType.RoomForAppointments, Name = "Room for appointments", Description = "Room description...", X = 720, Y = 30, Width = 280, Height = 140, FloorId = 3 },
                new Room { Id = 21, Type = RoomType.WC, Name = "WC", Description = "Room description...", X = 50, Y = 170, Width = 150, Height = 90, FloorId = 3 },

                new Room { Id = 22, Type = RoomType.OperationRoom, Name = "Operation room", Description = "Room description...", X = 320f, Y = 30f, Width = 400f, Height = 140f, FloorId = 4 },
                new Room { Id = 23, Type = RoomType.RoomForAppointments, Name = "Room for appointments", Description = "Room description...", X = 320, Y = 260, Width = 380, Height = 140, FloorId = 4 },
                new Room { Id = 24, Type = RoomType.RoomForAppointments, Name = "Room for appointments", Description = "Room description...", X = 50, Y = 260, Width = 270, Height = 140, FloorId = 4 },
                new Room { Id = 25, Type = RoomType.RoomForAppointments, Name = "Room for appointments", Description = "Room description...", X = 700, Y = 260, Width = 300, Height = 140, FloorId = 4 },
                new Room { Id = 26, Type = RoomType.RoomForAppointments, Name = "Room for appointments", Description = "Room description...", X = 50, Y = 30, Width = 270, Height = 140, FloorId = 4 },
                new Room { Id = 27, Type = RoomType.RoomForAppointments, Name = "Room for appointments", Description = "Room description...", X = 720, Y = 30, Width = 280, Height = 140, FloorId = 4 },
                new Room { Id = 28, Type = RoomType.WC, Name = "WC", Description = "Room description...", X = 50, Y = 170, Width = 150, Height = 90, FloorId = 4 },
                new Room { Id = 29, Type = RoomType.OperationRoom, Name = "Operation room", Description = "Room description...", X = 320f, Y = 30f, Width = 400f, Height = 140f, FloorId = 5 },
                new Room { Id = 30, Type = RoomType.RoomForAppointments, Name = "Room for appointments", Description = "Room description...", X = 320, Y = 260, Width = 380, Height = 140, FloorId = 5 },
                new Room { Id = 31, Type = RoomType.RoomForAppointments, Name = "Room for appointments", Description = "Room description...", X = 50, Y = 260, Width = 270, Height = 140, FloorId = 5 },
                new Room { Id = 32, Type = RoomType.RoomForAppointments, Name = "Room for appointments", Description = "Room description...", X = 700, Y = 260, Width = 300, Height = 140, FloorId = 5 },
                new Room { Id = 33, Type = RoomType.RoomForAppointments, Name = "Room for appointments", Description = "Room description...", X = 50, Y = 30, Width = 270, Height = 140, FloorId = 5 },
                new Room { Id = 34, Type = RoomType.RoomForAppointments, Name = "Room for appointments", Description = "Room description...", X = 720, Y = 30, Width = 280, Height = 140, FloorId = 5 },
                new Room { Id = 35, Type = RoomType.WC, Name = "WC", Description = "Room description...", X = 50, Y = 170, Width = 150, Height = 90, FloorId = 5 },

                new Room { Id = 36, Type = RoomType.OperationRoom, Name = "Operation room", Description = "Room description...", X = 320f, Y = 30f, Width = 400f, Height = 140f, FloorId = 6 },
                new Room { Id = 37, Type = RoomType.RoomForAppointments, Name = "Room for appointments", Description = "Room description...", X = 320, Y = 260, Width = 380, Height = 140, FloorId = 6 },
                new Room { Id = 38, Type = RoomType.RoomForAppointments, Name = "Room for appointments", Description = "Room description...", X = 50, Y = 260, Width = 270, Height = 140, FloorId = 6 },
                new Room { Id = 39, Type = RoomType.RoomForAppointments, Name = "Room for appointments", Description = "Room description...", X = 700, Y = 260, Width = 300, Height = 140, FloorId = 6 },
                new Room { Id = 40, Type = RoomType.RoomForAppointments, Name = "Room for appointments", Description = "Room description...", X = 50, Y = 30, Width = 270, Height = 140, FloorId = 6 },
                new Room { Id = 41, Type = RoomType.RoomForAppointments, Name = "Room for appointments", Description = "Room description...", X = 720, Y = 30, Width = 280, Height = 140, FloorId = 6 },
                new Room { Id = 42, Type = RoomType.WC, Name = "WC", Description = "Room description...", X = 50, Y = 170, Width = 150, Height = 90, FloorId = 6 },
                new Room { Id = 43, Type = RoomType.OperationRoom, Name = "Operation room", Description = "Room description...", X = 320f, Y = 30f, Width = 400f, Height = 140f, FloorId = 7 },
                new Room { Id = 44, Type = RoomType.RoomForAppointments, Name = "Room for appointments", Description = "Room description...", X = 320, Y = 260, Width = 380, Height = 140, FloorId = 7 },
                new Room { Id = 45, Type = RoomType.RoomForAppointments, Name = "Room for appointments", Description = "Room description...", X = 50, Y = 260, Width = 270, Height = 140, FloorId = 7 },
                new Room { Id = 46, Type = RoomType.RoomForAppointments, Name = "Room for appointments", Description = "Room description...", X = 700, Y = 260, Width = 300, Height = 140, FloorId = 7 },
                new Room { Id = 47, Type = RoomType.RoomForAppointments, Name = "Room for appointments", Description = "Room description...", X = 50, Y = 30, Width = 270, Height = 140, FloorId = 7 },
                new Room { Id = 48, Type = RoomType.RoomForAppointments, Name = "Room for appointments", Description = "Room description...", X = 720, Y = 30, Width = 280, Height = 140, FloorId = 7 },
                new Room { Id = 49, Type = RoomType.WC, Name = "WC", Description = "Room description...", X = 50, Y = 170, Width = 150, Height = 90, FloorId = 7 },
                new Room { Id = 50, Type = RoomType.OperationRoom, Name = "Operation room", Description = "Room description...", X = 320f, Y = 30f, Width = 400f, Height = 140f, FloorId = 8 },
                new Room { Id = 51, Type = RoomType.RoomForAppointments, Name = "Room for appointments", Description = "Room description...", X = 320, Y = 260, Width = 380, Height = 140, FloorId = 8 },
                new Room { Id = 52, Type = RoomType.RoomForAppointments, Name = "Room for appointments", Description = "Room description...", X = 50, Y = 260, Width = 270, Height = 140, FloorId = 8 },
                new Room { Id = 53, Type = RoomType.RoomForAppointments, Name = "Room for appointments", Description = "Room description...", X = 700, Y = 260, Width = 300, Height = 140, FloorId = 8 },
                new Room { Id = 54, Type = RoomType.RoomForAppointments, Name = "Room for appointments", Description = "Room description...", X = 50, Y = 30, Width = 270, Height = 140, FloorId = 8 },
                new Room { Id = 55, Type = RoomType.RoomForAppointments, Name = "Room for appointments", Description = "Room description...", X = 720, Y = 30, Width = 280, Height = 140, FloorId = 8 },
                new Room { Id = 56, Type = RoomType.WC, Name = "WC", Description = "Room description...", X = 50, Y = 170, Width = 150, Height = 90, FloorId = 8 },

                new Room { Id = 57, Type = RoomType.OperationRoom, Name = "Operation room", Description = "Room description...", X = 320f, Y = 30f, Width = 400f, Height = 140f, FloorId = 9 },
                new Room { Id = 58, Type = RoomType.RoomForAppointments, Name = "Room for appointments", Description = "Room description...", X = 320, Y = 260, Width = 380, Height = 140, FloorId = 9 },
                new Room { Id = 59, Type = RoomType.RoomForAppointments, Name = "Room for appointments", Description = "Room description...", X = 50, Y = 260, Width = 270, Height = 140, FloorId = 9 },
                new Room { Id = 60, Type = RoomType.RoomForAppointments, Name = "Room for appointments", Description = "Room description...", X = 700, Y = 260, Width = 300, Height = 140, FloorId = 9 },
                new Room { Id = 61, Type = RoomType.RoomForAppointments, Name = "Room for appointments", Description = "Room description...", X = 50, Y = 30, Width = 270, Height = 140, FloorId = 9 },
                new Room { Id = 62, Type = RoomType.RoomForAppointments, Name = "Room for appointments", Description = "Room description...", X = 720, Y = 30, Width = 280, Height = 140, FloorId = 9 },
                new Room { Id = 63, Type = RoomType.WC, Name = "WC", Description = "Room description...", X = 50, Y = 170, Width = 150, Height = 90, FloorId = 9 },
                new Room { Id = 64, Type = RoomType.OperationRoom, Name = "Operation room", Description = "Room description...", X = 320f, Y = 30f, Width = 400f, Height = 140f, FloorId = 10 },
                new Room { Id = 65, Type = RoomType.RoomForAppointments, Name = "Room for appointments", Description = "Room description...", X = 320, Y = 260, Width = 380, Height = 140, FloorId = 10 },
                new Room { Id = 66, Type = RoomType.RoomForAppointments, Name = "Room for appointments", Description = "Room description...", X = 50, Y = 260, Width = 270, Height = 140, FloorId = 10 },
                new Room { Id = 67, Type = RoomType.RoomForAppointments, Name = "Room for appointments", Description = "Room description...", X = 700, Y = 260, Width = 300, Height = 140, FloorId = 10 },
                new Room { Id = 68, Type = RoomType.RoomForAppointments, Name = "Room for appointments", Description = "Room description...", X = 50, Y = 30, Width = 270, Height = 140, FloorId = 10 },
                new Room { Id = 69, Type = RoomType.RoomForAppointments, Name = "Room for appointments", Description = "Room description...", X = 720, Y = 30, Width = 280, Height = 140, FloorId = 10 },
                new Room { Id = 70, Type = RoomType.WC, Name = "WC", Description = "Room description...", X = 50, Y = 170, Width = 150, Height = 90, FloorId = 10 });

            modelBuilder.Entity<Floor>().HasData(
                new Floor { Id = 1, Name = "Floor 1", BuildingId = 1 },
                new Floor { Id = 2, Name = "Floor 2", BuildingId = 1 },
                new Floor { Id = 3, Name = "Floor 3", BuildingId = 1 },
                new Floor { Id = 4, Name = "Floor 1", BuildingId = 2 },
                new Floor { Id = 5, Name = "Floor 2", BuildingId = 2 },
                new Floor { Id = 6, Name = "Floor 1", BuildingId = 3 },
                new Floor { Id = 7, Name = "Floor 2", BuildingId = 3 },
                new Floor { Id = 8, Name = "Floor 3", BuildingId = 3 },
                new Floor { Id = 9, Name = "Floor 1", BuildingId = 4 },
                new Floor { Id = 10, Name = "Floor 2", BuildingId = 4 });

            modelBuilder.Entity<Building>().HasData(
                new Building { Id = 1, Name = "Building1", X = 260, Y = 30, Width = 400, Height = 140, Type = BuildingType.Hospital },
                new Building { Id = 2, Name = "Building2", X = 260, Y = 230, Width = 400, Height = 140, Type = BuildingType.Hospital },
                new Building { Id = 3, Name = "Building3", X = 30, Y = 130, Width = 180, Height = 240, Type = BuildingType.Hospital },
                new Building { Id = 4, Name = "Building4", X = 700, Y = 230, Width = 300, Height = 140, Type = BuildingType.Hospital },
                new Building { Id = 5, Name = "Parking1", X = 30, Y = 30, Width = 200, Height = 70, Type = BuildingType.Parking },
                new Building { Id = 6, Name = "Parking2", X = 800, Y = 30, Width = 200, Height = 70, Type = BuildingType.Parking },
                new Building { Id = 7, Name = "Parking3", X = 800, Y = 130, Width = 200, Height = 70, Type = BuildingType.Parking });

            modelBuilder.Entity<FeedbackMessage>().HasData(            
                new FeedbackMessage
                {
                    Id = 1,
                    Date = new DateTime(2021, 4, 29, 18, 34, 21),
                    Text = "Zadovoljan sam uslugom.",
                    IsAnonymous = false,
                    Identity = "acaNikolic",
                    CanBePublished = true,
                    IsPublished = false
                },
                new FeedbackMessage
                {
                    Id = 2,
                    Date = new DateTime(2021, 6, 21, 14, 21, 56),
                    Text = "Čekanje je moglo biti kraće.",
                    IsAnonymous = true,
                    Identity = "NikolaTodorovic94",
                    CanBePublished = true,
                    IsPublished = false
                },
                new FeedbackMessage
                {
                    Id = 3,
                    Date = new DateTime(2021, 2, 16, 11, 8, 47),
                    Text = "Informacionom sistemu potrebne su određene popravke.",
                    IsAnonymous = false,
                    Identity = "MarijaPopovic",
                    CanBePublished = false,
                    IsPublished = false
                },
                new FeedbackMessage
                {
                    Id = 4,
                    Date = new DateTime(2021, 5, 20, 9, 10, 21),
                    Text = "Odlični lekari.",
                    IsAnonymous = false,
                    Identity = "UrosDevic0",
                    CanBePublished = true,
                    IsPublished = false
                },
                new FeedbackMessage
                {
                    Id = 5,
                    Date = new DateTime(2021, 9, 30, 7, 50, 19),
                    Text = "Savremena bolnica koju bih preporučio ljudima.",
                    IsAnonymous = false,
                    Identity = "MladenAlicic1",
                    CanBePublished = true,
                    IsPublished = true
                },
                new FeedbackMessage
                {
                    Id = 6,
                    Date = new DateTime(2021, 9, 30, 7, 50, 19),
                    Text = "Savremena bolnica koju bih preporučio ljudima.",
                    IsAnonymous = false,
                    Identity = "IvanJovanovic",
                    CanBePublished = true,
                    IsPublished = true
                },
                new FeedbackMessage
                {
                    Id = 7,
                    Date = new DateTime(2021, 9, 30, 7, 50, 19),
                    Text = "Savremena bolnica koju bih preporučio ljudima.",
                    IsAnonymous = false,
                    Identity = "JovanaGugl",
                    CanBePublished = true,
                    IsPublished = true
                },
                new FeedbackMessage
                {
                    Id = 8,
                    Date = new DateTime(2021, 9, 30, 7, 50, 19),
                    Text = "Savremena bolnica koju bih preporučio ljudima.",
                    IsAnonymous = false,
                    Identity = "RatkoVarda8",
                    CanBePublished = true,
                    IsPublished = true
                }
            );

            //modelBuilder.Entity<SurveyQuestion>().HasOne(sq => sq.Survey)
            //                                     .WithMany(s => s.SurveyQuestions)
            //                                     .HasForeignKey(sq => sq.SurveyId)
            //                                     .HasPrincipalKey(s => s.Id);
            //modelBuilder.Entity<Survey>()
            //    .Property(p => p.Id)
            //    .ValueGeneratedOnAdd();

            modelBuilder.Entity<Appointment>(entity =>
            {
                entity.ToTable("appointment");
            });

            modelBuilder.Entity<Survey>(entity =>
            {
                entity.ToTable("survey");

                entity.HasOne(d => d.Appointment)
               .WithMany(p => p.Surveys)
               .HasForeignKey(d => d.AppointmentId);
            });

            modelBuilder.Entity<SurveyCategory>(entity =>
            {
                entity.ToTable("surveyCategory");

                entity.HasOne(d => d.Survey)
               .WithMany(p => p.SurveyCategories)
               .HasForeignKey(d => d.SurveyId);
            });

            modelBuilder.Entity<SurveyQuestion>(entity =>
            {
                entity.ToTable("surveyQuestion");

                entity.HasOne(d => d.SurveyCategory)
               .WithMany(p => p.SurveyQuestions)
               .HasForeignKey(d => d.SurveyCategoryId);
            });


            modelBuilder.Entity<Appointment>().HasData(
                new Appointment { Id = 1, DoctorId = 1, PatientId = 1, RoomId = 1, Surveys = new List<Survey>() });

            modelBuilder.Entity<Survey>().HasData(
                new Survey { Id = 1, Done = true, SurveyCategories = new List<SurveyCategory>(), AppointmentId = 1 });

            modelBuilder.Entity<SurveyCategory>().HasData(
                new SurveyCategory { Id = 1, Name = "Doctor", SurveyQuestions = new List<SurveyQuestion>(), SurveyId = 1 },
                new SurveyCategory { Id = 2, Name = "Medical stuff", SurveyQuestions = new List<SurveyQuestion>(), SurveyId = 1 },
                new SurveyCategory { Id = 3, Name = "Hospital", SurveyQuestions = new List<SurveyQuestion>(), SurveyId = 1 });

            modelBuilder.Entity<SurveyQuestion>().HasData(
                new SurveyQuestion { Id = 1, Content = "How careful did doctor listen you?", Grade = 1, SurveyCategoryId = 1 },
                new SurveyQuestion { Id = 2, Content = "Has doctor been polite?", Grade = 3, SurveyCategoryId = 1 },
                new SurveyQuestion { Id = 3, Content = "Has he explained you your condition enough that you can understand it?", Grade = 4, SurveyCategoryId = 1 },
                new SurveyQuestion { Id = 4, Content = "How would you rate doctors' professionalism?", Grade = 5, SurveyCategoryId = 1 },
                new SurveyQuestion { Id = 5, Content = "Your general grade for doctors' service", Grade = 3, SurveyCategoryId = 1 },

                new SurveyQuestion { Id = 6, Content = "How much our medical staff were polite?", Grade = 2, SurveyCategoryId = 2 },
                new SurveyQuestion { Id = 7, Content = "How would you rate time span that you spend waiting untill doctor attended you?", Grade = 3, SurveyCategoryId = 2 },
                new SurveyQuestion { Id = 8, Content = "How prepared were stuff for emergency situations?", Grade = 4, SurveyCategoryId = 2 },
                new SurveyQuestion { Id = 9, Content = "How good has stuff explained you our procedures?", Grade = 5, SurveyCategoryId = 2 },
                new SurveyQuestion { Id = 10, Content = "Your general grade for medical stuffs' service", Grade = 3, SurveyCategoryId = 2 },

                new SurveyQuestion { Id = 11, Content = "How would you rate our appointment organisation?", Grade = 1, SurveyCategoryId = 3 },
                new SurveyQuestion { Id = 12, Content = "How would you rate hospitals' hygiene?", Grade = 4, SurveyCategoryId = 3 },
                new SurveyQuestion { Id = 13, Content = "How good were procedure for booking appointment?", Grade = 4, SurveyCategoryId = 3 },
                new SurveyQuestion { Id = 14, Content = "How easy was to use our application?", Grade = 5, SurveyCategoryId = 3 },
                new SurveyQuestion { Id = 15, Content = "Your general grade for whole hospital' service", Grade = 3, SurveyCategoryId = 3 });
        }
    }
}
