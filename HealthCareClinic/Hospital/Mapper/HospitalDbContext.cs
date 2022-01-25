﻿using System;
using Hospital.Schedule.Model;
using Hospital.Shared_model.Model;
using Hospital.Rooms_and_equipment.Model;
using Microsoft.EntityFrameworkCore;
using static Hospital.Rooms_and_equipment.Model.Building;
using static Hospital.Rooms_and_equipment.Model.Equipment;
using static Hospital.Rooms_and_equipment.Model.Room;
using System.Collections.Generic;
using Hospital.Medical_records.Model;
using static Hospital.Rooms_and_equipment.Model.Transfer;
using Hospital.Tendering.Model;
using Hospital.Graphical_editor.Model;

namespace Hospital.Mapper
{
    public class HospitalDbContext : DbContext
    {
        public DbSet<FeedbackMessage> FeedbackMessages { get; set; }

        public DbSet<Building> Buildings { get; set; }

        public DbSet<Floor> Floors { get; set; }

        public DbSet<Room> Rooms { get; set; }

        public DbSet<OnCallShift> OnCallShifts { get; set; }

        public DbSet<Vacation> Vacations { get; set; }

        public DbSet<Survey> Surveys { get; set; }
        public DbSet<SurveyCategory> SurveyCategories { get; set; }
        public DbSet<SurveyQuestion> SurveyQuestions { get; set; }

        public DbSet<Appointment> Appointments { get; set; }

        public DbSet<CanceledAppointment> CanceledAppointments { get; set; }

        public DbSet<Allergen> Allergens { get; set; }

        public DbSet<AllergenForPatient> AllergenForPatients { get; set; }

        public DbSet<Equipment> Equipments { get; set; }

        public DbSet<Doctor> Doctors { get; set; }
        public DbSet<WorkDayShift> WorkDayShift { get; set; }
        public DbSet<Patient> Patients { get; set; }
        public DbSet<ProfilePicture> ProfilePictures { get; set; }

        public DbSet<Renovation> Renovations { get; set; }
        public DbSet<Transfer> Transfer { get; set; }
        public DbSet<Prescription> Prescriptions { get; set; }
        public DbSet<Tender> Tenders { get; set; }
        public DbSet<TenderResponse> TenderResponses { get; set; }
        public DbSet<Medicine> Medicines { get; set; }
        public HospitalDbContext(DbContextOptions<HospitalDbContext> options) : base(options) { }

        // only for testing purposes
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Vacation>()
               .OwnsOne(r => r.DateSpan)
               .Property(p => p.StartTime).HasColumnName("StartTime");
            modelBuilder.Entity<Vacation>()
                .OwnsOne(r => r.DateSpan)
                .Property(p => p.EndTime).HasColumnName("EndTime");

            modelBuilder.Entity<Room>()
                .OwnsOne(r => r.PositionAndDimension)
                .Property(p => p.X).HasColumnName("X");
            modelBuilder.Entity<Room>()
                .OwnsOne(r => r.PositionAndDimension)
                .Property(p => p.Y).HasColumnName("Y");
            modelBuilder.Entity<Room>()
                .OwnsOne(r => r.PositionAndDimension)
                .Property(p => p.Width).HasColumnName("Width");
            modelBuilder.Entity<Room>()
                .OwnsOne(r => r.PositionAndDimension)
                .Property(p => p.Height).HasColumnName("Height");

            modelBuilder.Entity<WorkDayShift>()
               .OwnsOne(r => r.WorkHour)
               .Property(p => p.StartTime).HasColumnName("StartTime");
            modelBuilder.Entity<WorkDayShift>()
                .OwnsOne(r => r.WorkHour)
                .Property(p => p.EndTime).HasColumnName("EndTime");

            modelBuilder.Entity<Transfer>()
                .OwnsOne(t => t.Equipment)
                .Property(e => e.Name).HasColumnName("Name");
            modelBuilder.Entity<Transfer>()
                .OwnsOne(t => t.Equipment)
                .Property(e => e.Quantity).HasColumnName("Quantity");

            modelBuilder.Entity<Transfer>()
              .OwnsOne(t => t.RoomsForTransfer)
              .Property(e => e.SourceRoomId).HasColumnName("SourceRoomId");
            modelBuilder.Entity<Transfer>()
                .OwnsOne(t => t.RoomsForTransfer)
                .Property(e => e.DestinationRoomId).HasColumnName("DestinationRoomId");

            modelBuilder.Entity<Transfer>()
              .OwnsOne(t => t.DateAndDuration)
              .Property(e => e.Date).HasColumnName("Date");
            modelBuilder.Entity<Transfer>()
                .OwnsOne(t => t.DateAndDuration)
                .Property(e => e.Duration).HasColumnName("Duration");

            modelBuilder.Entity<Tender>()
               .Property(p => p.Id)
               .ValueGeneratedOnAdd();
            modelBuilder.Entity<Tender>()
                .OwnsOne(p => p.DateRange);
            modelBuilder.Entity<Tender>()
                .OwnsMany(p => p.TenderItems);

            modelBuilder.Entity<TenderResponse>()
               .Property(p => p.Id)
               .ValueGeneratedOnAdd();
            modelBuilder.Entity<TenderResponse>()
                .OwnsOne(p => p.TotalPrice);
            modelBuilder.Entity<TenderResponse>()
                .OwnsMany(p => p.TenderItems);

            modelBuilder.Entity<Medicine>()
               .Property(p => p.Id)
               .ValueGeneratedOnAdd();

            modelBuilder.Entity<OnCallShift>().HasData(
               new OnCallShift { Id = 1, DoctorId = 1, Date = new DateTime(2022, 02, 02, 14, 00, 00) },
               new OnCallShift { Id = 2, DoctorId = 2, Date = new DateTime(2021, 11, 25, 9, 30, 00) },
               new OnCallShift { Id = 3, DoctorId = 1, Date = new DateTime(2022, 08, 22, 9, 30, 00) },
               new OnCallShift { Id = 4, DoctorId = 2, Date = new DateTime(2021, 11, 24, 10, 00, 00) },
               new OnCallShift { Id = 5, DoctorId = 1, Date = new DateTime(2021, 11, 23, 10, 00, 00) },
               new OnCallShift { Id = 6, DoctorId = 2, Date = new DateTime(2021, 11, 28, 14, 00, 00) }
               );

            modelBuilder.Entity<Renovation>().HasData(
                new Renovation { Id = 1, FirstRoomId = 1, SecondRoomId = 2, Duration = 2, Date = new DateTime(2022, 02, 02, 14, 00, 00), Type = Renovation.RenovationType.Merge },
                new Renovation { Id = 2, FirstRoomId = 1, SecondRoomId = 0, Duration = 3, Date = new DateTime(2022, 02, 05, 14, 00, 00), Type = Renovation.RenovationType.Divide },
                new Renovation { Id = 3, FirstRoomId = 47, SecondRoomId = 62, Duration = 2, Date = new DateTime(2022, 02, 20, 14, 00, 00), Type = Renovation.RenovationType.Merge }
                );

            modelBuilder.Entity<Transfer>(t =>
            {
                t.HasData(new Transfer
                {
                    Id = 9/*,
                    TimeOfCreation = new DateTime(2022, 01, 01, 08, 00, 00)*/
                });
                t.OwnsOne(e => e.Equipment).HasData(new
                {
                    TransferId = 9,
                    Name = "Bed",
                    Quantity = 2
                });
                t.OwnsOne(e => e.RoomsForTransfer).HasData(new
                {
                    TransferId = 9,
                    SourceRoomId = 1,
                    DestinationRoomId = 2
                });
                t.OwnsOne(e => e.DateAndDuration).HasData(new
                {
                    TransferId = 9,
                    Date = new DateTime(2021, 11, 25, 9, 30, 00),
                    Duration = 60
                });
            });

            modelBuilder.Entity<Transfer>(t =>
            {
                t.HasData(new Transfer
                {
                    Id = 6/*,
                    TimeOfCreation = new DateTime(2022, 01, 01, 08, 00, 00)*/
                });
                t.OwnsOne(e => e.Equipment).HasData(new
                {
                    TransferId = 6,
                    Name = "Needle",
                    Quantity = 5
                });
                t.OwnsOne(e => e.RoomsForTransfer).HasData(new
                {
                    TransferId = 6,
                    SourceRoomId = 1,
                    DestinationRoomId = 51
                });
                t.OwnsOne(e => e.DateAndDuration).HasData(new
                {
                    TransferId = 6,
                    Date = new DateTime(2022, 08, 22, 9, 30, 00),
                    Duration = 60
                });
            });

