using Hospital.Mapper;
using Hospital.Rooms_and_equipment.Model;
using Hospital.Rooms_and_equipment.Repository;
using Hospital.Rooms_and_equipment.Service;
using Hospital_API.Controller;
using Hospital_API.DTO;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using Xunit;
using static Hospital.Rooms_and_equipment.Model.Equipment;
using static Hospital.Rooms_and_equipment.Model.Room;

namespace HospitalUnitTests.Graphical_editor
{
    public class TransfersTests
    {
        private DbContextOptions<HospitalDbContext> CreateStubRepository()
        {
            var options = new DbContextOptionsBuilder<HospitalDbContext>()
            .UseInMemoryDatabase(databaseName: "Transfer")
            .Options;

            using (var context = new HospitalDbContext(options))
            {
                context.Transfer.Add(new Transfer { Id = 1, Equipment = "Bed", Quantity = 5, SourceRoomId = 1, DestinationRoomId = 2, Date = new DateTime(2021, 12, 1, 9, 0 ,0), Duration = 60 });
                context.Transfer.Add(new Transfer { Id = 2, Equipment = "TV", Quantity = 2, SourceRoomId = 1, DestinationRoomId = 2, Date = new DateTime(2021, 11, 28, 11, 0, 0), Duration = 30 });
                context.Transfer.Add(new Transfer { Id = 3, Equipment = "Blanket", Quantity = 7, SourceRoomId = 11, DestinationRoomId = 2, Date = new DateTime(2021, 11, 30, 15, 30, 0), Duration = 45 });
                context.Rooms.Add(new Room { Id = 1, Name = "Operation room 1", Type = RoomType.OperationRoom, X = 10, Y = 10, Width = 100, Height = 200, FloorId = 1 });
                context.Rooms.Add(new Room { Id = 2, Name = "Operation room 2", Type = RoomType.OperationRoom, X = 100, Y = 100, Width = 190, Height = 110, FloorId = 1 });
                context.Equipments.Add(new Equipment { Id = 1, Name = "Bed", Type = EquipmentType.Static, Quantity = 25, RoomId = 1 });
                context.Equipments.Add(new Equipment { Id = 2, Name = "TV", Type = EquipmentType.Static, Quantity = 2, RoomId = 2 });
                context.Equipments.Add(new Equipment { Id = 3, Name = "TV", Type = EquipmentType.Static, Quantity = 25, RoomId = 1 });
                context.Equipments.Add(new Equipment { Id = 4, Name = "Blanket", Type = EquipmentType.Dynamic, Quantity = 25, RoomId = 1 });
                context.SaveChanges();
            }

            return options;
        }

        private void ClearStubRepository(HospitalDbContext context) 
        {
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
            foreach (Room r in context.Rooms)
            {
                context.Rooms.Remove(r);
                context.SaveChanges();
            }
        }

        [Fact]
        public void Update_room_equipment_after_transfer()
        {
            var options = CreateStubRepository();

            using (var context = new HospitalDbContext(options))
            {
                TransferRepository transferRepository = new TransferRepository(context);
                EquipmentRepository equipmentRepository = new EquipmentRepository(context);
                TransferService transferService = new TransferService(transferRepository);
                EquipmentService equipmentService = new EquipmentService(equipmentRepository);
                TransferController transferController = new TransferController(transferService, equipmentService);
                EquipmentController equipmentController = new EquipmentController(equipmentService, transferService);

                OkObjectResult transfersResponse = transferController.GetAllTransfers() as OkObjectResult;
                OkObjectResult equipmentResponse = equipmentController.GetEquipmentByRoomId(2) as OkObjectResult;
                List<EquipmentDTO> roomEquipment = equipmentResponse.Value as List<EquipmentDTO>;
                EquipmentDTO equipment = roomEquipment.Find(e => e.Name == "TV");
                ClearStubRepository(context);

                Assert.Equal(4, equipment.Quantity);
            }
        }

