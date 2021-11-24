
using Hospital.Shared_model.Interface;
using Hospital.Shared_model.Model;

namespace Hospital.Medical_records.Repository.Interface
{
    public interface IPatientRepository : IRepository<Patient>
    {
        void ActivatePatientsAccount(int id);
        Patient FindByToken(string token);
    }
}