            modelBuilder.Entity<Transfer>(t =>
            {
                t.HasData(new Transfer
                {
                    Id = 2/*,
                    TimeOfCreation = new DateTime(2022, 01, 01, 08, 00, 00)*/
                });
                t.OwnsOne(e => e.Equipment).HasData(new
                {
                    TransferId = 2,
                    Name = "Bed",
                    Quantity = 4
                });
                t.OwnsOne(e => e.RoomsForTransfer).HasData(new
                {
                    TransferId = 2,
                    SourceRoomId = 50,
                    DestinationRoomId = 60
                });
                t.OwnsOne(e => e.DateAndDuration).HasData(new
                {
                    TransferId = 2,
                    Date = new DateTime(2021, 11, 30, 12, 00, 00),
                    Duration = 45
                });
            });

            modelBuilder.Entity<Transfer>(t =>
            {
                t.HasData(new Transfer
                {
                    Id = 3/*,
                    TimeOfCreation = new DateTime(2022, 01, 01, 08, 00, 00)*/
                });
                t.OwnsOne(e => e.Equipment).HasData(new
                {
                    TransferId = 3,
                    Name = "TV",
                    Quantity = 1
                });
                t.OwnsOne(e => e.RoomsForTransfer).HasData(new
                {
                    TransferId = 3,
                    SourceRoomId = 45,
                    DestinationRoomId = 52
                });
                t.OwnsOne(e => e.DateAndDuration).HasData(new
                {
                    TransferId = 3,
                    Date = new DateTime(2021, 11, 24, 10, 00, 00),
                    Duration = 45
                });
            });

            modelBuilder.Entity<Transfer>(t =>
            {
                t.HasData(new Transfer
                {
                    Id = 4/*,
                    TimeOfCreation = new DateTime(2022, 01, 01, 08, 00, 00)*/
                });
                t.OwnsOne(e => e.Equipment).HasData(new
                {
                    TransferId = 4,
                    Name = "Bandage",
                    Quantity = 4
                });
                t.OwnsOne(e => e.RoomsForTransfer).HasData(new
                {
                    TransferId = 4,
                    SourceRoomId = 47,
                    DestinationRoomId = 62
                });
                t.OwnsOne(e => e.DateAndDuration).HasData(new
                {
                    TransferId = 4,
                    Date = new DateTime(2022, 08, 22, 9, 30, 00),
                    Duration = 15
                });
            });

            modelBuilder.Entity<Transfer>(t =>
            {
                t.HasData(new Transfer
                {
                    Id = 5/*,
                    TimeOfCreation = new DateTime(2022, 01, 01, 08, 00, 00)*/
                });
                t.OwnsOne(e => e.Equipment).HasData(new
                {
                    TransferId = 5,
                    Name = "Blanket",
                    Quantity = 10
                });
                t.OwnsOne(e => e.RoomsForTransfer).HasData(new
                {
                    TransferId = 5,
                    SourceRoomId = 18,
                    DestinationRoomId = 23
                });
                t.OwnsOne(e => e.DateAndDuration).HasData(new
                {
                    TransferId = 5,
                    Date = new DateTime(2021, 11, 28, 14, 00, 00),
                    Duration = 15
                });
            });

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

            modelBuilder.Entity<Room>(b =>
            {
                b.HasData(new Room
                {
                    Id = 1,
                    Type = RoomType.OperationRoom,
                    Name = "Operation room",
                    Description = "Room description...", 
                    FloorId = 1
                });
                b.OwnsOne(e => e.PositionAndDimension).HasData(new
                {
                    RoomId = 1,
                    X = 320f,
                    Y = 30f,
                    Width = 400f,
                    Height = 140f
                });
            });

            modelBuilder.Entity<Room>(b =>
            {
                b.HasData(new Room
                {
                    Id = 2,
                    Type = RoomType.RoomForAppointments,
                    Name = "Room for appointments",
                    Description = "Room description...",
                    FloorId = 1
                });
                b.OwnsOne(e => e.PositionAndDimension).HasData(new
                {
                    RoomId = 2,
                    X = 320f,
                    Y = 260f,
                    Width = 380f,
                    Height = 140f
                });
            });

            modelBuilder.Entity<Room>(b =>
            {
                b.HasData(new Room
                {
                    Id = 3,
                    Type = RoomType.RoomForAppointments,
                    Name = "Room for appointments",
                    Description = "Room description...",
                    FloorId = 1
                });
                b.OwnsOne(e => e.PositionAndDimension).HasData(new
                {
                    RoomId = 3,
                    X = 50f,
                    Y = 260f,
                    Width = 270f,
                    Height = 140f
                });
            });

            modelBuilder.Entity<Room>(b =>
            {
                b.HasData(new Room
                {
                    Id = 4,
                    Type = RoomType.RoomForAppointments,
                    Name = "Room for appointments",
                    Description = "Room description...",
                    FloorId = 1
                });
                b.OwnsOne(e => e.PositionAndDimension).HasData(new
                {
                    RoomId = 4,
                    X = 700f,
                    Y = 260f,
                    Width = 300f,
                    Height = 140f
                });
            });

            modelBuilder.Entity<Room>(b =>
            {
                b.HasData(new Room
                {
                    Id = 5,
                    Type = RoomType.RoomForAppointments,
                    Name = "Room for appointments",
                    Description = "Room description...",
                    FloorId = 1
                });
                b.OwnsOne(e => e.PositionAndDimension).HasData(new
                {
                    RoomId = 5,
                    X = 50f,
                    Y = 30f,
                    Width = 270f,
                    Height = 140f
                });
            });

            modelBuilder.Entity<Room>(b =>
            {
                b.HasData(new Room
                {
                    Id = 6,
                    Type = RoomType.RoomForAppointments,
                    Name = "Room for appointments",
                    Description = "Room description...",
                    FloorId = 1
                });
                b.OwnsOne(e => e.PositionAndDimension).HasData(new
                {
                    RoomId = 6,
                    X = 720f,
                    Y = 30f,
                    Width = 280f,
                    Height = 140f
                });
            });

            modelBuilder.Entity<Room>(b =>
            {
                b.HasData(new Room
                {
                    Id = 7,
                    Type = RoomType.WC,
                    Name = "WC",
                    Description = "Room description...",
                    FloorId = 1
                });
                b.OwnsOne(e => e.PositionAndDimension).HasData(new
                {
                    RoomId = 7,
                    X = 50f,
                    Y = 170f,
                    Width = 150f,
                    Height = 90f
                });
            });

            modelBuilder.Entity<Room>(b =>
            {
                b.HasData(new Room
                {
                    Id = 8,
                    Type = RoomType.OperationRoom,
                    Name = "Operation room",
                    Description = "Room description...",
                    FloorId = 2
                });
                b.OwnsOne(e => e.PositionAndDimension).HasData(new
                {
                    RoomId = 8,
                    X = 320f,
                    Y = 30f,
                    Width = 400f,
                    Height = 140f
                });
            });

            modelBuilder.Entity<Room>(b =>
            {
                b.HasData(new Room
                {
                    Id = 9,
                    Type = RoomType.RoomForAppointments,
                    Name = "Room for appointments",
                    Description = "Room description...",
                    FloorId = 2
                });
                b.OwnsOne(e => e.PositionAndDimension).HasData(new
                {
                    RoomId = 9,
                    X = 320f,
                    Y = 260f,
                    Width = 380f,
                    Height = 140f
                });
            });

            modelBuilder.Entity<Room>(b =>
            {
                b.HasData(new Room
                {
                    Id = 10,
                    Type = RoomType.RoomForAppointments,
                    Name = "Room for appointments",
                    Description = "Room description...",
                    FloorId = 2
                });
                b.OwnsOne(e => e.PositionAndDimension).HasData(new
                {
                    RoomId = 10,
                    X = 50f,
                    Y = 260f,
                    Width = 270f,
                    Height = 140f
                });
            });

            modelBuilder.Entity<Room>(b =>
            {
                b.HasData(new Room
                {
                    Id = 11,
                    Type = RoomType.RoomForAppointments,
                    Name = "Room for appointments",
                    Description = "Room description...",
                    FloorId = 2
                });
                b.OwnsOne(e => e.PositionAndDimension).HasData(new
                {
                    RoomId = 11,
                    X = 700f,
                    Y = 260f,
                    Width = 300f,
                    Height = 140f
                });
            });

            modelBuilder.Entity<Room>(b =>
            {
                b.HasData(new Room
                {
                    Id = 12,
                    Type = RoomType.RoomForAppointments,
                    Name = "Room for appointments",
                    Description = "Room description...",
                    FloorId = 2
                });
                b.OwnsOne(e => e.PositionAndDimension).HasData(new
                {
                    RoomId = 12,
                    X = 50f,
                    Y = 30f,
                    Width = 270f,
                    Height = 140f
                });
            });

