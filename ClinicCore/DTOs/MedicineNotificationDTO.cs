using Model;
using System.Collections.Generic;

namespace ClinicCore.DTOs
{
    public class MedicineNotificationDTO
    {
        public string Name { get; set; }
        public string SideEffect { get; set; }
        public string Usage { get; set; }
        public List<ReplaceMedicineName> MedicineNames { get; set; }
        public List<MedicineComponent> MedicineComponents { get; set; }
        public List<int> RecieverIds { get; set; }

        public MedicineNotificationDTO(string name, string sideEffect, string usage, List<ReplaceMedicineName> medicineNames, List<MedicineComponent> medicineComponents, List<int> recieverIds)
        {
            Name = name;
            SideEffect = sideEffect;
            Usage = usage;
            MedicineNames = medicineNames;
            MedicineComponents = medicineComponents;
            RecieverIds = recieverIds;
        }
    }
}
