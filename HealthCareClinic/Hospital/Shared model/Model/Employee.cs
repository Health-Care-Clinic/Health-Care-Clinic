using Hospital.Shared_model.Interface;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Hospital.Shared_model.Model
{
    public class Employee : IEmployeeUser
    {
        [Key]
        public int Id { get; set; }        
        public virtual EducationCategory Education { get; set; }
        public String Name { get; set; }
        public String Surname { get; set; }
        public DateTime BirthDate { get; set; }
        public String Phone { get; set; }
        public String Email { get; set; }
        public String Gender { get; set; }
        public String Relationship { get; set; }
        public String Password { get; set; }
        public String Address { get; set; }
        public Double Salary { get; set; }
        public DateTime EmploymentDate { get; set; }
        public virtual ICollection<WorkDay> WorkDay { get; set; }

        public Employee(int id, string name, string surname, DateTime birthDate, string address, string email, string password, double salary, DateTime employmentDate, ICollection<WorkDay> workDays)
        {
            this.Id = id;
            this.Name = name;
            this.Surname = surname;
            this.BirthDate = birthDate;
            this.Address = address;
            this.Email = email;
            this.Password = password;
            this.Salary = salary;
            this.EmploymentDate = employmentDate;
            this.WorkDay = workDays;
        }

        public Employee()
        {
        }
    }
}
