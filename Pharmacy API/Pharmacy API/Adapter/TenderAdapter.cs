using Pharmacy.Model;
using Pharmacy_API.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Pharmacy.Prescriptions.Model;
using Pharmacy.Tendering.Model;

namespace Pharmacy_API.Adapter
{
    public class TenderAdapter
    {
        public static Tender TenderRequestDTOToTender(TenderRequestDTO dto)
        {
            Tender tender = new Tender();
            tender.Medicines = MedicineDTOsListToMedicineList(dto.MedicineDTOs);
            
            return tender;
        }

        private static List<Medicine> MedicineDTOsListToMedicineList(List<MedicineDTO> medicineDTOs)
        {
         
            List<Medicine> medicines = new List<Medicine>();
            foreach(MedicineDTO dto in medicineDTOs)
            {
                medicines.Add(MedicineAdapter.MedicineDTOToMedicine(dto));
            }

            return medicines;
        }


        private static List<MedicineDTO> MedicinesToMedicineDTOs(List<Medicine> medicines)
        {

            List<MedicineDTO> medicineDTOs = new List<MedicineDTO>();
            foreach (Medicine med in medicines)
            {
                medicineDTOs.Add(MedicineAdapter.MedicineToMedicineDto(med));
            }

            return medicineDTOs;
        }

        public static TenderResponseDTO TenderToTenderResponse(Tender tender)
        {
            TenderResponseDTO tenderResponseDTO = new TenderResponseDTO();
            tenderResponseDTO.TenderResponseDescription = tender.TenderResponseDescription;
            tenderResponseDTO.TotalPrice = tender.TotalPrice;
            tenderResponseDTO.Medicines = MedicinesToMedicineDTOs(tender.Medicines);
            
            return tenderResponseDTO;
        }
    }
}
