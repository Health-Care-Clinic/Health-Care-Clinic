using Hospital.Tendering.Model;
using Hospital.Tendering.Repository;
using System;
using System.Collections.Generic;
using System.Text;

namespace Hospital.Tendering.Service
{
    public class TenderService : ITenderService
    {

        private readonly ITenderRepository _tenderRepository;

        public TenderService(ITenderRepository tenderRepository)
        {
            _tenderRepository = tenderRepository;
        }
        public void Add(Tender entity)
        {
            _tenderRepository.Add(entity);
            _tenderRepository.Save();
        }

        public IEnumerable<Tender> GetAll()
        {
            return _tenderRepository.GetAll();
        }

        public Tender GetOneById(int id)
        {
            Tender found = new Tender();
            foreach (Tender tender in GetAll())
            {
                if (tender.Id == id) found = tender;
            }

            return found;
        }

        public void Remove(Tender entity)
        {
            throw new NotImplementedException();
        }
    }
}
