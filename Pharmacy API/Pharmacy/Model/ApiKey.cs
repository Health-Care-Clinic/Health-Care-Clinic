using System;
using System.Collections.Generic;
using System.Text;

namespace Pharmacy.Model
{
    public class ApiKey
    {
        public int Id { get; set; }
        public String Name { get; set; }
        public String Key { get; set; }
        public String BaseUrl { get; set; }

        public ApiKey() { }

        public ApiKey(string name, string key, string baseUrl)
        {
            Name = name;
            Key = key;
            BaseUrl = baseUrl;
        }
    }
}
