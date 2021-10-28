using Enums;
using System;
using System.Collections.Generic;

namespace Model
{
    public class Doctor : Employee
    {
        public DateTime VacationTimeStart { get; set; }
        public WorkDayShift WorkShift { get; set; } 

        public Specialty Specialty { get; set; }

        public List<DateTime> DaysOff { get; set; } = new List<DateTime>();

        public Doctor(int id, string name, string surname, DateTime birthDate, string email, string password, string address,
            double salary, DateTime employmentDate, List<WorkDay> workDays, Specialty spec, int primaryRoom) : base(id, name, surname, birthDate, address, email, password, salary, employmentDate, workDays)
        {
            this.Specialty = spec;
            this.PrimaryRoom = primaryRoom;
        }

        public int PrimaryRoom { get; set; }


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

        public System.Collections.ArrayList patient;


        public System.Collections.ArrayList Patient
        {
            get
            {
                if (patient == null)
                    patient = new System.Collections.ArrayList();
                return patient;
            }
            set
            {
                RemoveAllPatient();
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
            if (this.patient == null)
                this.patient = new System.Collections.ArrayList();
            if (!this.patient.Contains(newPatient))
            {
                this.patient.Add(newPatient);
                newPatient.Doctor = this;
            }
        }


        public void RemovePatient(Patient oldPatient)
        {
            if (oldPatient == null)
                return;
            if (this.patient != null)
                if (this.patient.Contains(oldPatient))
                {
                    this.patient.Remove(oldPatient);
                    oldPatient.Doctor = null;
                }
        }

        public void RemoveAllPatient()
        {
            if (patient != null)
            {
                System.Collections.ArrayList tmpPatient = new System.Collections.ArrayList();
                foreach (Patient oldPatient in patient)
                    tmpPatient.Add(oldPatient);
                patient.Clear();
                foreach (Patient oldPatient in tmpPatient)
                    oldPatient.Doctor = null;
                tmpPatient.Clear();
            }
        }

    }
}