            modelBuilder.Entity<Room>(b =>
            {
                b.HasData(new Room
                {
                    Id = 13,
                    Type = RoomType.RoomForAppointments,
                    Name = "Room for appointments",
                    Description = "Room description...",
                    FloorId = 2
                });
                b.OwnsOne(e => e.PositionAndDimension).HasData(new
                {
                    RoomId = 13,
                    X = 720f,
                    Y = 30f,
                    Width = 280f,
                    Height = 140f
                });
            });

            modelBuilder.Entity<Room>(b =>
            {
                b.HasData(new Room
                {
                    Id = 14,
                    Type = RoomType.WC,
                    Name = "WC",
                    Description = "Room description...",
                    FloorId = 2
                });
                b.OwnsOne(e => e.PositionAndDimension).HasData(new
                {
                    RoomId = 14,
                    X = 50f,
                    Y = 170f,
                    Width = 150f,
                    Height = 90f
                });
            });

            modelBuilder.Entity<Room>(b =>
            {
                b.HasData(new Room
                {
                    Id = 15,
                    Type = RoomType.OperationRoom,
                    Name = "Operation room",
                    Description = "Room description...",
                    FloorId = 3
                });
                b.OwnsOne(e => e.PositionAndDimension).HasData(new
                {
                    RoomId = 15,
                    X = 320f,
                    Y = 30f,
                    Width = 400f,
                    Height = 140f
                });
            });

            modelBuilder.Entity<Room>(b =>
            {
                b.HasData(new Room
                {
                    Id = 16,
                    Type = RoomType.RoomForAppointments,
                    Name = "Room for appointments",
                    Description = "Room description...",
                    FloorId = 3
                });
                b.OwnsOne(e => e.PositionAndDimension).HasData(new
                {
                    RoomId = 16,
                    X = 320f,
                    Y = 260f,
                    Width = 380f,
                    Height = 140f
                });
            });

            modelBuilder.Entity<Room>(b =>
            {
                b.HasData(new Room
                {
                    Id = 17,
                    Type = RoomType.RoomForAppointments,
                    Name = "Room for appointments",
                    Description = "Room description...",
                    FloorId = 3
                });
                b.OwnsOne(e => e.PositionAndDimension).HasData(new
                {
                    RoomId = 17,
                    X = 50f,
                    Y = 260f,
                    Width = 270f,
                    Height = 140f
                });
            });

            modelBuilder.Entity<Room>(b =>
            {
                b.HasData(new Room
                {
                    Id = 18,
                    Type = RoomType.RoomForAppointments,
                    Name = "Room for appointments",
                    Description = "Room description...",
                    FloorId = 3
                });
                b.OwnsOne(e => e.PositionAndDimension).HasData(new
                {
                    RoomId = 18,
                    X = 700f,
                    Y = 260f,
                    Width = 300f,
                    Height = 140f
                });
            });

            modelBuilder.Entity<Room>(b =>
            {
                b.HasData(new Room
                {
                    Id = 19,
                    Type = RoomType.RoomForAppointments,
                    Name = "Room for appointments",
                    Description = "Room description...",
                    FloorId = 3
                });
                b.OwnsOne(e => e.PositionAndDimension).HasData(new
                {
                    RoomId = 19,
                    X = 50f,
                    Y = 30f,
                    Width = 270f,
                    Height = 140f
                });
            });

            modelBuilder.Entity<Room>(b =>
            {
                b.HasData(new Room
                {
                    Id = 20,
                    Type = RoomType.RoomForAppointments,
                    Name = "Room for appointments",
                    Description = "Room description...",
                    FloorId = 3
                });
                b.OwnsOne(e => e.PositionAndDimension).HasData(new
                {
                    RoomId = 20,
                    X = 720f,
                    Y = 30f,
                    Width = 280f,
                    Height = 140f
                });
            });

            modelBuilder.Entity<Room>(b =>
            {
                b.HasData(new Room
                {
                    Id = 21,
                    Type = RoomType.WC,
                    Name = "WC",
                    Description = "Room description...",
                    FloorId = 3
                });
                b.OwnsOne(e => e.PositionAndDimension).HasData(new
                {
                    RoomId = 21,
                    X = 50f,
                    Y = 170f,
                    Width = 150f,
                    Height = 90f
                });
            });

            modelBuilder.Entity<Room>(b =>
            {
                b.HasData(new Room
                {
                    Id = 22,
                    Type = RoomType.OperationRoom,
                    Name = "Operation room",
                    Description = "Room description...",
                    FloorId = 4
                });
                b.OwnsOne(e => e.PositionAndDimension).HasData(new
                {
                    RoomId = 22,
                    X = 320f,
                    Y = 30f,
                    Width = 400f,
                    Height = 140f
                });
            });

            modelBuilder.Entity<Room>(b =>
            {
                b.HasData(new Room
                {
                    Id = 23,
                    Type = RoomType.RoomForAppointments,
                    Name = "Room for appointments",
                    Description = "Room description...",
                    FloorId = 4
                });
                b.OwnsOne(e => e.PositionAndDimension).HasData(new
                {
                    RoomId = 23,
                    X = 320f,
                    Y = 260f,
                    Width = 380f,
                    Height = 140f
                });
            });

            modelBuilder.Entity<Room>(b =>
            {
                b.HasData(new Room
                {
                    Id = 24,
                    Type = RoomType.RoomForAppointments,
                    Name = "Room for appointments",
                    Description = "Room description...",
                    FloorId = 4
                });
                b.OwnsOne(e => e.PositionAndDimension).HasData(new
                {
                    RoomId = 24,
                    X = 50f,
                    Y = 260f,
                    Width = 270f,
                    Height = 140f
                });
            });

            modelBuilder.Entity<Room>(b =>
            {
                b.HasData(new Room
                {
                    Id = 25,
                    Type = RoomType.RoomForAppointments,
                    Name = "Room for appointments",
                    Description = "Room description...",
                    FloorId = 4
                });
                b.OwnsOne(e => e.PositionAndDimension).HasData(new
                {
                    RoomId = 25,
                    X = 700f,
                    Y = 260f,
                    Width = 300f,
                    Height = 140f
                });
            });

            modelBuilder.Entity<Room>(b =>
            {
                b.HasData(new Room
                {
                    Id = 26,
                    Type = RoomType.RoomForAppointments,
                    Name = "Room for appointments",
                    Description = "Room description...",
                    FloorId = 4
                });
                b.OwnsOne(e => e.PositionAndDimension).HasData(new
                {
                    RoomId = 26,
                    X = 50f,
                    Y = 30f,
                    Width = 270f,
                    Height = 140f
                });
            });

            modelBuilder.Entity<Room>(b =>
            {
                b.HasData(new Room
                {
                    Id = 27,
                    Type = RoomType.RoomForAppointments,
                    Name = "Room for appointments",
                    Description = "Room description...",
                    FloorId = 4
                });
                b.OwnsOne(e => e.PositionAndDimension).HasData(new
                {
                    RoomId = 27,
                    X = 720f,
                    Y = 30f,
                    Width = 280f,
                    Height = 140f
                });
            });

            modelBuilder.Entity<Room>(b =>
            {
                b.HasData(new Room
                {
                    Id = 28,
                    Type = RoomType.WC,
                    Name = "WC",
                    Description = "Room description...",
                    FloorId = 4
                });
                b.OwnsOne(e => e.PositionAndDimension).HasData(new
                {
                    RoomId = 28,
                    X = 50f,
                    Y = 170f,
                    Width = 150f,
                    Height = 90f
                });
            });

            modelBuilder.Entity<Room>(b =>
            {
                b.HasData(new Room
                {
                    Id = 29,
                    Type = RoomType.OperationRoom,
                    Name = "Operation room",
                    Description = "Room description...",
                    FloorId = 5
                });
                b.OwnsOne(e => e.PositionAndDimension).HasData(new
                {
                    RoomId = 29,
                    X = 320f,
                    Y = 30f,
                    Width = 400f,
                    Height = 140f
                });
            });

            modelBuilder.Entity<Room>(b =>
            {
                b.HasData(new Room
                {
                    Id = 30,
                    Type = RoomType.RoomForAppointments,
                    Name = "Room for appointments",
                    Description = "Room description...",
                    FloorId = 5
                });
                b.OwnsOne(e => e.PositionAndDimension).HasData(new
                {
                    RoomId = 30,
                    X = 320f,
                    Y = 260f,
                    Width = 380f,
                    Height = 140f
                });
            });

