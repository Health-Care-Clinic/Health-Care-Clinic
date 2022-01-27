using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using System.Text.RegularExpressions;

namespace Hospital.Shared_model.Model
{
    [Owned]
    public class AccountInfo : ValueObject
    {
        public DateTime DateOfRegistration { get; private set; }
        public bool IsBlocked { get; private set; }
        public bool IsActive { get; private set; }
        public string Username { get; private set; }
        public string Password { get; private set; }

        public AccountInfo() { }

        public AccountInfo(DateTime dateOfRegistration, bool isBlocked, bool isActive, string username, string password)
        {
            DateOfRegistration = dateOfRegistration;
            IsBlocked = isBlocked;
            IsActive = isActive;
            Username = username;
            Password = password;

            Validate();
        }

        public AccountInfo(string username, string password)
        {
            DateOfRegistration = DateTime.Now;
            IsBlocked = false;
            IsActive = true;
            Username = username;
            Password = password;

            Validate();
        }

        protected override IEnumerable<object> GetEqualityComponents()
        {
            yield return DateOfRegistration;
            yield return IsBlocked;
            yield return IsActive;
            yield return Username;
            yield return Password;
        }

        protected override void Validate()
        {
            CheckIfDateOfRegistrationIsInThePast();
            CheckIfUsernameMatchesPresetPattern();
            CheckIfPasswordMatchesPresetPattern();
        }

        private void CheckIfDateOfRegistrationIsInThePast()
        {
            if (DateTime.Compare(DateOfRegistration, DateTime.Now) <= 0)
                return;
            else
                throw new ArgumentException("Date of registration cannot be in the future.");
        }

        private void CheckIfUsernameMatchesPresetPattern()
        {
            if (Regex.IsMatch(Username, @"^[a-zA-Z][-_a-zA-Z0-9\.]+$"))
                return;
            else
                throw new ArgumentException("Username must begin with letter of English alphabet. Username must contain " +
                    "only English alphabet letters, '-', '_', ciphers and '.'");
        }

        private void CheckIfPasswordMatchesPresetPattern()
        {
            if (Password.Length >= 4 && Password.Length <= 15)
                return;
            else
                throw new ArgumentException("Password must contain at least 7 and at most 15 characters.");
        }
    }
}
