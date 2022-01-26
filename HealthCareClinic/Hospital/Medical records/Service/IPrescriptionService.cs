using System;
using System.Collections.Generic;
using System.Text;
using ClinicCore.Service;
using Hospital.Medical_records.Model;
using Hospital.Shared_model.Model;

namespace Hospital.Medical_records.Service
{
    public interface IPrescriptionService : IService<Prescription>
    {
        List<Prescription> GetAllPrescriptionsForPatient(Patient patient);
    }
}
