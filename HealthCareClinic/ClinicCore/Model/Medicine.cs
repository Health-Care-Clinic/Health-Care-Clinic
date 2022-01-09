using System;
using System.Collections.Generic;

namespace Model
{
    public class Medicine
    {
        public String Name { get; set; }
        public List<MedicineComponent> Composition { get; set; }
        public String SideEffects { get; set; }
        public String Usage { get; set; }
        public List<ReplaceMedicineName> ReplaceMedicine { get; set; }

        public Medicine(string name, List<MedicineComponent> composition, string sideEffects, string usage, List<ReplaceMedicineName> replaceMedicine)
        {
            Name = name;
            Composition = composition;
            SideEffects = sideEffects;
            Usage = usage;
            ReplaceMedicine = replaceMedicine;
        }
    }
}
