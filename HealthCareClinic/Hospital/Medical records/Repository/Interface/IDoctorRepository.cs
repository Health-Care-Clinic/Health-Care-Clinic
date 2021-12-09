
using Hospital.Shared_model.Interface;
using Hospital.Shared_model.Model;
using System.Collections.Generic;

namespace Hospital.Medical_records.Repository.Interface
{
    public interface IDoctorRepository : IRepository<Doctor>
    {
        List<Doctor> GetAvailableDoctors();
        List<Doctor> GetDoctorsWithSpecialty(string specialtyName);
    }
}
