using System;
using System.Collections.Generic;
using System.Text;
using ClinicCore.Storages;
using Hospital.Medical_records.Model;

namespace Hospital.Medical_records.Repository.Interface
{
    public interface IPrescriptionRepository : IRepository<Prescription>
    {
    }
}
