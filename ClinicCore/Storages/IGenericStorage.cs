using ClinicCore.Model;
using System.Collections.Generic;

namespace ClinicCore.Storages
{
    public interface IGenericStorage<T> where T:Entity
    {
        List<T> GetAll();
        T GetById(int id);
        void Add(T newObject);
        void Update(T selectedObject);
        void Delete(T selectedObject);
    }
}
