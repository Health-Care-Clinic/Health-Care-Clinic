using System;
using System.Collections.Generic;
using System.Text;

namespace Hospital.Shared_model.Model
{
    public class Specialty
    {
        public String Name { get; set; }

        public Specialty(string name)
        {
            this.Name = name;
        }
    }
}
