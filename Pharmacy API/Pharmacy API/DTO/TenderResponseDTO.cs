using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Pharmacy_API.DTO
{
    public class TenderResponseDTO
    {
        public List<MedicineDTO> Medicines { get; set; }
        public Double TotalPrice { get; set; }
        public String TenderResponseDescription { get; set; }

        public TenderResponseDTO(List<MedicineDTO> medicines, double totalPrice, string tenderResponseDescription)
        {
            Medicines = medicines;
            TotalPrice = totalPrice;
            TenderResponseDescription = tenderResponseDescription;
        }

        public TenderResponseDTO()
        {
        }
    }
}
