using Model;
using System;
using System.Collections.Generic;

namespace ClinicCore.Model.Interface
{
    interface IEmployeeUser : IUser
    {
        public Double Salary { get; set; }
        public DateTime EmploymentDate { get; set; }
        public List<WorkDay> WorkDay { get; set; }
    }
}
