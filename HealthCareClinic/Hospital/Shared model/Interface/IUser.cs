using Hospital.Shared_model.Model;
using System;
using System.Collections.Generic;
using System.Text;

namespace Hospital.Shared_model.Interface
{
    public interface IUser
    {
        public EducationCategory Education { get; set; }
        public int Id { get; set; }
        public String Name { get; set; }
        public String Surname { get; set; }
        public DateTime BirthDate { get; set; }
        public String Phone { get; set; }
        public String Email { get; set; }
        public String Gender { get; set; }
        public String Relationship { get; set; }
        public String Password { get; set; }
        public String Address { get; set; }
    }
}
