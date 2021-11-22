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
        public string FileDate { get; set; }
        public string Employer { get; set; }
        public bool Admitted { get; set; }
        public ICollection<Allergen> Alergies { get; set; }
        public string BloodType { get; set; }
        public bool IsGuest { get; set; } = false;
        public EducationCategory Education { get; set; }

        public string Name { get; set; }
        public string Surname { get; set; }
        public string BirthDate { get; set; }
        public string Phone { get; set; }
        public string Email { get; set; }
        public string Gender { get; set; }
        public string Relationship { get; set; }
        public string Password { get; set; }
        public string Address { get; set; }
        
        public DoctorDTO DoctorDTO { get; set; }

        public PatientDTO() {}

        public PatientDTO(int id, string name, string surname, string birthDate, string address, string email, 
            string password, string filedate, String employer, List<Allergen> alergies, Boolean isGuest, 
            Boolean isAdmitted)
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

        public PatientDTO(int id, string name, string surname, string gender, string birthDate, string address, 
            string phone, string email, string relationship, EducationCategory education, string password, 
            String employer, List<Allergen> alergies, Boolean isGuest)
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
    }
}
