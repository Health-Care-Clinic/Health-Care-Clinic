using Hospital.Shared_model.Interface;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Hospital.Shared_model.Model
{
    public class Patient : IPatientUser
    {
        public int Id { get; set; }
        public DateTime FileDate { get; set; }
        public string Employer { get; set; }
        public bool Admitted { get; set; }
        // Promenjeno iz List<string> u List<Allergen>.
        public ICollection<Allergen> Alergies { get; set; }
        //public AntiTroll TrollMechanism { get; set; } = new AntiTroll();
        //public ICollection<PatientNote> PatientNotes { get; set; } = new List<PatientNote>();
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

        public Patient()
        { }

        public Patient(int id, string name, string surname, DateTime birthDate, string address, string email, string password, DateTime filedate, String employer, List<Allergen> alergies, Boolean isGuest, Boolean isAdmitted)
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

        public Patient(int id, string name, string surname, string gender, DateTime birthDate, string address, string phone, string email, string relationship, EducationCategory education, string password, String employer, List<Allergen> alergies, Boolean isGuest)
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
        [ForeignKey("Doctor")]
        public int DoctorId;

        private Doctor doctor;

        public Doctor Doctor
        {
            get
            {
                return doctor;
            }
            set
            {
                if (this.doctor == null || !this.doctor.Equals(value))
                {
                    if (this.doctor != null)
                    {
                        Doctor oldDoctor = this.doctor;
                        this.doctor = null;
                        oldDoctor.RemovePatient(this);
                    }
                    if (value != null)
                    {
                        this.doctor = value;
                        this.doctor.AddPatient(this);
                    }
                }
            }
        }
    }
}
