using Pharmacy.Model;
using System;
using System.Collections.Generic;
using System.Text;

namespace Pharmacy.Repository
{
    public interface IMedicineRepository: IRepository<Medicine>
    {
        Medicine GetByName(string name);
    }
}
