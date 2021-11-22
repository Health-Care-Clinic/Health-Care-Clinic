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
        public String Name { get; set; }
        public String Surname { get; set; }
        public DateTime BirthDate { get; set; }
        public String Phone { get; set; }
        public String Username { get; set; }
        public String Email { get; set; }
        public String Gender { get; set; }
        public String Password { get; set; }
        public String Address { get; set; }
        public Double Salary { get; set; }
        public DateTime EmploymentDate { get; set; }
        public virtual ICollection<WorkDay> WorkDay { get; set; }

        public Employee(int id, string name, string surname, string gender, DateTime birthDate, double salary, string address, string phone,
            string email, string username, string password, 
            DateTime employmentDate, ICollection<WorkDay> workDay)
        {
            Id = id;
            Name = name;
            Surname = surname;
            BirthDate = birthDate;
            Phone = phone;
            Username = username;
            Email = email;
            Gender = gender;
            Password = password;
            Address = address;
            Salary = salary;
            EmploymentDate = employmentDate;
            WorkDay = workDay;
        }

        public Employee()
        {
        }
    }
}
