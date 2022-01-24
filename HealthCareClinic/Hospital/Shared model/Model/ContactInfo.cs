using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using System.Text.RegularExpressions;

namespace Hospital.Shared_model.Model
{
    [Owned]
    public class ContactInfo : ValueObject
    {
        public string Phone { get; private set; }
        public string Email { get; private set; }
        public string Address { get; private set; }

        public ContactInfo() { }

        public ContactInfo(string phone, string email, string address)
        {
            Phone = phone;
            Email = email;
            Address = address;
        }

        protected override IEnumerable<object> GetEqualityComponents()
        {
            yield return Phone;
            yield return Email;
            yield return Address;
        }

        protected override void Validate()
        {
            CheckIfPhoneMatchesPresetPattern();
            CheckIfEmailMatchesPresetPattern();
            CheckIfAddressIsNotAnEmptyString();
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

        private void CheckIfAddressIsNotAnEmptyString()
        {
            if (!Address.Equals(""))
                return;
            else
                throw new ArgumentException("Address cannot be an empty string.");
        }
    }
}
