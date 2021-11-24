using System;
using System.Collections.Generic;
using System.Text;

namespace Integration.ApiKeys.Model
{
    public class ApiKey
    {
        public int Id { get; set; }
        public String Name { get; set; }
        public String Key { get; set; }
        public String BaseUrl { get; set; }
        public string City { get; set; }

        public String Category { get; set; }

        public ApiKey() {}

        public ApiKey(string name, string key, string baseUrl, string category)
        {
            Name = name;
            Key = key;
            BaseUrl = baseUrl;
            Category = category;
        }
    }
}
