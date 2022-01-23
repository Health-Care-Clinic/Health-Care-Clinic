using Pharmacy.Advertisements.Model;
using System;
using System.Collections.Generic;
using System.Text;

namespace Pharmacy.Interfaces.Service
{
    public interface IAdvertisementService : IService<Advertisement>
    {
        public void AddEntitity(Advertisement entity, List<int> medicineIds)
        {
        }

        public void RemoveEntity(int id)
        {
        }
    }
}
