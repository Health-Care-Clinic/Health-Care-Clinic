using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;

namespace Hospital.Shared_model.Model
{
    public class Doctor : Employee
    {
        public int WorkShiftId { get; set; }     //bolnica radi od 7h do 19h - prva smena je od 7h-13h, a druga od 13h-19h
        public String Specialty { get; set; }  
        public virtual ICollection<Day> DaysOff { get; set; } = new List<Day>();
        //public virtual ICollection<DateTime> DaysOff { get; set; } = new List<DateTime>();      //ovo nam ne treba trenutno
        public int PrimaryRoom { get; set; }
        public Doctor()
        { }

        public Doctor(int id, string name, string surname, string gender, DateTime birthDate, double salary, string address, string phone,
            string email, string username, string password, DateTime employmentDate, ICollection<WorkDay> workDay, string spec, int primaryRoom) : base(id, name, surname, gender, birthDate, salary, address, phone,
            email, username, password, employmentDate,  workDay)
        {
            //this.SpecialtyId = spec.SpecialtyId;
            this.Specialty = spec;
            this.PrimaryRoom = primaryRoom;
            this.WorkShiftId = -1;
        }

        private ICollection<Patient> patients;

        public virtual ICollection<Patient> Patients
        {
            get
            {
                if (patients == null)
                    patients = new List<Patient>();
                return patients;
            }
            set
            {
                RemoveAllPatients();
                if (value != null)
                {
                    foreach (Patient oPatient in value)
                        AddPatient(oPatient);
                }
            }
        }


        public void AddPatient(Patient newPatient)
        {
            if (newPatient == null)
                return;
            if (this.patients == null)
                this.patients = new List<Patient>();
            if (!this.patients.Contains(newPatient))
            {
                this.patients.Add(newPatient);
                newPatient.Doctor = this;
            }
        }


        public void RemovePatient(Patient oldPatient)
        {
            if (oldPatient == null)
                return;
            if (this.patients != null)
                if (this.patients.Contains(oldPatient))
                {
                    this.patients.Remove(oldPatient);
                    oldPatient.Doctor = null;
                }
        }

        public void RemoveAllPatients()
        {
            if (patients != null)
            {
                List<Patient> tmpPatient = new List<Patient>();
                foreach (Patient oldPatient in patients)
                    tmpPatient.Add(oldPatient);
                patients.Clear();
                foreach (Patient oldPatient in tmpPatient)
                    oldPatient.Doctor = null;
                tmpPatient.Clear();
            }
        }
        public List<Patient> GetActivePatients()
        {
            return this.Patients.Where(p => p.AccountInfo.IsActive == true).ToList();
        }
        public void ViewPatientDocuments(Patient patient)
        {
            throw new NotImplementedException();
        }

        public Boolean UpadatePatient(Patient patient)
        {
            throw new NotImplementedException();
        }

        public Boolean AddPatietientDocument(Patient patient)
        {
            throw new NotImplementedException();
        }
    }
}
