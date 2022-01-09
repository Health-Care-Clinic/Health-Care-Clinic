using System;

namespace Hospital_API.DTO
{
    public class DoctorDTO
    {
        public int Id { get; set; }
        public String Name { get; set; }
        public String Surname { get; set; }
        public int WorkShiftId { get; set; }

        public DoctorDTO(int id, string name, string surname)
        {
            Id = id;
            Name = name;
            Surname = surname;
        }

        public DoctorDTO()
        {
        }
    }
}