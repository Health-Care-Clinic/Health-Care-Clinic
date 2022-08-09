using System;
using System.Collections.Generic;
using System.Text;
using Hospital.Medical_records.Model;
using Hospital.Medical_records.Repository.Interface;
using Hospital.Shared_model.Model;

namespace Hospital.Medical_records.Service
{
    public class PrescriptionService : IPrescriptionService
    {
        private readonly IPrescriptionRepository _prescriptionRepository;

        public PrescriptionService(IPrescriptionRepository prescriptionRepository)
        {
            _prescriptionRepository = prescriptionRepository;
        }

        public void Add(Prescription entity)
        {
            _prescriptionRepository.Add(entity);
        }

        public void Remove(Prescription entity)
        {
            _prescriptionRepository.Remove(entity);
        }

        public Prescription GetOneById(int id)
        {
            return _prescriptionRepository.GetById(id);
        }

        public IEnumerable<Prescription> GetAll()
        {
            return _prescriptionRepository.GetAll();
        }

        public List<Prescription> GetAllPrescriptionsForPatient(Patient patient)
        {
            return _prescriptionRepository.GetAllPrescriptionsForPatient(patient);
        }
    }
}
