using System;
using System.Collections.Generic;
using System.Text;

namespace Hospital.Shared_model.Model
{
    public class PersonalInfo : ValueObject
    {
        public string Name { get; private set; }
        public string Surname { get; private set; }
        public DateTime BirthDate { get; private set; }
        public string Phone { get; private set; }
        public string Email { get; private set; }
        public string Gender { get; private set; }
        public string Address { get; private set; }
        public string ParentName { get; private set; }
        public string EmploymentStatus { get; private set; }

        public PersonalInfo() { }

        public PersonalInfo(string name, string surname, DateTime birthDate, string phone, string email,
            string gender, string address, string parentName, string employmentStatus)
        {
            Name = name;
            Surname = surname;
            BirthDate = birthDate;
            Phone = phone;
            Email = email;
            Gender = gender;
            Address = address;
            ParentName = parentName;
            EmploymentStatus = employmentStatus;
        }

        protected override IEnumerable<object> GetEqualityComponents()
        {
            yield return Name;
            yield return Surname;
            yield return BirthDate;
            yield return Phone;
            yield return Email;
            yield return Gender;
            yield return Address;
            yield return ParentName;
            yield return EmploymentStatus;
        }
    }
}
