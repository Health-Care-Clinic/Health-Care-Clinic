using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;

namespace Hospital.Shared_model.Model
{
    [Owned]
    public class PersonalInfo : ValueObject
    {
        public string Name { get; private set; }
        public string Surname { get; private set; }
        public DateTime BirthDate { get; private set; }
        public string Gender { get; private set; }
        public string ParentName { get; private set; }
        public string EmploymentStatus { get; private set; }

        public PersonalInfo() { }

        public PersonalInfo(string name, string surname, DateTime birthDate, string gender, string parentName, 
            string employmentStatus)
        {
            Name = name;
            Surname = surname;
            BirthDate = birthDate;
            Gender = gender;
            ParentName = parentName;
            EmploymentStatus = employmentStatus;

            Validate();
        }

        protected override IEnumerable<object> GetEqualityComponents()
        {
            yield return Name;
            yield return Surname;
            yield return BirthDate;
            yield return Gender;
            yield return ParentName;
            yield return EmploymentStatus;
        }

        protected override void Validate()
        {
            CheckIfSomeSortOfNameMatchesPresetPattern(Name);
            CheckIfSomeSortOfNameMatchesPresetPattern(Surname);
            CheckIfBirthDateIsInThePast();
            CheckIfGenderIsMaleOrFemale();
            CheckIfSomeSortOfNameMatchesPresetPattern(ParentName);
            CheckIfEmploymentStatusIsNotAnEmptyString();
        }

        private void CheckIfSomeSortOfNameMatchesPresetPattern(string someSortOfName)
        {
            if (Regex.IsMatch(someSortOfName, @"^[A-Z\p{L}][a-z\p{L}]+([ -][A-Z\p{L}][a-z\p{L}]+)*$"))
                return;
            else
                throw new ArgumentException("Name, surname and parent's name must start with capital letter and contain " +
                    "only letters, '-' and ' '.");
        }

        private void CheckIfBirthDateIsInThePast()
        {
            if (DateTime.Compare(BirthDate, DateTime.Now) <= 0)
                return;
            else
                throw new ArgumentException("Birth date cannot be in the future.");
        }

        private void CheckIfGenderIsMaleOrFemale()
        {
            StringBuilder stringBuilder = new StringBuilder();
            stringBuilder.Append(Gender.ElementAt(0).ToString().ToLower());
            stringBuilder.Append(Gender.Substring(1, Gender.Length - 1));

            string genderWithLoweredFirstChar = stringBuilder.ToString();
            if (genderWithLoweredFirstChar.Equals("male") || genderWithLoweredFirstChar.Equals("female"))
                return;
            else
                throw new ArgumentException("Gender must be either 'Male' or 'Female'.");
        }

        private void CheckIfEmploymentStatusIsNotAnEmptyString()
        {
            if (!EmploymentStatus.Equals(""))
                return;
            else
                throw new ArgumentException("Employment status cannot be an empty string.");
        }
    }
}
