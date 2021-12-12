using System;

namespace ClinicCore.DTOs
{
    public class BranchDTO
    {
        public String Name { get; set; }
        public String City { get; set; }

        public BranchDTO(string name, string city)
        {
            Name = name;
            City = city;
        }
    }
}
