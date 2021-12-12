using Hospital.Shared_model.Model;
using Hospital.Shared_model.Repository;
using System;
using System.Collections.Generic;
using System.Text;

namespace Hospital.Shared_model.Service
{
    public class AllergenService : IAllergenService
    {
        private IAllergenRepository _allergenRepository;

        public AllergenService(IAllergenRepository allergenRepository)
        {
            _allergenRepository = allergenRepository;
        }

        public void Add(Allergen entity)
        {
            _allergenRepository.Add(entity);
        }

        public IEnumerable<Allergen> GetAll()
        {
            return _allergenRepository.GetAll();
        }

        public Allergen GetOneById(int id)
        {
            throw new NotImplementedException();
        }

        public void Remove(Allergen entity)
        {
            throw new NotImplementedException();
        }
    }
}
