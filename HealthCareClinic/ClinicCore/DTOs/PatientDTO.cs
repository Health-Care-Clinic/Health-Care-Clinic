using Enums;
using System;
using System.Collections.Generic;

namespace ClinicCore.DTOs
{
    public class PatientDTO
    {
        #region Feilds
        public EducationCategory Education { get; set; }
        public int Id { get; set; }
        public String Name { get; set; }
        public String Surname { get; set; }
        public DateTime BirthDate { get; set; }
        public String Phone { get; set; }
        public String Email { get; set; }
        public String Gender { get; set; }
        public String Relationship { get; set; }
        public String Password { get; set; }
        public String Address { get; set; }
        public String Employer { get; set; }
        public List<String> Alergies { get; set; }
        public DateTime FileDate { get; set; }
        public Boolean IsGuest { get; set; }
        public Boolean IsAdmitted { get; set; }
        public String BloodType { get; set; }

        #endregion
        public PatientDTO(int id, string name, string surname, string gender, DateTime birthDate, string phone, string email, 
            EducationCategory education, string relationship, string employer, string password, string address, List<string> alergies, 
            Boolean isGuest, Boolean isAdmitted)
        {
            Id = id;
            Name = name;
            Surname = surname;
            Gender = gender;
            BirthDate = birthDate;
            Phone = phone;
            Email = email;
            Education = education;
            Relationship = relationship;
            Employer = employer;
            Password = password;
            Address = address;
            Alergies = alergies;
            IsGuest = isGuest;
            IsAdmitted = isAdmitted;
        }

        public PatientDTO()
        { 
        }
       
    }
}
