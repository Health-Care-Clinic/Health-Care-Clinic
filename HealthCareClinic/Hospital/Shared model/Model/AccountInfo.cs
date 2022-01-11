using System;
using System.Collections.Generic;
using System.Text;

namespace Hospital.Shared_model.Model
{
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
        }

        protected override IEnumerable<object> GetEqualityComponents()
        {
            yield return DateOfRegistration;
            yield return IsBlocked;
            yield return IsActive;
            yield return Username;
            yield return Password;
        }
    }
}
