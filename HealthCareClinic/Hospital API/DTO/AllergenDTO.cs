﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Hospital_API.DTO
{
    public class AllergenDTO
    {
        public int Id { get; set; }
        public String Name { get; set; }
        public AllergenDTO()
        {
        }

        public AllergenDTO(int id, string name)
        {
            Id = id;
            Name = name;
        }
    }
}
