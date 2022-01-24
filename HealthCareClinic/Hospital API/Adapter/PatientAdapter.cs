using Hospital.Medical_records.Model;
using Hospital.Shared_model.Model;
using Hospital_API.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Hospital_API.Adapter
{
    public class PatientAdapter
    {
        public static Patient PatientDTOToPatient(PatientDTO dto)
        {
            PersonalInfo personalInfo = new PersonalInfo(dto.Name, dto.Surname, ConvertToDate(dto.BirthDate), dto.Gender, 
                dto.ParentName, dto.EmploymentStatus);
            ContactInfo contactInfo = new ContactInfo(dto.Phone, dto.Email, dto.Address);
            MedicalRecord medicalRecord = new MedicalRecord(dto.Id, 
                AllergenAdapter.AllergenDTOListToAllergenForPatientList(dto.Allergens, dto.Id), dto.BloodType, personalInfo);

            AccountInfo accountInfo = new AccountInfo(ConvertToDate(dto.DateOfRegistration), dto.IsBlocked, dto.IsActive, 
                dto.Username, dto.Password);

            Patient patient = new Patient(dto.Id, medicalRecord, contactInfo, accountInfo);

            return patient;
        }

        public static PatientDTO PatientToPatientDTO(Patient patient)
        {
            PatientDTO dto = new PatientDTO();

            dto.Id = patient.Id;
            dto.EmploymentStatus = patient.MedicalRecord.PersonalInfo.EmploymentStatus;
            dto.Name = patient.MedicalRecord.PersonalInfo.Name;
            dto.Surname = patient.MedicalRecord.PersonalInfo.Surname;
            dto.BirthDate = ConvertToString(patient.MedicalRecord.PersonalInfo.BirthDate);
            dto.Phone = patient.ContactInfo.Phone;
            dto.Email = patient.ContactInfo.Email;
            dto.Gender = patient.MedicalRecord.PersonalInfo.Gender;
            dto.Username = patient.AccountInfo.Username;
            dto.Password = patient.AccountInfo.Password;
            dto.Address = patient.ContactInfo.Address;
            dto.DateOfRegistration = ConvertToString(patient.AccountInfo.DateOfRegistration);
            dto.ParentName = patient.MedicalRecord.PersonalInfo.ParentName;
            dto.IsActive = patient.AccountInfo.IsActive;
            dto.Allergens = AllergenAdapter.AllergenForPatientListToAllergenDTOList(patient.MedicalRecord.Allergens);
            dto.BloodType = patient.MedicalRecord.BloodType;
            dto.IsBlocked = patient.AccountInfo.IsBlocked;
            dto.DoctorDTO = DoctorAdapter.DoctorToDoctorDTO(patient.Doctor);

            return dto;
        }

        public static DateTime ConvertToDate(String dateAsString)
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

        public static String ConvertToString(DateTime date)
        {
            String dateAsString = date.ToString();

            return dateAsString;
        }

        public static DateTime ConvertToDateForAppointment(String dateAsString)
        {
            String[] mainParts = dateAsString.Split();

            String[] dateParts = mainParts[0].Split('-');
            int day = int.Parse(dateParts[0]);
            int month = int.Parse(dateParts[1]);
            int year = int.Parse(dateParts[2]);

            String[] timeParts = mainParts[1].Split(':');
            int hour = int.Parse(timeParts[0]);
            int minute = int.Parse(timeParts[1]);
            int second = int.Parse(timeParts[2]);

            DateTime date = new DateTime(year, month, day, hour, minute, second);

            return date;
        }
    }
}
