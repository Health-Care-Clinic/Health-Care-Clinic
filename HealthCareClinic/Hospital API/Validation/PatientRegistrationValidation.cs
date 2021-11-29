using Hospital_API.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Hospital_API.Validation
{
    public class PatientRegistrationValidation
    {
        public PatientRegistrationValidation() { }

        public static bool IsIncomingPatientDtoValid(PatientDTO patientDTO)
        {
            bool incomingPatientDtoValidity = true;

            if (!IsNameValid(patientDTO.Name))
            {
                incomingPatientDtoValidity = false;
            }

            if (!IsBirthDateValid(patientDTO.BirthDate))
            {
                incomingPatientDtoValidity = false;
            }

            if (!IsPhoneValid(patientDTO.Phone))
            {
                incomingPatientDtoValidity = false;
            }

            if (!IsBloodTypeValid(patientDTO.BloodType))
            {
                incomingPatientDtoValidity = false;
            }

            if (!IsGenderValid(patientDTO.Gender))
            {
                incomingPatientDtoValidity = false;
            }

            if (!IsEmailValid(patientDTO.Email))
            {
                incomingPatientDtoValidity = false;
            }

            if (!IsUsernameValid(patientDTO.Username))
            {
                incomingPatientDtoValidity = false;
            }

            if (!IsPasswordValid(patientDTO.Password))
            {
                incomingPatientDtoValidity = false;
            }

            return incomingPatientDtoValidity;
        }

        private static bool IsNameValid(string name)
        {
            bool nameValidity = true;

            if (!Regex.IsMatch(name, @"^[A-Z\p{L}][a-z\p{L}]+([ -][A-Z\p{L}][a-z\p{L}]+)*$"))
            {
                nameValidity = false;
            }

            return nameValidity;
        }

        private static bool IsBirthDateValid(string birthDate)
        {
            bool birthDateValidity = true;

            if (DateTime.Compare(ConvertToDate(birthDate), DateTime.Now) >= 0)
            {
                birthDateValidity = false;
            }

            return birthDateValidity;
        }

        private static bool IsPhoneValid(string phone)
        {
            bool phoneValidity = true;

            if (!Regex.IsMatch(phone, @"^06[0-9]{7,8}$"))
            {
                phoneValidity = false;
            }

            return phoneValidity;
        }

        private static bool IsBloodTypeValid(string bloodType)
        {
            bool bloodTypeValidity = false;

            if (Regex.IsMatch(bloodType, @"^A[-\+]?$") || Regex.IsMatch(bloodType, @"^B[-\+]?$")
                || Regex.IsMatch(bloodType, @"^AB[-\+]?$") || Regex.IsMatch(bloodType, @"^0[-\+]?$"))
            {
                bloodTypeValidity = true;
            }

            return bloodTypeValidity;
        }

        private static bool IsGenderValid(string gender)
        {
            bool bloodTypeValidity = false;

            StringBuilder stringBuilder = new StringBuilder();
            stringBuilder.Append(gender.ElementAt(0).ToString().ToLower());
            stringBuilder.Append(gender.Substring(1, gender.Length - 1));

            string genderWithLoweredFirstChar = stringBuilder.ToString();
            if (genderWithLoweredFirstChar.Equals("male") || !genderWithLoweredFirstChar.Equals("female"))
            {
                bloodTypeValidity = true;
            }

            return bloodTypeValidity;
        }

        private static bool IsEmailValid(string email)
        {
            bool emailValidity = true;

            if (!Regex.IsMatch(email, @"^[a-z][-_a-z0-9\+\.]+@[a-z][-_a-z0-9\+]+\.[-_a-z0-9\+\.]+$"))
            {
                emailValidity = false;
            }

            return emailValidity;
        }

        private static bool IsUsernameValid(string username)
        {
            bool usernameValidity = true;

            if (!Regex.IsMatch(username, @"^[a-zA-Z][-_a-zA-Z0-9\.]+$"))
            {
                usernameValidity = false;
            }

            return usernameValidity;
        }

        private static bool IsPasswordValid(string password)
        {
            bool passwordValidity = true;

            if (password.Length <= 6 || password.Length >= 16)
            {
                passwordValidity = false;
            }

            return passwordValidity;
        }

        private static DateTime ConvertToDate(String dateAsString)
        {
            String[] mainParts = dateAsString.Split('T');

            String[] dateParts = mainParts[0].Split('-');
            int year = int.Parse(dateParts[0]);
            int month = int.Parse(dateParts[1]);
            int day = int.Parse(dateParts[2]);

            String[] timeParts = mainParts[1].Split(':');
            int hour = int.Parse(timeParts[0]);
            int minute = int.Parse(timeParts[1]);
            int second = int.Parse(timeParts[2].Substring(0, 2));

            DateTime date = new DateTime(year, month, day, hour, minute, second);

            return date;
        }
    }
}
