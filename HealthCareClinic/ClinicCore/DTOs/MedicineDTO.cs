using ClinicCore.DTOs;
using System.Collections.Generic;

namespace DTOs
{
    public class MedicineDTO
    {
        public List<MedicineComponentDTO> Composition { get; set; }
        public string SideEffects { get; set; }
        public string Usage { get; set; }
        public List<ReplaceMedicineNameDTO> ReplaceMedicine { get; set; }

        public string Name { get; set; }

        public bool Check { get; set; }

        public bool Allergic { get; set; }

        public MedicineDTO(List<MedicineComponentDTO> composition, string sideEffects, string usage, List<ReplaceMedicineNameDTO> replaceMedicine, string name, bool check, bool allergic)
        {
            Composition = composition;
            SideEffects = sideEffects;
            Usage = usage;
            ReplaceMedicine = replaceMedicine;
            Name = name;
            Check = check;
            Allergic = allergic;
        }
    }
}