            modelBuilder.Entity<Room>(b =>
            {
                b.HasData(new Room
                {
                    Id = 31,
                    Type = RoomType.RoomForAppointments,
                    Name = "Room for appointments",
                    Description = "Room description...",
                    FloorId = 5
                });
                b.OwnsOne(e => e.PositionAndDimension).HasData(new
                {
                    RoomId = 31,
                    X = 50f,
                    Y = 260f,
                    Width = 270f,
                    Height = 140f
                });
            });

            modelBuilder.Entity<Room>(b =>
            {
                b.HasData(new Room
                {
                    Id = 32,
                    Type = RoomType.RoomForAppointments,
                    Name = "Room for appointments",
                    Description = "Room description...",
                    FloorId = 5
                });
                b.OwnsOne(e => e.PositionAndDimension).HasData(new
                {
                    RoomId = 32,
                    X = 700f,
                    Y = 260f,
                    Width = 300f,
                    Height = 140f
                });
            });

            modelBuilder.Entity<Room>(b =>
            {
                b.HasData(new Room
                {
                    Id = 33,
                    Type = RoomType.RoomForAppointments,
                    Name = "Room for appointments",
                    Description = "Room description...",
                    FloorId = 5
                });
                b.OwnsOne(e => e.PositionAndDimension).HasData(new
                {
                    RoomId = 33,
                    X = 50f,
                    Y = 30f,
                    Width = 270f,
                    Height = 140f
                });
            });

            modelBuilder.Entity<Room>(b =>
            {
                b.HasData(new Room
                {
                    Id = 34,
                    Type = RoomType.RoomForAppointments,
                    Name = "Room for appointments",
                    Description = "Room description...",
                    FloorId = 5
                });
                b.OwnsOne(e => e.PositionAndDimension).HasData(new
                {
                    RoomId = 34,
                    X = 720f,
                    Y = 30f,
                    Width = 280f,
                    Height = 140f
                });
            });

            modelBuilder.Entity<Room>(b =>
            {
                b.HasData(new Room
                {
                    Id = 35,
                    Type = RoomType.WC,
                    Name = "WC",
                    Description = "Room description...",
                    FloorId = 5
                });
                b.OwnsOne(e => e.PositionAndDimension).HasData(new
                {
                    RoomId = 35,
                    X = 50f,
                    Y = 170f,
                    Width = 150f,
                    Height = 90f
                });
            });

            modelBuilder.Entity<Room>(b =>
            {
                b.HasData(new Room
                {
                    Id = 36,
                    Type = RoomType.OperationRoom,
                    Name = "Operation room",
                    Description = "Room description...",
                    FloorId = 6
                });
                b.OwnsOne(e => e.PositionAndDimension).HasData(new
                {
                    RoomId = 36,
                    X = 320f,
                    Y = 30f,
                    Width = 400f,
                    Height = 140f
                });
            });

            modelBuilder.Entity<Room>(b =>
            {
                b.HasData(new Room
                {
                    Id = 37,
                    Type = RoomType.RoomForAppointments,
                    Name = "Room for appointments",
                    Description = "Room description...",
                    FloorId = 6
                });
                b.OwnsOne(e => e.PositionAndDimension).HasData(new
                {
                    RoomId = 37,
                    X = 320f,
                    Y = 260f,
                    Width = 380f,
                    Height = 140f
                });
            });

            modelBuilder.Entity<Room>(b =>
            {
                b.HasData(new Room
                {
                    Id = 38,
                    Type = RoomType.RoomForAppointments,
                    Name = "Room for appointments",
                    Description = "Room description...",
                    FloorId = 6
                });
                b.OwnsOne(e => e.PositionAndDimension).HasData(new
                {
                    RoomId = 38,
                    X = 50f,
                    Y = 260f,
                    Width = 270f,
                    Height = 140f
                });
            });

            modelBuilder.Entity<Room>(b =>
            {
                b.HasData(new Room
                {
                    Id = 39,
                    Type = RoomType.RoomForAppointments,
                    Name = "Room for appointments",
                    Description = "Room description...",
                    FloorId = 6
                });
                b.OwnsOne(e => e.PositionAndDimension).HasData(new
                {
                    RoomId = 39,
                    X = 700f,
                    Y = 260f,
                    Width = 300f,
                    Height = 140f
                });
            });

            modelBuilder.Entity<Room>(b =>
            {
                b.HasData(new Room
                {
                    Id = 40,
                    Type = RoomType.RoomForAppointments,
                    Name = "Room for appointments",
                    Description = "Room description...",
                    FloorId = 6
                });
                b.OwnsOne(e => e.PositionAndDimension).HasData(new
                {
                    RoomId = 40,
                    X = 50f,
                    Y = 30f,
                    Width = 270f,
                    Height = 140f
                });
            });

            modelBuilder.Entity<Room>(b =>
            {
                b.HasData(new Room
                {
                    Id = 41,
                    Type = RoomType.RoomForAppointments,
                    Name = "Room for appointments",
                    Description = "Room description...",
                    FloorId = 6
                });
                b.OwnsOne(e => e.PositionAndDimension).HasData(new
                {
                    RoomId = 41,
                    X = 720f,
                    Y = 30f,
                    Width = 280f,
                    Height = 140f
                });
            });

            modelBuilder.Entity<Room>(b =>
            {
                b.HasData(new Room
                {
                    Id = 42,
                    Type = RoomType.WC,
                    Name = "WC",
                    Description = "Room description...",
                    FloorId = 6
                });
                b.OwnsOne(e => e.PositionAndDimension).HasData(new
                {
                    RoomId = 42,
                    X = 50f,
                    Y = 170f,
                    Width = 150f,
                    Height = 90f
                });
            });

            modelBuilder.Entity<Room>(b =>
            {
                b.HasData(new Room
                {
                    Id = 43,
                    Type = RoomType.OperationRoom,
                    Name = "Operation room",
                    Description = "Room description...",
                    FloorId = 7
                });
                b.OwnsOne(e => e.PositionAndDimension).HasData(new
                {
                    RoomId = 43,
                    X = 320f,
                    Y = 30f,
                    Width = 400f,
                    Height = 140f
                });
            });

            modelBuilder.Entity<Room>(b =>
            {
                b.HasData(new Room
                {
                    Id = 44,
                    Type = RoomType.RoomForAppointments,
                    Name = "Room for appointments",
                    Description = "Room description...",
                    FloorId = 7
                });
                b.OwnsOne(e => e.PositionAndDimension).HasData(new
                {
                    RoomId = 44,
                    X = 320f,
                    Y = 260f,
                    Width = 380f,
                    Height = 140f
                });
            });

            modelBuilder.Entity<Room>(b =>
            {
                b.HasData(new Room
                {
                    Id = 45,
                    Type = RoomType.RoomForAppointments,
                    Name = "Room for appointments",
                    Description = "Room description...",
                    FloorId = 7
                });
                b.OwnsOne(e => e.PositionAndDimension).HasData(new
                {
                    RoomId = 45,
                    X = 50f,
                    Y = 260f,
                    Width = 270f,
                    Height = 140f
                });
            });

            modelBuilder.Entity<Room>(b =>
            {
                b.HasData(new Room
                {
                    Id = 46,
                    Type = RoomType.RoomForAppointments,
                    Name = "Room for appointments",
                    Description = "Room description...",
                    FloorId = 7
                });
                b.OwnsOne(e => e.PositionAndDimension).HasData(new
                {
                    RoomId = 46,
                    X = 700f,
                    Y = 260f,
                    Width = 300f,
                    Height = 140f
                });
            });

            modelBuilder.Entity<Room>(b =>
            {
                b.HasData(new Room
                {
                    Id = 47,
                    Type = RoomType.RoomForAppointments,
                    Name = "Room for appointments",
                    Description = "Room description...",
                    FloorId = 7
                });
                b.OwnsOne(e => e.PositionAndDimension).HasData(new
                {
                    RoomId = 47,
                    X = 50f,
                    Y = 30f,
                    Width = 270f,
                    Height = 140f
                });
            });

            modelBuilder.Entity<Room>(b =>
            {
                b.HasData(new Room
                {
                    Id = 48,
                    Type = RoomType.RoomForAppointments,
                    Name = "Room for appointments",
                    Description = "Room description...",
                    FloorId = 7
                });
                b.OwnsOne(e => e.PositionAndDimension).HasData(new
                {
                    RoomId = 48,
                    X = 720f,
                    Y = 30f,
                    Width = 280f,
                    Height = 140f
                });
            });

