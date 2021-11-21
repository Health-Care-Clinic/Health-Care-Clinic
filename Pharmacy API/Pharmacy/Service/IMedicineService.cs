using System;
using System.Collections.Generic;
using System.Text;
using Pharmacy.Model;

namespace Pharmacy.Service
{
    public interface IMedicineService : IService<Medicine>
    {
        Medicine GetByName(string name);
    }
}
