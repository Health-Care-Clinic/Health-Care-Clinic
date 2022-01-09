using Hospital.Medical_records.Service;
using Hospital.Schedule.Model;
using Hospital.Shared_model.Model;
using Hospital_API.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Hospital_API.Adapter
{
    public class AppointmentSchedulingAdapter
    {
        public static TermsInDateRangeForDoctorDTO TermsInDateRangeForDoctorToDTO(TermsInDateRangeForDoctor termsInDateRangeForDoctor)
        {
            TermsInDateRangeForDoctorDTO termsDTO = new TermsInDateRangeForDoctorDTO();

            termsDTO.Doctor = DoctorAdapter.DoctorToDoctorWithSpecialtyDTO(termsInDateRangeForDoctor.Doctor);
            termsDTO.Terms = new List<string>();
            foreach (DateTime dateTime in termsInDateRangeForDoctor.Terms)
            {
                termsDTO.Terms.Add(ConvertToString(dateTime));
            }

            return termsDTO;
        }

        public static TermsInDateRangeForDoctor TermsInDateRangeForDoctorDTOToObject(TermsInDateRangeForDoctorDTO dto)
        {
            TermsInDateRangeForDoctor termsObject = new TermsInDateRangeForDoctor();

            termsObject.Doctor = DoctorAdapter.DoctorWithSpecialtyDTOToDoctor(dto.Doctor);
            termsObject.Terms = new List<DateTime>();
            foreach (string dateTimeAsString in dto.Terms)
            {
                termsObject.Terms.Add(ConvertToDateTime(dateTimeAsString));
            }

            return termsObject;
        }

        public static TermsInDateRangeDTO TermsInDateRangeToDTO(TermsInDateRange termsInDateRange)
        {
            TermsInDateRangeDTO termsDTO = new TermsInDateRangeDTO();

            termsDTO.InitiallyPickedDoctor = DoctorAdapter.DoctorToDoctorWithSpecialtyDTO(termsInDateRange.InitiallyPickedDoctor);
            termsDTO.Specialty = termsInDateRange.Specialty;
            termsDTO.BeginningDateTime = ConvertToString(termsInDateRange.BeginningDateTime);
            termsDTO.EndingDateTime = ConvertToString(termsInDateRange.EndingDateTime);
            termsDTO.TermsInDateRangeForDoctors = new List<TermsInDateRangeForDoctorDTO>();
            foreach (TermsInDateRangeForDoctor termsInDateRangeForDoctor in termsInDateRange.TermsInDateRangeForDoctors)
            {
                termsDTO.TermsInDateRangeForDoctors.Add(TermsInDateRangeForDoctorToDTO(termsInDateRangeForDoctor));
            }

            return termsDTO;
        }

        public static TermsInDateRange TermsInDateRangeDTOToObject(TermsInDateRangeDTO dto)
        {
            TermsInDateRange termsObject = new TermsInDateRange();

            termsObject.InitiallyPickedDoctor = DoctorAdapter.DoctorWithSpecialtyDTOToDoctor(dto.InitiallyPickedDoctor);
            termsObject.Specialty = dto.Specialty;
            termsObject.BeginningDateTime = ConvertToDateTime(dto.BeginningDateTime);
            termsObject.EndingDateTime = ConvertToDateTime(dto.EndingDateTime);
            termsObject.TermsInDateRangeForDoctors = new List<TermsInDateRangeForDoctor>();
            foreach (TermsInDateRangeForDoctorDTO termsInDateRangeForDoctorDTO in dto.TermsInDateRangeForDoctors)
            {
                termsObject.TermsInDateRangeForDoctors.Add(TermsInDateRangeForDoctorDTOToObject(termsInDateRangeForDoctorDTO));
            }

            return termsObject;
        }

        public static TermsInDateRange CreateTermsInDateRangeObject(DoctorAndDateRangeDataDTO dto, IDoctorService doctorService)
        {
            Doctor initiallyPickedDoctor = doctorService.GetOneById(dto.DoctorId);

            TermsInDateRange termsInDateRange = new TermsInDateRange(initiallyPickedDoctor, initiallyPickedDoctor.Specialty, 
                ConvertToDateTime(dto.BeginningDateTime), ConvertToDateTime(dto.EndingDateTime), 
                new List<TermsInDateRangeForDoctor>());

            return termsInDateRange;
        }

        private static DateTime ConvertToDateTime(string dateTimeAsString)
        {
            string[] mainParts = dateTimeAsString.Split('T');

            string[] dateParts = mainParts[0].Split('-');
            int year = int.Parse(dateParts[0]);
            int month = int.Parse(dateParts[1]);
            int day = int.Parse(dateParts[2]);

            string[] timeParts = mainParts[1].Split(':');
            int hour = int.Parse(timeParts[0]);
            int minute = int.Parse(timeParts[1]);
            int second = int.Parse(timeParts[2].Substring(0, 2));

            DateTime dateTime = new DateTime(year, month, day, hour, minute, second);

            return dateTime;
        }

        private static string ConvertToString(DateTime dateTime)
        {
            string dateTimeAsString = dateTime.ToString();

            return dateTimeAsString;
        }
    }
}
