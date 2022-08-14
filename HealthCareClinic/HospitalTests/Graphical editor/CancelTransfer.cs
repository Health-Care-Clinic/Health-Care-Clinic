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

        [Theory]
        [MemberData(nameof(Data_mock))]
        public void Check_if_transfer_is_cancellable(int transferId, bool cancellable)
        {
            TransferService transferService = new TransferService(CreateStubRepository());

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

        private static ITransferRepository CreateStubRepository()
        {
            List<Transfer> transfers = new List<Transfer>();
            var stubRepository = new Mock<ITransferRepository>();

            transfers.Add(new Transfer { Id = 1, Equipment = new EquipmentForTransfer("Needle", 4), RoomsForTransfer = new RoomsForTransfer(1, 2), DateAndDuration = new DateAndDuration(DateTime.Now.AddHours(1), 45) });
            transfers.Add(new Transfer { Id = 2, Equipment = new EquipmentForTransfer("Bandage", 3), RoomsForTransfer = new RoomsForTransfer(1, 2), DateAndDuration = new DateAndDuration(DateTime.Now.AddHours(25), 45) });

            stubRepository.Setup(m => m.GetAll()).Returns(transfers);

            return stubRepository.Object;
        }
    }
}
