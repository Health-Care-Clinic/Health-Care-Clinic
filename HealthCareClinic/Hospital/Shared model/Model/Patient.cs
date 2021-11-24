using Hospital.Shared_model.Interface;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Hospital.Shared_model.Model
{
    public class Patient : IPatientUser
    {
        [Key]
        public int Id { get; set; }
        public string ParentName { get; set; }
        public DateTime DateOfRegistration { get; set; }
        public bool IsBlocked { get; set; }
        public bool IsActive { get; set; }

        public virtual ICollection<AllergenForPatient> Allergens { get; set; }
        public string BloodType { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public DateTime BirthDate { get; set; }
        public string Phone { get; set; }
        public string Email { get; set; }
        public string Gender { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
        public string Address { get; set; }
        public string EmploymentStatus { get; set; }
        //[ForeignKey("TrollMechanism")]
        //public AntiTroll TrollMechanismId { get; set; }
        //public virtual AntiTroll TrollMechanism { get; set; } = new AntiTroll();
        //public ICollection<PatientNote> PatientNotes { get; set; } = new List<PatientNote>();

        public Patient()
        { }

        public Patient(int id, string name, string surname, string gender, string bloodType, DateTime birthDate, string address, string phone, string email, string username, string password, String ParentName, List<AllergenForPatient> alergies, string employmentStatus,bool isActive)
        {
            this.Id = id;
            this.Name = name;
            this.Surname = surname;
            this.ParentName = ParentName;
            this.BloodType = bloodType;
            this.Gender = gender;
            this.BirthDate = birthDate;
            this.Address = address;
            this.Phone = phone;
            this.Email = email;
            this.Username = username;
            this.Password = password;
            this.Allergens = alergies;
            this.EmploymentStatus = employmentStatus;
            this.IsActive = isActive;
            this.IsBlocked = false;
        }
        public Patient(int id, string name, string surname, string gender, string bloodType, DateTime birthDate, string address, string phone, string email, string username, string password, String ParentName, List<AllergenForPatient> alergies, string employmentStatus,Doctor doctor)
        {
            this.Id = id;
            this.Name = name;
            this.Surname = surname;
            this.ParentName = ParentName;
            this.BloodType = bloodType;
            this.Gender = gender;
            this.BirthDate = birthDate;
            this.Address = address;
            this.Phone = phone;
            this.Email = email;
            this.Username = username;
            this.Password = password;
            this.Allergens = alergies;
            this.EmploymentStatus = employmentStatus;
            this.IsActive = false;
            this.IsBlocked = false;
            this.DoctorId = doctor.Id;
            this.Doctor = doctor;
        }

        [ForeignKey("Doctor")]
        public int DoctorId { get; set; }

        private Doctor doctor;

        public virtual Doctor Doctor
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