        [Fact]
        public void Get_all_transfers()
        {
            var options = CreateStubRepository();

            using (var context = new HospitalDbContext(options))
            {
                TransferRepository transferRepository = new TransferRepository(context);
                EquipmentRepository equipmentRepository = new EquipmentRepository(context);
                TransferService transferService = new TransferService(transferRepository);
                EquipmentService equipmentService = new EquipmentService(equipmentRepository);
                TransferController transferController = new TransferController(transferService, equipmentService);

                OkObjectResult transfersResponse = transferController.GetAllTransfers() as OkObjectResult;
                List<TransferDTO> transfers = transfersResponse.Value as List<TransferDTO>;
                ClearStubRepository(context);

                Assert.Equal(3, transfers.Count);
            }
        }

        [Fact]
        public void Add_transfer()
        {
            var options = CreateStubRepository();

            using (var context = new HospitalDbContext(options))
            {
                TransferRepository transferRepository = new TransferRepository(context);
                EquipmentRepository equipmentRepository = new EquipmentRepository(context);
                TransferService transferService = new TransferService(transferRepository);
                EquipmentService equipmentService = new EquipmentService(equipmentRepository);
                TransferController transferController = new TransferController(transferService, equipmentService);

                TransferDTO transfer = new TransferDTO(5, "Bed", 5, 1, 2, new DateTime(2021, 12, 2, 9, 0, 0), 60);
                OkObjectResult addTransferResponse = transferController.AddNewTransfer(transfer) as OkObjectResult;
                context.SaveChanges();

                OkObjectResult transfersResponse = transferController.GetAllTransfers() as OkObjectResult;
                List<TransferDTO> transfers = transfersResponse.Value as List<TransferDTO>;
                ClearStubRepository(context);

                Assert.Equal(4, transfers.Count);
            }
        }

        [Fact]
        public void Check_available_free_term_for_transfer()
        {
            var options = CreateStubRepository();

            using (var context = new HospitalDbContext(options))
            {
                TransferRepository transferRepository = new TransferRepository(context);
                EquipmentRepository equipmentRepository = new EquipmentRepository(context);
                TransferService transferService = new TransferService(transferRepository);
                EquipmentService equipmentService = new EquipmentService(equipmentRepository);
                TransferController transferController = new TransferController(transferService, equipmentService);

                TransferDTO transfer = new TransferDTO(5, "Bed", 5, 1, 2, new DateTime(2021, 12, 1, 15, 0, 0), 60);
                OkObjectResult transfersResponse = transferController.checkFreeTransfers(transfer) as OkObjectResult;
                List<DateTime> freeTerms = transfersResponse.Value as List<DateTime>;
                ClearStubRepository(context);

                Assert.Contains(new DateTime(2021, 12, 1, 10, 30, 0), freeTerms);
            }
        }

        [Fact]
        public void Check_unavailable_free_term_for_transfer()
        {
            var options = CreateStubRepository();

            using (var context = new HospitalDbContext(options))
            {
                TransferRepository transferRepository = new TransferRepository(context);
                EquipmentRepository equipmentRepository = new EquipmentRepository(context);
                TransferService transferService = new TransferService(transferRepository);
                EquipmentService equipmentService = new EquipmentService(equipmentRepository);
                TransferController transferController = new TransferController(transferService, equipmentService);

                TransferDTO transfer = new TransferDTO(5, "Bed", 5, 1, 2, new DateTime(2021, 12, 1, 15, 0, 0), 60);
                OkObjectResult transfersResponse = transferController.checkFreeTransfers(transfer) as OkObjectResult;
                List<DateTime> freeTerms = transfersResponse.Value as List<DateTime>;
                ClearStubRepository(context);

                Assert.DoesNotContain(new DateTime(2021, 12, 1, 9, 30, 0), freeTerms);
            }
        }
    }
}
