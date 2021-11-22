using Hospital.Shared_model.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Hospital_API.DTO
{
    public class PatientDTO
    {
        public int Id { get; set; }
        public string ParentName { get; set; }
        public string DateOfRegistration { get; set; }
        public bool IsBlocked { get; set; }
        public bool IsActive { get; set; }
        public ICollection<Allergen> Alergies { get; set; }
        public string BloodType { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public string BirthDate { get; set; }
        public string Phone { get; set; }
        public string Email { get; set; }
        public string Gender { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
        public string Address { get; set; }
        public string EmploymentStatus { get; set; }

        public DoctorDTO DoctorDTO { get; set; }

        public PatientDTO() {}

        public PatientDTO(int id, string parentName, string dateOfRegistration, bool isBlocked, bool isActive, ICollection<Allergen> alergies, string bloodType,
                            string name, string surname, string birthDate, string phone, string email, string gender, string username, string password,
                             string address, string employmentStatus, DoctorDTO doctorDTO)
        {
            Id = id;
            ParentName = parentName;
            DateOfRegistration = dateOfRegistration;
            IsBlocked = isBlocked;
            IsActive = isActive;
            Alergies = alergies;
            BloodType = bloodType;
            Name = name;
            Surname = surname;
            BirthDate = birthDate;
            Phone = phone;
            Email = email;
            Gender = gender;
            Username = username;
            Password = password;
            Address = address;
            EmploymentStatus = employmentStatus;
            DoctorDTO = doctorDTO;
        }
    }
}
