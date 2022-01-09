using Hospital.Tendering.Model;
using Hospital.Tendering.Repository;
using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace Hospital.Tendering.Service
{
    public class TenderResponseService : ITenderResponseService
    {

        private readonly ITenderResponseRepository _tenderResponseRepository;

        public TenderResponseService(ITenderResponseRepository tenderResponseRepository)
        {
            _tenderResponseRepository = tenderResponseRepository;
        }
        public void Add(TenderResponse entity)
        {
            _tenderResponseRepository.Add(entity);
            _tenderResponseRepository.Save();
        }

        public IEnumerable<TenderResponse> GetAll()
        {
            return _tenderResponseRepository.GetAll();
        }

        public TenderResponse GetOneById(int id)
        {
            return _tenderResponseRepository.GetById(id);
        }

        public ICollection<TenderResponse> GetTenderResponsesByTenderId(int tenderId)
        {
            return _tenderResponseRepository.GetAll().Where(x => x.TenderId == tenderId).ToList();
        }

        public void Remove(TenderResponse entity)
        {
            throw new NotImplementedException();
        }

        public void Update(TenderResponse entity)
        {
            _tenderResponseRepository.Update(entity);
        }
    }
}
