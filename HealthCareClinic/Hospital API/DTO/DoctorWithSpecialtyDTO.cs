using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Hospital_API.DTO
{
    public class DoctorWithSpecialtyDTO
    {
        public int Id { get; set; }
        public String Name { get; set; }
        public String Surname { get; set; }
        public String Specialty { get; set; }
        public int WorkShiftId { get; set; }

        public DoctorWithSpecialtyDTO(int id, string name, string surname, string specialty) : this(id, name, surname)
        {
            Specialty = specialty;
        }

        public DoctorWithSpecialtyDTO(int id, string name, string surname)
        {
            Id = id;
            Name = name;
            Surname = surname;
        }

        public DoctorWithSpecialtyDTO()
        {
        }
    }
}
