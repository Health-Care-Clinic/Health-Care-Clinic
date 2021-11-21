using Hospital.Shared_model.Model;
using System;
using System.Collections.Generic;

namespace Hospital.Shared_model.Interface
{
    public interface IPatientUser : IUser
    {
        public DateTime FileDate { get; set; }
        public String Employer { get; set; }
        public Boolean Admitted { get; set; }
        //public List<Allergen> Alergies { get; set; }
        //public AntiTroll TrollMechanism { get; set; }
        //public List<PatientNote> PatientNotes { get; set; }
        public String BloodType { get; set; }
        public Boolean IsGuest { get; set; }
    }
}
