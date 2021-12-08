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
            Patient patient = new Patient();

            AllergenForPatient allergenForPatient = new AllergenForPatient();

            patient.Id = dto.Id;
            patient.EmploymentStatus = dto.EmploymentStatus;
            patient.Name = dto.Name;
            patient.Surname = dto.Surname;
            patient.BirthDate = ConvertToDate(dto.BirthDate);
            patient.Phone = dto.Phone;
            patient.Email = dto.Email;
            patient.Gender = dto.Gender;
            patient.Username = dto.Username;
            patient.Password = dto.Password;
            patient.Address = dto.Address;
            patient.DateOfRegistration = ConvertToDate(dto.DateOfRegistration);
            patient.ParentName = dto.ParentName;
            patient.IsActive = dto.IsActive;
            patient.BloodType = dto.BloodType;
            patient.IsBlocked = dto.IsBlocked;
            patient.Allergens = AllergenAdapter.AllergenDTOListToAllergenForPatientList(dto.Allergens, dto.Id);
            return patient;
        }

        public static PatientDTO PatientToPatientDTO(Patient patient)
        {
            PatientDTO dto = new PatientDTO();

            dto.Id = patient.Id;
            dto.EmploymentStatus = patient.EmploymentStatus;
            dto.Name = patient.Name;
            dto.Surname = patient.Surname;
            dto.BirthDate = ConvertToString(patient.BirthDate);
            dto.Phone = patient.Phone;
            dto.Email = patient.Email;
            dto.Gender = patient.Gender;
            dto.Username = patient.Username;
            dto.Password = patient.Password;
            dto.Address = patient.Address;
            dto.DateOfRegistration = ConvertToString(patient.DateOfRegistration);
            dto.ParentName = patient.ParentName;
            dto.IsActive = patient.IsActive;
            dto.Allergens = AllergenAdapter.AllergenForPatientListToAllergenDTOList(patient.Allergens);
            dto.BloodType = patient.BloodType;
            dto.IsBlocked = patient.IsBlocked;
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
    }
}
