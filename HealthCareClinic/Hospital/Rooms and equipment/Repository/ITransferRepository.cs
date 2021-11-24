using ClinicCore.Storages;
using Hospital.Rooms_and_equipment.Model;
using System;
using System.Collections.Generic;
using System.Text;

namespace Hospital.Rooms_and_equipment.Repository
{
    public interface ITransferRepository : IRepository<Transfer>
    {
        public void RemoveById(int id);
    }
}
