using ClinicCore.Model;
using ClinicCore.Model.Interface;
using Enums;
using System;
using System.Collections.Generic;

namespace Model
{
    public class Patient : Entity, IPatientUser
    {
        public DateTime FileDate { get; set; }
        public string Employer { get; set; }
        public bool Admitted { get; set; }
        public List<string> Alergies { get; set; }
        public AntiTroll TrollMechanism { get; set; } = new AntiTroll();
        public List<PatientNote> PatientNotes { get; set; } = new List<PatientNote>();
        public string BloodType { get; set; }
        public bool IsGuest { get; set; } = false;
        public EducationCategory Education { get; set; }
      
        public string Name { get; set; }
        public string Surname { get; set; }
        public DateTime BirthDate { get; set; }
        public string Phone { get; set; }
        public string Email { get; set; }
        public string Gender { get; set; }
        public string Relationship { get; set; }
        public string Password { get; set; }
        public string Address { get; set; }

        public Patient(int id, string name, string surname, DateTime birthDate, string address, string email, string password, DateTime filedate, String employer, List<String> alergies, Boolean isGuest, Boolean isAdmitted)
        {
            this.Id = id;
            this.Name = name;
            this.Surname = surname;
            this.BirthDate = birthDate;
            this.Address = address;
            this.Email = email;
            this.Password = password;
            this.FileDate = filedate;
            this.Employer = employer;
            this.Alergies = alergies;
            this.IsGuest = isGuest;
            this.Admitted = isAdmitted;
        }

        public Patient(int id, string name, string surname, string gender, DateTime birthDate, string address, string phone, string email, string relationship, EducationCategory education, string password, String employer, List<String> alergies, Boolean isGuest)
        {
            this.Id = id;
            this.Name = name;
            this.Surname = surname;
            this.Gender = gender;
            this.BirthDate = birthDate;
            this.Address = address;
            this.Email = email;
            this.Password = password;
            this.Phone = phone;
            this.Employer = employer;
            this.Alergies = alergies;
            this.IsGuest = isGuest;
            this.Relationship = relationship;
            this.Education = education;
        }

        public Patient()
        {
        }

        public Doctor Doc { get; set; }

        public Doctor Doctor
        {
            get
            {
                return Doc;
            }
            set
            {
                if (this.Doc == null || !this.Doc.Equals(value))
                {
                    if (this.Doc != null)
                    {
                        Doctor oldDoctor = this.Doc;
                        this.Doc = null;
                        oldDoctor.RemovePatient(this);
                    }
                    if (value != null)
                    {
                        this.Doc = value;
                        this.Doc.AddPatient(this);
                    }
                }
            }
        }
    }
}
