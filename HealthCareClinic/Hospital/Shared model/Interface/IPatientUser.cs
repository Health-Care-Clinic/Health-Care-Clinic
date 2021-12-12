using Hospital.Shared_model.Model;
using System;
using System.Collections.Generic;

namespace Hospital.Shared_model.Interface
{
    public interface IPatientUser : IUser
    {
        //public List<Allergen> Alergies { get; set; }
        //public AntiTroll TrollMechanism { get; set; }
        //public List<PatientNote> PatientNotes { get; set; }
        public String BloodType { get; set; }
        public String ParentName { get; set; }
        public DateTime DateOfRegistration { get; set; }
        public bool IsBlocked { get; set; }
        public bool IsActive { get; set; }
        public string EmploymentStatus { get; set; }
    }
}
