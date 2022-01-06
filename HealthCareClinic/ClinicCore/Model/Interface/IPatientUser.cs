using Model;
using System;
using System.Collections.Generic;

namespace ClinicCore.Model.Interface
{
    public interface IPatientUser : IUser
    {
        public DateTime FileDate { get; set; }
        public String Employer { get; set; }
        public Boolean Admitted { get; set; }
        public List<String> Alergies { get; set; }
        public AntiTroll TrollMechanism { get; set; }
        public List<PatientNote> PatientNotes { get; set; }
        public String BloodType { get; set; }
        public Boolean IsGuest { get; set; }
    }
}
