using Hospital.Shared_model.Model;
using System;
using System.Collections.Generic;
using System.Text;

namespace Hospital.Medical_records.Model
{
    public class MedicalRecord
    {
        public int Id { get; private set; }
        public virtual ICollection<AllergenForPatient> Allergens { get; private set; }
        public string BloodType { get; private set; }

        private MedicalRecord() { }
    }
}
