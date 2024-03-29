﻿using System;

namespace Integration.DTO
{
    public class PharmacyDTO
    {
        public int Id { get; set; }
        public String Name { get; set; }
        public string City { get; set; }

        public PharmacyDTO() { }

        public PharmacyDTO(int id, string name, string city)
        {
            Id = id;
            Name = name;
            City = city;
        }
    }
}
