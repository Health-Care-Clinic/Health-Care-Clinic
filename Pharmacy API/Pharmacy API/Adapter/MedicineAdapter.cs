using Pharmacy.Model;
using Pharmacy_API.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Pharmacy_API.Adapter
{
    public class MedicineAdapter
    {
        public static Medicine MedicineDTOToMedicine(MedicineDTO dto)
        {
            Medicine medicine = new Medicine();
            medicine.Manufacturer = dto.Manufacturer;
            medicine.Name = dto.Name;
            medicine.Quantity = dto.Quantity;
            medicine.Reactions = dto.Reactions;
            medicine.SideEffects = dto.SideEffects;
            medicine.Usage = dto.Usage;
            medicine.Weight = dto.Weight;
            medicine.Price = dto.Price;

            return medicine;
        }

        public static MedicineDTO MedicineToMedicineDto(Medicine medicine)
        {
            MedicineDTO medicineDTO = new MedicineDTO();
            medicineDTO.Manufacturer = medicine.Manufacturer;
            medicineDTO.Name = medicine.Name;
            medicineDTO.Quantity = medicine.Quantity;
            medicineDTO.Reactions = medicine.Reactions;
            medicineDTO.SideEffects = medicine.SideEffects;
            medicineDTO.Usage = medicine.Usage;
            medicineDTO.Weight = medicine.Weight;
            medicineDTO.Price = medicine.Price;

            return medicineDTO;
        }
    }
}
