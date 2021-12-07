using Hospital.Shared_model.Model;
using Hospital_API.DTO;
using System;
using System.Collections.Generic;

namespace Hospital_API.Adapter
{
    public class DoctorAdapter
    {
        public static List<DoctorDTO> DoctorListToDoctorDTOList(List<Doctor> doctors)
        {
            List<DoctorDTO> doctorsDTO = new List<DoctorDTO>();
            foreach (Doctor doctor in doctors)
                doctorsDTO.Add(DoctorToDoctorDTO(doctor));

            return doctorsDTO;
        }
        public static DoctorDTO DoctorToDoctorDTO(Doctor doctor)
        {
            if (doctor is null)
                return null;

            DoctorDTO dto = new DoctorDTO();

            dto.Id = doctor.Id;
            dto.Name = doctor.Name;
            dto.Surname = doctor.Surname;

            return dto;
        }

        internal static Doctor DoctorDTOToDoctor(DoctorDTO dto)
        {
            Doctor doctor = new Doctor();

            doctor.Id = dto.Id;
            doctor.Name = dto.Name;
            doctor.Surname = dto.Surname;

            return doctor;
        }

        public static List<DoctorWithSpecialtyDTO> DoctorListToDoctorWithSpecialtyDTOList(List<Doctor> doctors)
        {
            List<DoctorWithSpecialtyDTO> doctorsDTO = new List<DoctorWithSpecialtyDTO>();
            foreach (Doctor doctor in doctors)
                doctorsDTO.Add(DoctorToDoctorWithSpecialtyDTO(doctor));

            return doctorsDTO;
        }

        public static DoctorWithSpecialtyDTO DoctorToDoctorWithSpecialtyDTO(Doctor doctor)
        {
            if (doctor is null)
                return null;

            DoctorWithSpecialtyDTO dto = new DoctorWithSpecialtyDTO();

            dto.Id = doctor.Id;
            dto.Name = doctor.Name;
            dto.Surname = doctor.Surname;
            dto.Specialty = doctor.Specialty.Name;

            return dto;
        }
    }
}

