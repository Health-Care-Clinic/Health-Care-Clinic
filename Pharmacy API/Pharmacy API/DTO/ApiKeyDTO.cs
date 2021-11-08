﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Pharmacy_API.DTO
{
    public class ApiKeyDTO
    {
        public int Id { get; set; }
        public String Name { get; set; }
        public String Key { get; set; }
        public String BaseUrl { get; set; }
        public String Category { get; set; }

        public ApiKeyDTO() { }

        public ApiKeyDTO(int id, string name, string key, string baseUrl, string category)
        {
            Id = id;
            Name = name;
            Key = key;
            BaseUrl = baseUrl;
            Category = category;
        }
    }
}
