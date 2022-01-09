using ClinicCore.Storages;
using Hospital.Shared_model.Model;
using System;
using System.Collections.Generic;
using System.Text;

namespace Hospital.Shared_model.Repository
{
    public interface IVacationRepository : IRepository<Vacation>
    {
        public void Change(Vacation entity);
        public void RemoveById(int id);
        public List<Vacation> GetVacationsByDoctorId(int id);
    }
}
