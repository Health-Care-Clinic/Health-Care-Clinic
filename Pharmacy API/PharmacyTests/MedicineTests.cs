using Moq;
using Pharmacy.Model;
using Pharmacy.Repository;
using Pharmacy.Service;
using System;
using System.Collections.Generic;
using Xunit;

namespace PharmacyTests
{
    public class MedicineTests
    {
        [Fact]
        public void Reduces_medicine_quantity()
        {
            var stubRepository = new Mock<IMedicineRepository>();

            Dictionary<int, Medicine> medicines = new Dictionary<int, Medicine>();
            medicines[1] = new Medicine(1, "Brufen", 10);
            medicines[2] = new Medicine(2, "Bromazepam", 20);

            stubRepository.Setup(m => m.GetAll()).Returns(medicines.Values);

            Medicine brufen = new Medicine(1, "Brufen", 3);
            
            stubRepository.Setup(m => m.Update(brufen)).Callback((Medicine brufen) => medicines[brufen.Id] = brufen);

            MedicineService service = new MedicineService(stubRepository.Object);

            service.ReduceMedicineQuantity(brufen.Name, brufen.Quantity);

            Assert.Equal(7, medicines[1].Quantity);
        }

        [Fact]
        public void Medicine_exists_in_quantity()
        {
            var stubRepository = new Mock<IMedicineRepository>();

            Dictionary<int, Medicine> medicines = new Dictionary<int, Medicine>();
            medicines[1] = new Medicine(1, "Brufen", 10);
            medicines[2] = new Medicine(2, "Bromazepam", 20);

            stubRepository.Setup(m => m.GetAll()).Returns(medicines.Values);

            Medicine brufen = new Medicine(1, "Brufen", 3);

            MedicineService service = new MedicineService(stubRepository.Object);

            Assert.True(service.MedicineExistInQuantity(brufen.Name, brufen.Quantity));
        }

        [Fact]
        public void Medicine_not_exists_in_quantity()
        {
            var stubRepository = new Mock<IMedicineRepository>();

            Dictionary<int, Medicine> medicines = new Dictionary<int, Medicine>();
            medicines[1] = new Medicine(1, "Brufen", 10);
            medicines[2] = new Medicine(2, "Bromazepam", 20);

            stubRepository.Setup(m => m.GetAll()).Returns(medicines.Values);

            Medicine brufen = new Medicine(1, "Brufen", 100);

            MedicineService service = new MedicineService(stubRepository.Object);

            Assert.False(service.MedicineExistInQuantity(brufen.Name, brufen.Quantity));
        }
    }
}
