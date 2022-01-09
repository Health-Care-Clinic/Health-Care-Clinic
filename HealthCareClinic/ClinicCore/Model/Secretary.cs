using System;
using System.Collections.Generic;

namespace Model
{
    public class Secretary : Employee
    {
        public Secretary(int id, string name, string surname, DateTime birthDate, string email, string password, string address, double salary, DateTime employmentDate, List<WorkDay> workDays) : base(id, name, surname, birthDate, email, password, address, salary, employmentDate, workDays)
        {
        }
    }
}