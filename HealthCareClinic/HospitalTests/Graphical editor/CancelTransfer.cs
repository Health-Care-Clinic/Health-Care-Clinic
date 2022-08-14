using Hospital.Mapper;
using Hospital.Rooms_and_equipment.Model;
using Hospital.Rooms_and_equipment.Repository;
using Hospital.Rooms_and_equipment.Service;
using Hospital_API.Controller;
using Hospital_API.DTO;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Moq;
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
                context.Transfer.Add(new Transfer { Id = 1, Equipment = new EquipmentForTransfer("Bed", 5), RoomsForTransfer = new RoomsForTransfer(1, 2), DateAndDuration = new DateAndDuration(new DateTime(2021, 12, 31, 9, 0, 0), 60) });
                context.Transfer.Add(new Transfer { Id = 2, Equipment = new EquipmentForTransfer("TV", 2), RoomsForTransfer = new RoomsForTransfer(1, 2), DateAndDuration = new DateAndDuration(new DateTime(2021, 12, 28, 11, 0, 0), 30) });
                context.Transfer.Add(new Transfer { Id = 3, Equipment = new EquipmentForTransfer("Blanket", 7), RoomsForTransfer = new RoomsForTransfer(2, 5), DateAndDuration = new DateAndDuration(new DateTime(2021, 12, 25, 15, 30, 0),  45) });
                context.Transfer.Add(new Transfer { Id = 4, Equipment = new EquipmentForTransfer("Needle", 4), RoomsForTransfer = new RoomsForTransfer(8, 9), DateAndDuration = new DateAndDuration(DateTime.Now.AddHours(20), 45) });
                context.Transfer.Add(new Transfer { Id = 5, Equipment = new EquipmentForTransfer("Bandage", 3), RoomsForTransfer = new RoomsForTransfer(7, 12), DateAndDuration = new DateAndDuration(DateTime.Now.AddHours(30), 45) });
                context.SaveChanges();
            }

            return options;
        }

        private static ITransferRepository CreateTransferStubRepository()
        {
            List<Transfer> transfers = new List<Transfer>();
            var stubRepository = new Mock<ITransferRepository>();

            transfers.Add(new Transfer { Id = 1, Equipment = new EquipmentForTransfer("Needle", 4), RoomsForTransfer = new RoomsForTransfer(1, 2), DateAndDuration = new DateAndDuration(DateTime.Now.AddHours(20), 45) });
            transfers.Add(new Transfer { Id = 2, Equipment = new EquipmentForTransfer("Bandage", 3), RoomsForTransfer = new RoomsForTransfer(1, 2), DateAndDuration = new DateAndDuration(DateTime.Now.AddHours(30), 45) });

            stubRepository.Setup(m => m.GetAll()).Returns(transfers);

            return stubRepository.Object;
        }

        private void ClearStubRepository(HospitalDbContext context)
        {
            foreach (Transfer t in context.Transfer)
            {
                context.Transfer.Remove(t);
                context.SaveChanges();
            }
        }

        //Los test
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

                bool isCancellable = transferService.CheckIfTransferCancellable(transferId);
                ClearStubRepository(context);

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


        //Dobar test
        [Theory]
        [MemberData(nameof(Data_mock))]
        public void Check_if_transfer_is_cancellable_with_mock(int transferId, bool cancellable)
        {
                TransferService transferService = new TransferService(CreateTransferStubRepository());

                bool isCancellable = transferService.CheckIfTransferCancellable(transferId);

                Assert.Equal(cancellable, isCancellable);
        }

        public static IEnumerable<object[]> Data_mock()
        {
            var retVal = new List<object[]>();

            retVal.Add(new object[] { 1, false });
            retVal.Add(new object[] { 2, true });

            return retVal;
        }
    }
}