            modelBuilder.Entity<Room>(b =>
            {
                b.HasData(new Room
                {
                    Id = 49,
                    Type = RoomType.WC,
                    Name = "WC",
                    Description = "Room description...",
                    FloorId = 7
                });
                b.OwnsOne(e => e.PositionAndDimension).HasData(new
                {
                    RoomId = 49,
                    X = 50f,
                    Y = 170f,
                    Width = 150f,
                    Height = 90f
                });
            });

            modelBuilder.Entity<Room>(b =>
            {
                b.HasData(new Room
                {
                    Id = 50,
                    Type = RoomType.OperationRoom,
                    Name = "Operation room",
                    Description = "Room description...",
                    FloorId = 8
                });
                b.OwnsOne(e => e.PositionAndDimension).HasData(new
                {
                    RoomId = 50,
                    X = 320f,
                    Y = 30f,
                    Width = 400f,
                    Height = 140f
                });
            });

            modelBuilder.Entity<Room>(b =>
            {
                b.HasData(new Room
                {
                    Id = 51,
                    Type = RoomType.RoomForAppointments,
                    Name = "Room for appointments",
                    Description = "Room description...",
                    FloorId = 8
                });
                b.OwnsOne(e => e.PositionAndDimension).HasData(new
                {
                    RoomId = 51,
                    X = 320f,
                    Y = 260f,
                    Width = 380f,
                    Height = 140f
                });
            });

            modelBuilder.Entity<Room>(b =>
            {
                b.HasData(new Room
                {
                    Id = 52,
                    Type = RoomType.RoomForAppointments,
                    Name = "Room for appointments",
                    Description = "Room description...",
                    FloorId = 8
                });
                b.OwnsOne(e => e.PositionAndDimension).HasData(new
                {
                    RoomId = 52,
                    X = 50f,
                    Y = 260f,
                    Width = 270f,
                    Height = 140f
                });
            });

            modelBuilder.Entity<Room>(b =>
            {
                b.HasData(new Room
                {
                    Id = 53,
                    Type = RoomType.RoomForAppointments,
                    Name = "Room for appointments",
                    Description = "Room description...",
                    FloorId = 8
                });
                b.OwnsOne(e => e.PositionAndDimension).HasData(new
                {
                    RoomId = 53,
                    X = 700f,
                    Y = 260f,
                    Width = 300f,
                    Height = 140f
                });
            });

            modelBuilder.Entity<Room>(b =>
            {
                b.HasData(new Room
                {
                    Id = 54,
                    Type = RoomType.RoomForAppointments,
                    Name = "Room for appointments",
                    Description = "Room description...",
                    FloorId = 8
                });
                b.OwnsOne(e => e.PositionAndDimension).HasData(new
                {
                    RoomId = 54,
                    X = 50f,
                    Y = 30f,
                    Width = 270f,
                    Height = 140f
                });
            });

            modelBuilder.Entity<Room>(b =>
            {
                b.HasData(new Room
                {
                    Id = 55,
                    Type = RoomType.RoomForAppointments,
                    Name = "Room for appointments",
                    Description = "Room description...",
                    FloorId = 8
                });
                b.OwnsOne(e => e.PositionAndDimension).HasData(new
                {
                    RoomId = 55,
                    X = 720f,
                    Y = 30f,
                    Width = 280f,
                    Height = 140f
                });
            });

            modelBuilder.Entity<Room>(b =>
            {
                b.HasData(new Room
                {
                    Id = 56,
                    Type = RoomType.WC,
                    Name = "WC",
                    Description = "Room description...",
                    FloorId = 8
                });
                b.OwnsOne(e => e.PositionAndDimension).HasData(new
                {
                    RoomId = 56,
                    X = 50f,
                    Y = 170f,
                    Width = 150f,
                    Height = 90f
                });
            });

            modelBuilder.Entity<Room>(b =>
            {
                b.HasData(new Room
                {
                    Id = 57,
                    Type = RoomType.OperationRoom,
                    Name = "Operation room",
                    Description = "Room description...",
                    FloorId = 9
                });
                b.OwnsOne(e => e.PositionAndDimension).HasData(new
                {
                    RoomId = 57,
                    X = 320f,
                    Y = 30f,
                    Width = 400f,
                    Height = 140f
                });
            });

            modelBuilder.Entity<Room>(b =>
            {
                b.HasData(new Room
                {
                    Id = 58,
                    Type = RoomType.RoomForAppointments,
                    Name = "Room for appointments",
                    Description = "Room description...",
                    FloorId = 9
                });
                b.OwnsOne(e => e.PositionAndDimension).HasData(new
                {
                    RoomId = 58,
                    X = 320f,
                    Y = 260f,
                    Width = 380f,
                    Height = 140f
                });
            });

            modelBuilder.Entity<Room>(b =>
            {
                b.HasData(new Room
                {
                    Id = 59,
                    Type = RoomType.RoomForAppointments,
                    Name = "Room for appointments",
                    Description = "Room description...",
                    FloorId = 9
                });
                b.OwnsOne(e => e.PositionAndDimension).HasData(new
                {
                    RoomId = 59,
                    X = 50f,
                    Y = 260f,
                    Width = 270f,
                    Height = 140f
                });
            });

            modelBuilder.Entity<Room>(b =>
            {
                b.HasData(new Room
                {
                    Id = 60,
                    Type = RoomType.RoomForAppointments,
                    Name = "Room for appointments",
                    Description = "Room description...",
                    FloorId = 9
                });
                b.OwnsOne(e => e.PositionAndDimension).HasData(new
                {
                    RoomId = 60,
                    X = 700f,
                    Y = 260f,
                    Width = 300f,
                    Height = 140f
                });
            });

            modelBuilder.Entity<Room>(b =>
            {
                b.HasData(new Room
                {
                    Id = 61,
                    Type = RoomType.RoomForAppointments,
                    Name = "Room for appointments",
                    Description = "Room description...",
                    FloorId = 9
                });
                b.OwnsOne(e => e.PositionAndDimension).HasData(new
                {
                    RoomId = 61,
                    X = 50f,
                    Y = 30f,
                    Width = 270f,
                    Height = 140f
                });
            });

            modelBuilder.Entity<Room>(b =>
            {
                b.HasData(new Room
                {
                    Id = 62,
                    Type = RoomType.RoomForAppointments,
                    Name = "Room for appointments",
                    Description = "Room description...",
                    FloorId = 9
                });
                b.OwnsOne(e => e.PositionAndDimension).HasData(new
                {
                    RoomId = 62,
                    X = 720f,
                    Y = 30f,
                    Width = 280f,
                    Height = 140f
                });
            });

            modelBuilder.Entity<Room>(b =>
            {
                b.HasData(new Room
                {
                    Id = 63,
                    Type = RoomType.WC,
                    Name = "WC",
                    Description = "Room description...",
                    FloorId = 9
                });
                b.OwnsOne(e => e.PositionAndDimension).HasData(new
                {
                    RoomId = 63,
                    X = 50f,
                    Y = 170f,
                    Width = 150f,
                    Height = 90f
                });
            });

            modelBuilder.Entity<Room>(b =>
            {
                b.HasData(new Room
                {
                    Id = 64,
                    Type = RoomType.OperationRoom,
                    Name = "Operation room",
                    Description = "Room description...",
                    FloorId = 10
                });
                b.OwnsOne(e => e.PositionAndDimension).HasData(new
                {
                    RoomId = 64,
                    X = 320f,
                    Y = 30f,
                    Width = 400f,
                    Height = 140f
                });
            });

            modelBuilder.Entity<Room>(b =>
            {
                b.HasData(new Room
                {
                    Id = 65,
                    Type = RoomType.RoomForAppointments,
                    Name = "Room for appointments",
                    Description = "Room description...",
                    FloorId = 10
                });
                b.OwnsOne(e => e.PositionAndDimension).HasData(new
                {
                    RoomId = 65,
                    X = 320f,
                    Y = 260f,
                    Width = 380f,
                    Height = 140f
                });
            });

            modelBuilder.Entity<Room>(b =>
            {
                b.HasData(new Room
                {
                    Id = 66,
                    Type = RoomType.RoomForAppointments,
                    Name = "Room for appointments",
                    Description = "Room description...",
                    FloorId = 10
                });
                b.OwnsOne(e => e.PositionAndDimension).HasData(new
                {
                    RoomId = 66,
                    X = 50f,
                    Y = 260f,
                    Width = 270f,
                    Height = 140f
                });
            });

            modelBuilder.Entity<Room>(b =>
            {
                b.HasData(new Room
                {
                    Id = 67,
                    Type = RoomType.RoomForAppointments,
                    Name = "Room for appointments",
                    Description = "Room description...",
                    FloorId = 10
                });
                b.OwnsOne(e => e.PositionAndDimension).HasData(new
                {
                    RoomId = 67,
                    X = 700f,
                    Y = 260f,
                    Width = 300f,
                    Height = 140f
                });
            });

