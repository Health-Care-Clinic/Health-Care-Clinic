using System;
using System.Collections.Generic;
using System.Text;
using ClinicCore.Storages;
using Hospital.Medical_records.Model;
using Hospital.Shared_model.Model;

namespace Hospital.Medical_records.Repository.Interface
{
    public interface IPrescriptionRepository : IRepository<Prescription>
    {
        List<Prescription> GetAllPrescriptionsForPatient(Patient patient);
    }
}
