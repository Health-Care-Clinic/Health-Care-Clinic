using System;
using System.Collections.Generic;

using Hospital.Shared_model.Interface;
using Hospital.Shared_model.Model;
using Hospital.Medical_records.Repository.Interface;

namespace Hospital.Medical_records.Service
{
    public class DoctorService : IDoctorService
    {
        private readonly IDoctorRepository doctorRepository;

        public DoctorService(IDoctorRepository doctorRepository)
        {
            this.doctorRepository = doctorRepository;
        }
        public void Add(Doctor entity)
        {
            doctorRepository.Add(entity);
        }

        public IEnumerable<Doctor> GetAll()
        {
            return doctorRepository.GetAll();
        }

        public Doctor GetOneById(int id)
        {
            return doctorRepository.GetById(id);
        }

        public void Remove(Doctor entity)
        {
            doctorRepository.Remove(entity);
        }

        public List<Doctor> GetAvailableDoctors()
        {
            List<Doctor> availableDoctors = new List<Doctor>();

            availableDoctors = doctorRepository.GetAvailableDoctors();

            return availableDoctors;
        }

    }
}