            modelBuilder.Entity<Room>(b =>
            {
                b.HasData(new Room
                {
                    Id = 68,
                    Type = RoomType.RoomForAppointments,
                    Name = "Room for appointments",
                    Description = "Room description...",
                    FloorId = 10
                });
                b.OwnsOne(e => e.PositionAndDimension).HasData(new
                {
                    RoomId = 68,
                    X = 50f,
                    Y = 30f,
                    Width = 270f,
                    Height = 140f
                });
            });

            modelBuilder.Entity<Room>(b =>
            {
                b.HasData(new Room
                {
                    Id = 69,
                    Type = RoomType.RoomForAppointments,
                    Name = "Room for appointments",
                    Description = "Room description...",
                    FloorId = 10
                });
                b.OwnsOne(e => e.PositionAndDimension).HasData(new
                {
                    RoomId = 69,
                    X = 720f,
                    Y = 30f,
                    Width = 280f,
                    Height = 140f
                });
            });

            modelBuilder.Entity<Vacation>(b =>
            {
                b.HasData(new Vacation
                {
                    Id = 1,
                    Description = "Description...",
                    DoctorId = 1
                });
                b.OwnsOne(e => e.DateSpan).HasData(new
                {
                    VacationId = 1,
                    StartTime = new DateTime(2020, 05, 20, 00, 00, 00),
                    EndTime = new DateTime(2020, 05, 27, 23, 00, 00)
                });
            });

            modelBuilder.Entity<Vacation>(b =>
            {
                b.HasData(new Vacation
                {
                    Id = 2,
                    Description = "Description...",
                    DoctorId = 2
                });
                b.OwnsOne(e => e.DateSpan).HasData(new
                {
                    VacationId = 2,
                    StartTime = new DateTime(2020, 06, 20, 00, 00, 00),
                    EndTime = new DateTime(2020, 07, 03, 23, 00, 00)
                });
            });

            modelBuilder.Entity<Vacation>(b =>
            {
                b.HasData(new Vacation
                {
                    Id = 3,
                    Description = "Description...",
                    DoctorId = 1
                });
                b.OwnsOne(e => e.DateSpan).HasData(new
                {
                    VacationId = 3,
                    StartTime = new DateTime(2020, 09, 22, 00, 00, 00),
                    EndTime = new DateTime(2020, 10, 18, 23, 00, 00)
                });
            });

            modelBuilder.Entity<Vacation>(b =>
            {
                b.HasData(new Vacation
                {
                    Id = 4,
                    Description = "Description...",
                    DoctorId = 2
                });
                b.OwnsOne(e => e.DateSpan).HasData(new
                {
                    VacationId = 4,
                    StartTime = new DateTime(2020, 10, 13, 00, 00, 00),
                    EndTime = new DateTime(2020, 10, 21, 23, 00, 00)
                });
            });

            modelBuilder.Entity<Vacation>(b =>
            {
                b.HasData(new Vacation
                {
                    Id = 5,
                    Description = "Description...",
                    DoctorId = 1
                });
                b.OwnsOne(e => e.DateSpan).HasData(new
                {
                    VacationId = 5,
                    StartTime = new DateTime(2021, 03, 02, 00, 00, 00),
                    EndTime = new DateTime(2021, 03, 20, 23, 00, 00)
                });
            });

            modelBuilder.Entity<Vacation>(b =>
            {
                b.HasData(new Vacation
                {
                    Id = 6,
                    Description = "Description...",
                    DoctorId = 2
                });
                b.OwnsOne(e => e.DateSpan).HasData(new
                {
                    VacationId = 6,
                    StartTime = new DateTime(2021, 08, 11, 00, 00, 00),
                    EndTime = new DateTime(2021, 08, 22, 23, 00, 00)
                });
            });

            modelBuilder.Entity<Vacation>(b =>
            {
                b.HasData(new Vacation
                {
                    Id = 7,
                    Description = "Description...",
                    DoctorId = 1
                });
                b.OwnsOne(e => e.DateSpan).HasData(new
                {
                    VacationId = 7,
                    StartTime = new DateTime(2022, 01, 07, 00, 00, 00),
                    EndTime = new DateTime(2022, 01, 13, 23, 00, 00)
                });
            });

            modelBuilder.Entity<Vacation>(b =>
            {
                b.HasData(new Vacation
                {
                    Id = 8,
                    Description = "Description...",
                    DoctorId = 2
                });
                b.OwnsOne(e => e.DateSpan).HasData(new
                {
                    VacationId = 8,
                    StartTime = new DateTime(2022, 01, 01, 00, 00, 00),
                    EndTime = new DateTime(2022, 01, 21, 23, 00, 00)
                });
            });

            modelBuilder.Entity<Vacation>(b =>
            {
                b.HasData(new Vacation
                {
                    Id = 9,
                    Description = "Description...",
                    DoctorId = 1
                });
                b.OwnsOne(e => e.DateSpan).HasData(new
                {
                    VacationId = 9,
                    StartTime = new DateTime(2022, 04, 23, 00, 00, 00),
                    EndTime = new DateTime(2022, 05, 07, 23, 00, 00)
                });
            });

            modelBuilder.Entity<Vacation>(b =>
            {
                b.HasData(new Vacation
                {
                    Id = 10,
                    Description = "Description...",
                    DoctorId = 2
                });
                b.OwnsOne(e => e.DateSpan).HasData(new
                {
                    VacationId = 10,
                    StartTime = new DateTime(2022, 08, 22, 00, 00, 00),
                    EndTime = new DateTime(2022, 08, 26, 23, 00, 00)
                });
            });

            modelBuilder.Entity<Room>(b =>
            {
                b.HasData(new Room
                {
                    Id = 70,
                    Type = RoomType.WC,
                    Name = "WC",
                    Description = "Room description...",
                    FloorId = 10
                });
                b.OwnsOne(e => e.PositionAndDimension).HasData(new
                {
                    RoomId = 70,
                    X = 50f,
                    Y = 170f,
                    Width = 150f,
                    Height = 90f
                });
            });

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

            

            modelBuilder.Entity<Allergen>().HasData(
                new Allergen(1, "Polen ambrozije"),
                new Allergen(2, "Ibuprofen"),
                new Allergen(3, "Aspirin"),
                new Allergen(4, "Penicilin"),
                new Allergen(5, "Mačija dlaka"),
                new Allergen(6, "Lateks"),
                new Allergen(7, "Kikiriki"),
                new Allergen(8, "Kravlje mleko"),
                new Allergen(9, "Jaja"),
                new Allergen(10, "Školjke")
            );
           
            modelBuilder.Entity<Appointment>().HasData(
                new Appointment(1, 1, 1, 1, false, false, new DateTime(2022, 2, 22, 7, 0, 0), 1),
                new Appointment(2, 2, 1, 1, false, false, new DateTime(2022, 2, 22, 7, 30, 0), 2),
                new Appointment(3, 3, 1, 1, false, false, new DateTime(2022, 2, 22, 8, 0, 0), 3),
                new Appointment(4, 4, 1, 1, false, false, new DateTime(2022, 2, 22, 8, 30, 0), 4),
                new Appointment(5, 5, 1, 1, false, false, new DateTime(2022, 2, 22, 9, 0, 0), 5),
                new Appointment(6, 6, 1, 1, false, false, new DateTime(2022, 2, 22, 9, 30, 0), 6),
                new Appointment(7, 7, 1, 1, false, false, new DateTime(2022, 2, 22, 10, 0, 0), 7),
                new Appointment(8, 8, 1, 1, false, false, new DateTime(2022, 2, 22, 10, 30, 0), 8),
                new Appointment(9, 1, 1, 1, false, false, new DateTime(2022, 2, 22, 11, 0, 0), 9),
                new Appointment(10, 1, 2, 2, false, true, new DateTime(2021, 2, 22, 11, 30, 0), 10),

                new Appointment(11, 1, 1, 1, false, false, new DateTime(2022, 2, 22, 12, 0, 0), 11),
                new Appointment(12, 1, 1, 1, false, false, new DateTime(2022, 2, 22, 12, 30, 0), 12),
                new Appointment(13, 9, 3, 3, false, false, new DateTime(2022, 2, 22, 7, 0, 0), 13),
                new Appointment(14, 10, 3, 3, false, false, new DateTime(2022, 2, 22, 7, 30, 0), 14),
                new Appointment(15, 11, 3, 3, false, false, new DateTime(2022, 2, 22, 8, 0, 0), 15),
                new Appointment(16, 12, 3, 3, false, false, new DateTime(2022, 2, 22, 8, 30, 0), 16),
                new Appointment(17, 13, 3, 3, false, false, new DateTime(2022, 2, 22, 9, 0, 0), 17),
                new Appointment(18, 14, 3, 3, false, false, new DateTime(2022, 2, 22, 9, 30, 0), 18),
                new Appointment(19, 15, 3, 3, false, false, new DateTime(2022, 2, 22, 10, 0, 0), 19),
                new Appointment(20, 16, 3, 3, false, false, new DateTime(2022, 2, 22, 10, 30, 0), 20),
                new Appointment(21, 17, 3, 3, false, false, new DateTime(2022, 2, 22, 11, 0, 0), 21),
                new Appointment(22, 18, 3, 3, false, false, new DateTime(2022, 2, 22, 11, 30, 0), 22),
                new Appointment(23, 19, 3, 3, false, false, new DateTime(2022, 2, 22, 12, 0, 0), 23),
                new Appointment(24, 20, 3, 3, false, false, new DateTime(2022, 2, 22, 12, 30, 0), 24)
            );

