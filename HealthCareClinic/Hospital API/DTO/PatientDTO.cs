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
        public String Name { get; set; }
        public String Surname { get; set; }
        public String BirthDate { get; set; }
        public String ParentName { get; set; }
        public String Address { get; set; }
        public String Phone { get; set; }
        public String EmploymentStatus { get; set; }
        public String BloodType { get; set; }
        public String Gender { get; set; }
        public String Email { get; set; }
        public String Username { get; set; }
        public String Password { get; set; }
        public DoctorDTO DoctorDTO { get; set; }
        public ICollection<Allergen> Alergies { get; set; }
        public String DateOfRegistration { get; set; }
        public bool IsBlocked { get; set; }
        public bool IsActive { get; set; }
    

        public PatientDTO() {}

        public PatientDTO(int id, String name, String surname, String birthDate, String parentName, String address, String phone, String employmentStatus, String bloodType, String gender, String email, String username, String password, DoctorDTO doctorDTO, ICollection<Allergen> alergies, String dateOfRegistration, bool isBlocked, bool isActive)
        {
            Id = id;
            Name = name;
            Surname = surname;
            BirthDate = birthDate;
            ParentName = parentName;
            Address = address;
            Phone = phone;
            EmploymentStatus = employmentStatus;
            BloodType = bloodType;
            Gender = gender;
            Email = email;
            Username = username;
            Password = password;
            DoctorDTO = doctorDTO;
            Alergies = alergies;
            DateOfRegistration = dateOfRegistration;
            IsBlocked = isBlocked;
            IsActive = isActive;
        }
    }
}
