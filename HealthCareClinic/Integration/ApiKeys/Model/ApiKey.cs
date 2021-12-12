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
        public String City { get; set; }
        public String Category { get; set; }
        public String ImagePath { get; set; }
        public String Note { get; set; }

        public ApiKey() {}

        public ApiKey(string name, string key, string baseUrl, string category)
        {
            Name = name;
            Key = key;
            BaseUrl = baseUrl;
            Category = category;
            ImagePath = "";
            Note = "";
        }
        public ApiKey(string name, string key, string baseUrl, string category, string imagePath, string note)
        {
            Name = name;
            Key = key;
            BaseUrl = baseUrl;
            Category = category;
            ImagePath = imagePath;
            Note = note;
        }
    }
}