            for (int i = 1; i <= 24; i++)
            {
                if (i != 10)
                {
                    modelBuilder.Entity<Survey>().HasData(
                    new Survey { Id = i, Done = false, SurveyCategories = new List<SurveyCategory>(), AppointmentId = i });

                    modelBuilder.Entity<SurveyCategory>().HasData(
                        new SurveyCategory { Id = i * 3 - 2, Name = "Doctor", SurveyQuestions = new List<SurveyQuestion>(), SurveyId = i },
                        new SurveyCategory { Id = i * 3 - 1, Name = "Medical stuff", SurveyQuestions = new List<SurveyQuestion>(), SurveyId = i },
                        new SurveyCategory { Id = i * 3, Name = "Hospital", SurveyQuestions = new List<SurveyQuestion>(), SurveyId = i });

                    modelBuilder.Entity<SurveyQuestion>().HasData(
                        new SurveyQuestion { Id = i * 15 - 14, Content = "How careful did doctor listen you?", Grade = 0, SurveyCategoryId = i * 3 - 2 },
                        new SurveyQuestion { Id = i * 15 - 13, Content = "Has doctor been polite?", Grade = 0, SurveyCategoryId = i * 3 - 2 },
                        new SurveyQuestion { Id = i * 15 - 12, Content = "Has he explained you your condition enough that you can understand it?", Grade = 0, SurveyCategoryId = i * 3 - 2 },
                        new SurveyQuestion { Id = i * 15 - 11, Content = "How would you rate doctors' professionalism?", Grade = 0, SurveyCategoryId = i * 3 - 2 },
                        new SurveyQuestion { Id = i * 15 - 10, Content = "Your general grade for doctors' service", Grade = 0, SurveyCategoryId = i * 3 - 2 },

                        new SurveyQuestion { Id = i * 15 - 9, Content = "How much our medical staff were polite?", Grade = 0, SurveyCategoryId = i * 3 - 1 },
                        new SurveyQuestion { Id = i * 15 - 8, Content = "How would you rate time span that you spend waiting untill doctor attended you?", Grade = 0, SurveyCategoryId = i * 3 - 1 },
                        new SurveyQuestion { Id = i * 15 - 7, Content = "How prepared were stuff for emergency situations?", Grade = 0, SurveyCategoryId = i * 3 - 1 },
                        new SurveyQuestion { Id = i * 15 - 6, Content = "How good has stuff explained you our procedures?", Grade = 0, SurveyCategoryId = i * 3 - 1 },
                        new SurveyQuestion { Id = i * 15 - 5, Content = "Your general grade for medical stuffs' service", Grade = 0, SurveyCategoryId = i * 3 - 1 },

                        new SurveyQuestion { Id = i * 15 - 4, Content = "How would you rate our appointment organisation?", Grade = 0, SurveyCategoryId = i * 3 },
                        new SurveyQuestion { Id = i * 15 - 3, Content = "How would you rate hospitals' hygiene?", Grade = 0, SurveyCategoryId = i * 3 },
                        new SurveyQuestion { Id = i * 15 - 2, Content = "How good were procedure for booking appointment?", Grade = 0, SurveyCategoryId = i * 3 },
                        new SurveyQuestion { Id = i * 15 - 1, Content = "How easy was to use our application?", Grade = 0, SurveyCategoryId = i * 3 },
                        new SurveyQuestion { Id = i * 15, Content = "Your general grade for whole hospital' service", Grade = 0, SurveyCategoryId = i * 3 });
                }
            }

            modelBuilder.Entity<Survey>().HasData(
                new Survey { Id = 10, Done = true, SurveyCategories = new List<SurveyCategory>(), AppointmentId = 10 });

            modelBuilder.Entity<SurveyCategory>().HasData(
                new SurveyCategory { Id = 28, Name = "Doctor", SurveyQuestions = new List<SurveyQuestion>(), SurveyId = 10 },
                new SurveyCategory { Id = 29, Name = "Medical stuff", SurveyQuestions = new List<SurveyQuestion>(), SurveyId = 10 },
                new SurveyCategory { Id = 30, Name = "Hospital", SurveyQuestions = new List<SurveyQuestion>(), SurveyId = 10 });

            modelBuilder.Entity<SurveyQuestion>().HasData(
                new SurveyQuestion { Id = 136, Content = "How careful did doctor listen you?", Grade = 1, SurveyCategoryId = 28 },
                new SurveyQuestion { Id = 137, Content = "Has doctor been polite?", Grade = 3, SurveyCategoryId = 28 },
                new SurveyQuestion { Id = 138, Content = "Has he explained you your condition enough that you can understand it?", Grade = 4, SurveyCategoryId = 28 },
                new SurveyQuestion { Id = 139, Content = "How would you rate doctors' professionalism?", Grade = 5, SurveyCategoryId = 28 },
                new SurveyQuestion { Id = 140, Content = "Your general grade for doctors' service", Grade = 3, SurveyCategoryId = 28 },

                new SurveyQuestion { Id = 141, Content = "How much our medical staff were polite?", Grade = 2, SurveyCategoryId = 29 },
                new SurveyQuestion { Id = 142, Content = "How would you rate time span that you spend waiting untill doctor attended you?", Grade = 3, SurveyCategoryId = 29 },
                new SurveyQuestion { Id = 143, Content = "How prepared were stuff for emergency situations?", Grade = 4, SurveyCategoryId = 29 },
                new SurveyQuestion { Id = 144, Content = "How good has stuff explained you our procedures?", Grade = 5, SurveyCategoryId = 29 },
                new SurveyQuestion { Id = 145, Content = "Your general grade for medical stuffs' service", Grade = 3, SurveyCategoryId = 29 },

                new SurveyQuestion { Id = 146, Content = "How would you rate our appointment organisation?", Grade = 1, SurveyCategoryId = 30 },
                new SurveyQuestion { Id = 147, Content = "How would you rate hospitals' hygiene?", Grade = 4, SurveyCategoryId = 30 },
                new SurveyQuestion { Id = 148, Content = "How good were procedure for booking appointment?", Grade = 4, SurveyCategoryId = 30 },
                new SurveyQuestion { Id = 149, Content = "How easy was to use our application?", Grade = 5, SurveyCategoryId = 30 },
                new SurveyQuestion { Id = 150, Content = "Your general grade for whole hospital' service", Grade = 3, SurveyCategoryId = 30 });


