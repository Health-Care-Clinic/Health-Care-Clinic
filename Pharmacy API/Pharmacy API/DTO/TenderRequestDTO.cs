using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Pharmacy_API.DTO
{
    public class TenderRequestDTO
    {
       

        public List<MedicineDTO> MedicineDTOs
        {
            get; set;
        }

        public TenderRequestDTO(List<MedicineDTO> medicineDTOs)
        {
            MedicineDTOs = medicineDTOs;
        }
    }
}
