using Hospital.Graphical_editor.Model;
using Hospital.Mapper;
using Hospital.Rooms_and_equipment.Model;
using Hospital.Rooms_and_equipment.Repository;
using Hospital.Rooms_and_equipment.Service;
using Hospital.Shared_model.Repository;
using Hospital_API.Controller;
using Hospital_API.DTO;
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
                context.Transfer.Add(new Transfer { Id = 1, Equipment = new Equipment("Bed", 5), RoomsForTransfer = new RoomsForTransfer(1, 2), DateAndDuration = new DateAndDuration(new DateTime(2021, 12, 31, 9, 0, 0), 60) });
                context.Transfer.Add(new Transfer { Id = 2, Equipment = new Equipment("TV", 2), RoomsForTransfer = new RoomsForTransfer(1, 2), DateAndDuration = new DateAndDuration(new DateTime(2021, 11, 28, 11, 0, 0), 30) });
                context.Transfer.Add(new Transfer { Id = 3, Equipment = new Equipment("Blanket", 7), RoomsForTransfer = new RoomsForTransfer(1, 2), DateAndDuration = new DateAndDuration(new DateTime(2021, 12, 25, 15, 30, 0), 45) });
                context.Transfer.Add(new Transfer { Id = 4, Equipment = new Equipment("Needle", 25), RoomsForTransfer = new RoomsForTransfer(1, 2), DateAndDuration = new DateAndDuration(new DateTime(2021, 10, 25, 15, 30, 0), 45) });
                context.Rooms.Add(new Room { Id = 1, Name = "Operation room 1", Type = Room.RoomType.OperationRoom, PositionAndDimension = new PositionAndDimension(10, 100, 100, 200), FloorId = 1 });
                context.Rooms.Add(new Room { Id = 2, Name = "Operation room 2", Type = Room.RoomType.OperationRoom, PositionAndDimension = new PositionAndDimension(110, 100, 190, 110), FloorId = 1 });
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
                AppointmentRepository appointmentRepository = new AppointmentRepository(context);
                RenovationService renovationService = new RenovationService(renovationRepository, transferRepository, appointmentRepository);
                Renovation renovation = new Renovation(4, 1, 2, new DateTime(2022, 2, 23, 14, 30, 00), 1, Renovation.RenovationType.Merge);
                List<DateTime> freeTerms = renovationService.getFreeTermsForMerge(renovation);
                ClearStubRepository(context);


                Assert.Contains(new DateTime(2022, 2, 22, 8, 30, 0), freeTerms);
            }
        }


        [Theory]
        [MemberData(nameof(Data))]
        public void Get_room_renovations(int roomId, int roomRenovationsCount)
        {
            var options = CreateStubRepository();

            using (var context = new HospitalDbContext(options))
            {
                RenovationRepository renovationRepository = new RenovationRepository(context);
                TransferRepository transferRepository = new TransferRepository(context);
                AppointmentRepository appointmentRepository = new AppointmentRepository(context);
                RenovationService renovationService = new RenovationService(renovationRepository, transferRepository, appointmentRepository);

                List<Renovation> roomRenovations = renovationService.GetRoomRenovations(roomId);
                ClearStubRepository(context);



                Assert.Equal(roomRenovationsCount, roomRenovations.Count);
            }
        }

        public static IEnumerable<object[]> Data()
        {
            var retVal = new List<object[]>();

            retVal.Add(new object[] { 1, 2 });
            retVal.Add(new object[] { 3, 0 });

            return retVal;
        }

        [Fact]
        public void Check_equipment_transfer_from_one_room_to_another()
        {
            var options = CreateStubRepository();

            using (var context = new HospitalDbContext(options))
            {
                EquipmentRepository equipmentRepository = new EquipmentRepository(context);
                EquipmentService equipmentService = new EquipmentService(equipmentRepository);

                Equipment eq = new Equipment(4, "Blanket", EquipmentType.Dynamic, 25, 2);

                List<Equipment> newEquipment = equipmentService.TransferEquipmentFromOneRoomToAnother(2, 1);

                ClearStubRepository(context);

                Assert.Contains(eq, newEquipment);
            }
        }

        [Fact]
        public void Check_equipment_quantity_when_transfered_from_one_room_to_another()
        {
            var options = CreateStubRepository();

            using (var context = new HospitalDbContext(options))
            {
                EquipmentRepository equipmentRepository = new EquipmentRepository(context);
                EquipmentService equipmentService = new EquipmentService(equipmentRepository);

                int quantity = equipmentService.GetQuantityOfEquipmentWhenTransferedFromOneRoomToAnother("TV", 1, 2);

                ClearStubRepository(context);

                Assert.Equal(27, quantity);
            }
        }
    }
}
