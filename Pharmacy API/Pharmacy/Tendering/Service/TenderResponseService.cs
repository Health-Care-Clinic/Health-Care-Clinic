using Pharmacy.Interfaces.Repository;
using Pharmacy.Interfaces.Service;
using Pharmacy.Tendering.Model;
using System;
using System.Collections.Generic;
using System.Text;

namespace Pharmacy.Tendering.Service
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
            throw new NotImplementedException();
        }

        public void Remove(TenderResponse entity)
        {
            throw new NotImplementedException();
        }
    }
}
