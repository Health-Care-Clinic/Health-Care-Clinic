using Hospital.Shared_model.Interface;
using Hospital.Shared_model.Model;
using System;
using System.Collections.Generic;
using System.Text;

namespace Hospital.Medical_records.Service
{
    public interface IDoctorService : IService<Doctor>
    {
        List<Doctor> GetAvailableDoctors();
        public List<String> GetAllSpecialties();
        public List<Doctor> GetDoctorsBySpecialty(string specialty);
        public void addShiftToDoctor(Doctor doctor);
        public Doctor findById(int id);
    }
}
