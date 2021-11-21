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
            DoctorDTO dto = new DoctorDTO();

            dto.Id = doctor.Id;
            dto.Name = doctor.Name;
            dto.Surname = doctor.Surname;

            return dto;
        }
    }

}