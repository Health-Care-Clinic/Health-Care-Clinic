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
    public class TransfersTests
    {
        private DbContextOptions<HospitalDbContext> CreateStubRepository()
        {
            var options = new DbContextOptionsBuilder<HospitalDbContext>()
            .UseInMemoryDatabase(databaseName: "Transfer")
            .Options;

            using (var context = new HospitalDbContext(options))
            {
                context.Transfer.Add(new Transfer { Id = 1, Equipment = "Bed", Quantity = 5, SourceRoomId = 1, DestinationRoomId = 2, Date = new DateTime(2021, 11, 28, 9, 0 ,0), Duration = 60 });
                context.Transfer.Add(new Transfer { Id = 2, Equipment = "TV", Quantity = 2, SourceRoomId = 1, DestinationRoomId = 15, Date = new DateTime(2021, 11, 29, 10, 0, 0), Duration = 30 });
                context.Transfer.Add(new Transfer { Id = 3, Equipment = "Blanket", Quantity = 7, SourceRoomId = 11, DestinationRoomId = 20, Date = new DateTime(2021, 11, 30, 15, 30, 0), Duration = 45 });
                context.SaveChanges();
            }

            return options;
        }

        [Fact]
        public void Get_all_transfers()
        {
            var options = CreateStubRepository();

            using (var context = new HospitalDbContext(options))
            {
                TransferRepository transferRepository = new TransferRepository(context);
                TransferService transferService = new TransferService(transferRepository);
                TransferController transferController = new TransferController(transferService, null);

                OkObjectResult a = transferController.GetAllTransfers() as OkObjectResult;
                List<TransferDTO> transfers = a.Value as List<TransferDTO>;
                foreach (Transfer t in context.Transfer)
                {
                    context.Transfer.Remove(t);
                    context.SaveChanges();
                }

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
                TransferService transferService = new TransferService(transferRepository);
                TransferController transferController = new TransferController(transferService, null);

                TransferDTO transfer = new TransferDTO(5, "Bed", 5, 1, 2, new DateTime(2021, 11, 28, 9, 0, 0), 60);
                OkObjectResult a = transferController.AddNewTransfer(transfer) as OkObjectResult;
                context.SaveChanges();

                OkObjectResult tc = transferController.GetAllTransfers() as OkObjectResult;

                List<TransferDTO> transfers = tc.Value as List<TransferDTO>;

                foreach (Transfer t in context.Transfer)
                {
                    context.Transfer.Remove(t);
                    context.SaveChanges();
                }

                Assert.Equal(4, transfers.Count);
            }
        }
    }
}
