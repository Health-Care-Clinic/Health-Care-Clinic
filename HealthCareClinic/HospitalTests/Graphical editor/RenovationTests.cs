using Hospital.Mapper;
using Hospital.Rooms_and_equipment.Model;
using Hospital.Rooms_and_equipment.Repository;
using Hospital.Rooms_and_equipment.Service;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using Xunit;
using static Hospital.Rooms_and_equipment.Model.Equipment;

namespace HospitalUnitTests.Graphical_editor
{
    public class RenovationTests
    {
        private DbContextOptions<HospitalDbContext> CreateStubRepository()
        {
            var options = new DbContextOptionsBuilder<HospitalDbContext>()
            .UseInMemoryDatabase(databaseName: "Renovations")
            .Options;

            using (var context = new HospitalDbContext(options))
            {
                context.Renovations.Add(new Renovation { Id = 1, FirstRoomId = 1, SecondRoomId = 2, Duration = 2, Date = new DateTime(2022, 02, 02, 14, 00, 00), Type = Renovation.RenovationType.Merge });
                context.Renovations.Add(new Renovation { Id = 2, FirstRoomId = 1, SecondRoomId = 0, Duration = 3, Date = new DateTime(2022, 02, 05, 15, 00, 00), Type = Renovation.RenovationType.Divide });
                context.Renovations.Add(new Renovation { Id = 3, FirstRoomId = 47, SecondRoomId = 62, Duration = 2, Date = new DateTime(2022, 02, 20, 14, 00, 00), Type = Renovation.RenovationType.Merge });
                context.Transfer.Add(new Transfer { Id = 1, Equipment = "Bed", Quantity = 5, SourceRoomId = 1, DestinationRoomId = 2, Date = new DateTime(2021, 12, 31, 9, 0, 0), Duration = 60 });
                context.Transfer.Add(new Transfer { Id = 2, Equipment = "TV", Quantity = 2, SourceRoomId = 1, DestinationRoomId = 2, Date = new DateTime(2021, 11, 28, 11, 0, 0), Duration = 30 });
                context.Transfer.Add(new Transfer { Id = 3, Equipment = "Blanket", Quantity = 7, SourceRoomId = 1, DestinationRoomId = 2, Date = new DateTime(2021, 12, 25, 15, 30, 0), Duration = 45 });
                context.Transfer.Add(new Transfer { Id = 4, Equipment = "Needle", Quantity = 25, SourceRoomId = 1, DestinationRoomId = 2, Date = new DateTime(2021, 10, 25, 15, 30, 0), Duration = 45 });
                context.Rooms.Add(new Room { Id = 1, Name = "Operation room 1", Type = Room.RoomType.OperationRoom, X = 10, Y = 100, Width = 100, Height = 200, FloorId = 1 });
                context.Rooms.Add(new Room { Id = 2, Name = "Operation room 2", Type = Room.RoomType.OperationRoom, X = 110, Y = 100, Width = 190, Height = 110, FloorId = 1 });
                context.Equipments.Add(new Equipment { Id = 1, Name = "Bed", Type = EquipmentType.Static, Quantity = 25, RoomId = 1 });
                context.Equipments.Add(new Equipment { Id = 2, Name = "TV", Type = EquipmentType.Static, Quantity = 2, RoomId = 2 });
                context.Equipments.Add(new Equipment { Id = 3, Name = "TV", Type = EquipmentType.Static, Quantity = 25, RoomId = 1 });
                context.Equipments.Add(new Equipment { Id = 4, Name = "Blanket", Type = EquipmentType.Dynamic, Quantity = 25, RoomId = 1 });
                context.Equipments.Add(new Equipment { Id = 5, Name = "Needle", Type = EquipmentType.Dynamic, Quantity = 25, RoomId = 1 });
                context.SaveChanges();
            }

            return options;
        }

        private void ClearStubRepository(HospitalDbContext context)
        {
            foreach (Renovation re in context.Renovations)
            {
                context.Renovations.Remove(re);
                context.SaveChanges();
            }
            foreach (Room r in context.Rooms)
            {
                context.Rooms.Remove(r);
                context.SaveChanges();
            }
            foreach (Transfer t in context.Transfer)
            {
                context.Transfer.Remove(t);
                context.SaveChanges();
            }
            foreach (Equipment e in context.Equipments)
            {
                context.Equipments.Remove(e);
                context.SaveChanges();
            }
        }

        [Fact]
        public void Check_available_free_term_for_renovation()
        {
            var options = CreateStubRepository();

            using (var context = new HospitalDbContext(options))
            {
                RenovationRepository renovationRepository = new RenovationRepository(context);
                TransferRepository transferRepository = new TransferRepository(context);
                RenovationService renovationService = new RenovationService(renovationRepository, transferRepository);
                Renovation renovation = new Renovation(4, 1,2, new DateTime(2021, 12, 31, 14, 30, 00), 1,Renovation.RenovationType.Merge);
                List<DateTime> freeTerms = renovationService.getFreeTermsForMerge(renovation);
                ClearStubRepository(context);

                Assert.Contains(new DateTime(2021, 12, 30, 8, 30, 0), freeTerms);
            }
        }


    }
}