            modelBuilder.Entity<Doctor>().HasData(
               new Doctor()
               {
                   Id = 1,
                   Name = "Nikola",
                   Surname = "Nikolic",
                   Gender = "male",
                   BirthDate = new System.DateTime(1981, 05, 06),
                   Salary = 80000.0,
                   Address = "Brace Radica 15",
                   Phone = "0697856665",
                   Email = "nikolanikolic@gmail.com",
                   Username = "nikola",
                   Password = "nikola",
                   EmploymentDate = new System.DateTime(2021, 06, 10),
                   WorkDay = null,
                   Specialty = "General medicine",
                   PrimaryRoom = 1,
                   WorkShiftId = 2
               },

                new Doctor()
                {
                    Id = 2,
                    Name = "Marko",
                    Surname = "Radic",
                    Gender = "male",
                    BirthDate = new System.DateTime(1986, 04, 06),
                    Salary = 80000.0,
                    Address = "Bogoboja Atanackovica 5",
                    Phone = "0697856665",
                    Email = "markoradic@gmail.com",
                    Username = "marko",
                    Password = "marko",
                    EmploymentDate = new System.DateTime(2020, 06, 07),
                    WorkDay = null,
                    Specialty = "General medicine",
                    PrimaryRoom = 2,
                    WorkShiftId = 1
                },
                new Doctor()
                {
                    Id = 3,
                    Name = "Jozef",
                    Surname = "Sivc",
                    Gender = "male",
                    BirthDate = new System.DateTime(1986, 04, 06),
                    Salary = 80000.0,
                    Address = "Bulevar Oslobodjenja 5",
                    Phone = "0697856665",
                    Email = "jozika@gmail.com",
                    Username = "jozef",
                    Password = "jozef",
                    EmploymentDate = new System.DateTime(2011, 03, 10),
                    WorkDay = null,
                    Specialty = "General medicine",
                    PrimaryRoom = 3,
                    WorkShiftId = 1
                },
                new Doctor()
                {
                    Id = 4,
                    Name = "Dragana",
                    Surname = "Zoric",
                    Gender = "female",
                    BirthDate = new System.DateTime(1968, 01, 08),
                    Salary = 80000.0,
                    Address = "Mike Antice 5",
                    Phone = "0697856665",
                    Email = "dragana@gmail.com",
                    Username = "dragana",
                    Password = "dragana",
                    EmploymentDate = new System.DateTime(2017, 03, 10),
                    WorkDay = null,
                    Specialty = "Surgery",
                    PrimaryRoom = 4,
                    WorkShiftId = 2
                },
                new Doctor()
                {
                    Id = 5,
                    Name = "Mile",
                    Surname = "Grandic",
                    Gender = "male",
                    BirthDate = new System.DateTime(1978, 11, 07),
                    Salary = 80000.0,
                    Address = "Pariske Komune 35",
                    Phone = "0697856665",
                    Email = "mile@gmail.com",
                    Username = "mile",
                    Password = "mile",
                    EmploymentDate = new System.DateTime(2007, 03, 10),
                    WorkDay = null,
                    Specialty = "Surgery",
                    PrimaryRoom = 5,
                    WorkShiftId = 2
                },
                new Doctor()
                {
                    Id = 6,
                    Name = "Misa",
                    Surname = "Bradina",
                    Gender = "male",
                    BirthDate = new System.DateTime(1968, 06, 07),
                    Salary = 80000.0,
                    Address = "Pariske Komune 85",
                    Phone = "0697856665",
                    Email = "misa@gmail.com",
                    Username = "misa",
                    Password = "misa",
                    EmploymentDate = new System.DateTime(2006, 03, 10),
                    WorkDay = null,
                    Specialty = "General medicine",
                    PrimaryRoom = 6,
                    WorkShiftId = 1
                }
            );

            modelBuilder.Entity<WorkDayShift>(b =>
            {
                b.HasData(new WorkDayShift
                {
                    Id = 1,
                    Name = "First"
                });
                b.OwnsOne(e => e.WorkHour).HasData(new
                {
                    WorkDayShiftId = 1,
                    StartTime = new DateTime(2022, 2, 22, 7, 0, 0),
                    EndTime = new DateTime(2022, 2, 22, 13, 0, 0)
                });
            });

            modelBuilder.Entity<WorkDayShift>(b =>
            {
                b.HasData(new WorkDayShift
                {
                    Id = 2,
                    Name = "Second"
                });
                b.OwnsOne(e => e.WorkHour).HasData(new
                {
                    WorkDayShiftId = 2,
                    StartTime = new DateTime(2022, 2, 22, 13, 0, 0),
                    EndTime = new DateTime(2022, 2, 22, 19, 0, 0)
                });
            });

            modelBuilder.Entity<Patient>().HasData(
                new Patient(1, "Petar", "Petrovic", "male", "A", new System.DateTime(2005, 09, 11), "Bogoboja Atanackovica 15", "0634556665", "petar@gmail.com", "petar", "petar", "miki", null, "Employed", true)
                { DoctorId = 1 },
                new Patient(2, "Jovan", "Zoric", "male", "A", new System.DateTime(1985, 07, 11), "Voje Rodica 19", "0697856665", "miki@gmail.com", "jovan", "jovan", "miki", null, "Employed", true)
                { DoctorId = 2 },
                new Patient(3, "Zorana", "Bilic", "male", "A", new System.DateTime(1978, 07, 11), "Voje Rodica 19", "0697856665", "miki@gmail.com", "zorana", "zorana", "miki", null, "Employed", true)
                { DoctorId = 2 },
                new Patient(4, "Milica", "Maric", "male", "A", new System.DateTime(1969, 07, 11), "Voje Rodica 19", "0697856665", "miki@gmail.com", "milica", "milica", "miki", null, "Employed", true)
                { DoctorId = 3 },
                new Patient(5, "Igor", "Caric", "male", "A", new System.DateTime(1936, 07, 11), "Voje Rodica 19", "0697856665", "miki@gmail.com", "igor", "igor", "miki", null, "Employed", true)
                { DoctorId = 3 },
                new Patient(6, "Predrag", "Zaric", "male", "A", new System.DateTime(1975, 07, 11), "Voje Rodica 19", "0697856665", "miki@gmail.com", "predrag", "predrag", "miki", null, "Employed", true)
                { DoctorId = 3 },
                new Patient(7, "Miki", "Nikolic", "male", "A", new System.DateTime(1960, 07, 11), "Voje Rodica 19", "0697856665", "miki@gmail.com", "miki", "miki", "miki", null, "Employed", true)
                { DoctorId = 3 },
                new Patient(8, "Zorka", "Djokic", "female", "B", new System.DateTime(1987, 07, 01), "Kralja Petra 19", "0697856665", "zorka@gmail.com", "zorka", "zorka", "zorka", null, "Unemployed", true)
                { DoctorId = 6 }
                );

            modelBuilder.Entity<AllergenForPatient>()
                .HasKey(c => new { c.PatientId, c.AllergenId });


            modelBuilder.Entity<CanceledAppointment>()
                .HasKey(c => new { c.PatientId, c.AppointmentId });

            modelBuilder.Entity<CanceledAppointment>().HasData(
                new CanceledAppointment { AppointmentId = 1764, PatientId = 1, DateOfCancellation = new System.DateTime(2021, 12, 11) },
                new CanceledAppointment { AppointmentId = 1765, PatientId = 1, DateOfCancellation = new System.DateTime(2021, 12, 21) },
                new CanceledAppointment { AppointmentId = 1763, PatientId = 1, DateOfCancellation = new System.DateTime(2021, 12, 30) },
                new CanceledAppointment { AppointmentId = 1766, PatientId = 1, DateOfCancellation = new System.DateTime(2021, 12, 19) },
                new CanceledAppointment { AppointmentId = 1777, PatientId = 1, DateOfCancellation = new System.DateTime(2021, 12, 22) },
                new CanceledAppointment { AppointmentId = 1767, PatientId = 6, DateOfCancellation = new System.DateTime(2021, 12, 8) },
                new CanceledAppointment { AppointmentId = 1768, PatientId = 6, DateOfCancellation = new System.DateTime(2021, 12, 6) },
                new CanceledAppointment { AppointmentId = 1769, PatientId = 6, DateOfCancellation = new System.DateTime(2021, 12, 7) },
                new CanceledAppointment { AppointmentId = 1799, PatientId = 2, DateOfCancellation = new System.DateTime(2021, 12, 11) },
                new CanceledAppointment { AppointmentId = 1780, PatientId = 6, DateOfCancellation = new System.DateTime(2021, 12, 21) },
                new CanceledAppointment { AppointmentId = 1870, PatientId = 1, DateOfCancellation = new System.DateTime(2021, 12, 22) });
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            //optionsBuilder.UseNpgsql("Server=localhost;Port=5432;Database=PharmacyDatabase;User id=postgres;Password=admin").UseLazyLoadingProxies();
            //optionsBuilder.UseNpgsql("Server=postgres-database;Port=5432;Database=PharmacyDatabase;User id=postgres;Password=admin").UseLazyLoadingProxies();
            optionsBuilder.UseNpgsql(CreateConnectionStringFromEnvironment()).UseLazyLoadingProxies();
        }
        private static string CreateConnectionStringFromEnvironment()
        {
            var server = Environment.GetEnvironmentVariable("DATABASE_HOST_HOSPITAL") ?? "localhost";
            var port = Environment.GetEnvironmentVariable("DATABASE_PORT") ?? "5432";
            var database = Environment.GetEnvironmentVariable("DATABASE_SCHEMA_HOSPITAL") ?? "hospitalDb";
            var user = Environment.GetEnvironmentVariable("DATABASE_USERNAME") ?? "postgres";
            var password = Environment.GetEnvironmentVariable("DATABASE_PASSWORD") ?? "password";

            return
                $"Server={server};Port={port};Database={database};User ID={user};Password={password};";
        }
    }
}