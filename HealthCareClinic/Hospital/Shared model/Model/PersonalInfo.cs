using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;

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

        protected override void Validate()
        {
            CheckIfSomeSortOfNameMatchesPresetPattern(Name);
            CheckIfSomeSortOfNameMatchesPresetPattern(Surname);
            CheckIfBirthDateIsInThePast();
            CheckIfPhoneMatchesPresetPattern();
            CheckIfEmailMatchesPresetPattern();
            CheckIfGenderIsMaleOrFemale();
            CheckIfAddressIsNotAnEmptyString();
            CheckIfSomeSortOfNameMatchesPresetPattern(ParentName);
            CheckIfEmploymentStatusIsNotAnEmptyString();
        }

        private void CheckIfSomeSortOfNameMatchesPresetPattern(string someSortOfName)
        {
            if (Regex.IsMatch(someSortOfName, @"^[A-Z\p{L}][a-z\p{L}]+([ -][A-Z\p{L}][a-z\p{L}]+)*$"))
                return;
            else
                throw new ArgumentException("Name, surname and parent's name must contain only letters, '-' and ' '.");
        }

        private void CheckIfBirthDateIsInThePast()
        {
            if (DateTime.Compare(BirthDate, DateTime.Now) <= 0)
                return;
            else
                throw new ArgumentException("Birth date cannot be in the future.");
        }

        private void CheckIfPhoneMatchesPresetPattern()
        {
            if (Regex.IsMatch(Phone, @"^06[0-9]{7,8}$"))
                return;
            else
                throw new ArgumentException("Phone must start with '06'. Phone must contain at least 9 and at most 10 ciphers.");
        }

        private void CheckIfEmailMatchesPresetPattern()
        {
            if (Regex.IsMatch(Email, @"^[a-z][-_a-z0-9\+\.]+@[a-z][-_a-z0-9\+]+\.[-_a-z0-9\+\.]+$"))
                return;
            else
                throw new ArgumentException("Email must not contain letters outside of English aphabet. Email must start with " +
                    "small letter and characters before '@' can be a small letter, cipher, '+', '-', '.' or '_'. Domain part " +
                    "(part after '@') must start with small letter, while following characters can be any from sequence in " +
                    "previous sentence.");
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

        private void CheckIfAddressIsNotAnEmptyString()
        {
            if (!Address.Equals(""))
                return;
            else
                throw new ArgumentException("Address cannot be an empty string.");
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
