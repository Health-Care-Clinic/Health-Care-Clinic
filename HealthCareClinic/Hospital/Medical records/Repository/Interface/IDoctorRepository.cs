
using Hospital.Shared_model.Interface;
using Hospital.Shared_model.Model;
using System.Collections.Generic;

namespace Hospital.Medical_records.Repository.Interface
{
    public interface IDoctorRepository : IRepository<Doctor>
    {
        public List<Doctor> GetAvailableDoctors();
        public List<string> GetAllSpecialties();
        public List<Doctor> GetDoctorsBySpecialty(string specialty);
    }
}
