using Hospital.Rooms_and_equipment.Model;
using Hospital.Rooms_and_equipment.Repository;
using Hospital.Rooms_and_equipment.Service;
using Moq;
using System.Collections.Generic;
using Xunit;
using static Hospital.Rooms_and_equipment.Model.Equipment;

namespace HospitalUnitTests.Graphical_editor
{
    public class EquipmentTransferTests
    {

        private static IEquipmentRepository CreateStubRepository()
        {
            List<Equipment> equipment = new List<Equipment>();
            var stubRepository = new Mock<IEquipmentRepository>();
            var firstRoomId = 1;
            var secondRoomId = 2;

            equipment.Add(new Equipment { Id = 1, Name = "Blanket", Type = EquipmentType.Dynamic, Quantity = 1, RoomId = firstRoomId });

            stubRepository.Setup(m => m.GetEquipmentByRoomId(firstRoomId)).Returns(equipment);
            stubRepository.Setup(m => m.GetEquipmentByRoomId(secondRoomId)).Returns(new List<Equipment>());

            return stubRepository.Object;
        }

        [Fact]
        public void Check_equipment_transfer_from_one_room_to_another()
        {
            var equipmentRepository = CreateStubRepository();
            EquipmentService equipmentService = new EquipmentService(equipmentRepository);
            var firstRoomId = 1;
            var secondRoomId = 2;
            var equipmentName = "Blanket";
            var quantity = 1;
            Equipment eq = new Equipment(1, equipmentName, EquipmentType.Dynamic, quantity, secondRoomId);

            List<Equipment> newEquipment = equipmentService.TransferEquipmentFromOneRoomToAnother(secondRoomId, firstRoomId);

            Assert.Contains(eq, newEquipment);
        }

        [Fact]
        public void Check_equipment_quantity_when_transfered_from_one_room_to_another()
        {
            var equipmentRepository = CreateStubRepository();
            EquipmentService equipmentService = new EquipmentService(equipmentRepository);
            var firstRoomId = 1;
            var secondRoomId = 2;
            var equipmentName = "Blanket";

            int quantity = equipmentService.GetQuantityOfEquipmentWhenTransferedFromOneRoomToAnother(equipmentName, secondRoomId, firstRoomId);

            Assert.Equal(1, quantity);
        }
    }
}
