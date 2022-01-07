using Enums;
using System;
using System.Collections.Generic;

namespace ClinicCore.DTOs
{
    public class DoctorDTO
    {
        public int Id { get; set; }
        public String Name { get; set; }
        public String Surname { get; set; }
        public DateTime BirthDate { get; set; }
        public String Phone { get; set; }
        public String Email { get; set; }
        public String Gender { get; set; }
        public String Password { get; set; }
        public String Address { get; set; }
        public String Specialty { get; set; }
        public int PrimaryRoom { get; set; }
        public DateTime VacationTimeStart { get; set; }
        public WorkDayShift WorkShift { get; set; }
        public List<DateTime> DaysOff { get; set; } = new List<DateTime>();

        public DoctorDTO(int id, string name, string surname, DateTime birthDate, string phone, 
            string email, string gender, string password, string address, string specialty, int primaryRoom)
        {
            Id = id;
            Name = name;
            Surname = surname;
            BirthDate = birthDate;
            Phone = phone;
            Email = email;
            Gender = gender;
            Password = password;
            Address = address;
            Specialty = specialty;
            PrimaryRoom = primaryRoom;
        }

        public DoctorDTO(int id, string name, string surname, DateTime birthDate, string phone,
           string email, string gender, string password, string address, string specialty, int primaryRoom, DateTime vacationTimeStart, WorkDayShift workShift, List<DateTime> daysOff)
        {
            Id = id;
            Name = name;
            Surname = surname;
            BirthDate = birthDate;
            Phone = phone;
            Email = email;
            Gender = gender;
            Password = password;
            Address = address;
            Specialty = specialty;
            PrimaryRoom = primaryRoom;
            VacationTimeStart = vacationTimeStart;
            WorkShift = workShift;
            DaysOff.AddRange(daysOff);
        }

        public DoctorDTO()
        { 
        }
    }

}
