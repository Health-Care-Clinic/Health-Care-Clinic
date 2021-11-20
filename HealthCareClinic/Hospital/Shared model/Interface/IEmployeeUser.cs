using Hospital.Shared_model.Model;
using System;
using System.Collections.Generic;
using System.Text;

namespace Hospital.Shared_model.Interface
{
    public interface IEmployeeUser : IUser
    {
        public Double Salary { get; set; }
        public DateTime EmploymentDate { get; set; }
        public List<WorkDay> WorkDay { get; set; }
    }
}
