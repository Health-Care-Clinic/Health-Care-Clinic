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

namespace HospitalUnitTests.Graphical_editor
{
    public class CancelTransfer
    {
        private DbContextOptions<HospitalDbContext> CreateStubRepository()
        {
            var options = new DbContextOptionsBuilder<HospitalDbContext>()
            .UseInMemoryDatabase(databaseName: "CancelTransfer")
            .Options;

            using (var context = new HospitalDbContext(options))
            {
                context.Transfer.Add(new Transfer { Id = 1, Equipment = "Bed", Quantity = 5, SourceRoomId = 1, DestinationRoomId = 2, Date = new DateTime(2021, 12, 31, 9, 0, 0), Duration = 60 });
                context.Transfer.Add(new Transfer { Id = 2, Equipment = "TV", Quantity = 2, SourceRoomId = 1, DestinationRoomId = 2, Date = new DateTime(2021, 12, 28, 11, 0, 0), Duration = 30 });
                context.Transfer.Add(new Transfer { Id = 3, Equipment = "Blanket", Quantity = 7, SourceRoomId = 2, DestinationRoomId = 5, Date = new DateTime(2021, 12, 25, 15, 30, 0), Duration = 45 });
                context.Transfer.Add(new Transfer { Id = 4, Equipment = "Needle", Quantity = 4, SourceRoomId = 8, DestinationRoomId = 9, Date = DateTime.Now.AddHours(20), Duration = 45 });
                context.Transfer.Add(new Transfer { Id = 5, Equipment = "Bandage", Quantity = 3, SourceRoomId = 7, DestinationRoomId = 12, Date = DateTime.Now.AddHours(30), Duration = 45 });
                context.SaveChanges();
            }

            return options;
        }

        [Fact]
        public void Cancel_transfer()
        {
            var options = CreateStubRepository();

            using (var context = new HospitalDbContext(options))
            {
                TransferRepository transferRepository = new TransferRepository(context);
                EquipmentRepository equipmentRepository = new EquipmentRepository(context);
                TransferService transferService = new TransferService(transferRepository);
                EquipmentService equipmentService = new EquipmentService(equipmentRepository);
                TransferController transferController = new TransferController(transferService, equipmentService);

                OkObjectResult getRoomTransfersResponse = transferController.GetRoomTransfers(1) as OkObjectResult;
                List<TransferDTO> roomTransfers = getRoomTransfersResponse.Value as List<TransferDTO>;
                OkObjectResult transfersResponse = transferController.CancelTransfer(roomTransfers[0]) as OkObjectResult;
                OkObjectResult getRoomTransfersAfterCancelResponse = transferController.GetRoomTransfers(1) as OkObjectResult;
                List<TransferDTO> roomTransfersAfterCancel = getRoomTransfersAfterCancelResponse.Value as List<TransferDTO>;
                foreach (Transfer t in context.Transfer)
                {
                    context.Transfer.Remove(t);
                    context.SaveChanges();
                }

                Assert.Single(roomTransfersAfterCancel);
            }
        }

        [Theory]
        [MemberData(nameof(Data))]
        public void Check_if_transfer_is_cancellable(int transferId, bool cancellable)
        {
            var options = CreateStubRepository();

            using (var context = new HospitalDbContext(options))
            {
                TransferRepository transferRepository = new TransferRepository(context);
                EquipmentRepository equipmentRepository = new EquipmentRepository(context);
                TransferService transferService = new TransferService(transferRepository);
                EquipmentService equipmentService = new EquipmentService(equipmentRepository);
                TransferController transferController = new TransferController(transferService, equipmentService);

                OkObjectResult transfersResponse = transferController.CheckIfTransferCancellable(transferId) as OkObjectResult;
                bool isCancellable = (bool)transfersResponse.Value;
                foreach (Transfer t in context.Transfer)
                {
                    context.Transfer.Remove(t);
                    context.SaveChanges();
                }

                Assert.Equal(cancellable, isCancellable);
            }
        }

        public static IEnumerable<object[]> Data()
        {
            var retVal = new List<object[]>();

            retVal.Add(new object[] { 4, false });
            retVal.Add(new object[] { 5, true });

            return retVal;
        }
    }
}
