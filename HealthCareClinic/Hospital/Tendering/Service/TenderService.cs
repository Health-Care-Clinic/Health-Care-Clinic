using Hospital.Tendering.Model;
using System;
using System.Collections.Generic;
using System.Text;

namespace Hospital.Tendering.Service
{
    public class TenderService : ITenderService
    {

        private readonly TenderService _tenderService;

        public TenderService(TenderService tenderService)
        {
            _tenderService = tenderService;
        }
        public void Add(Tender entity)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Tender> GetAll()
        {
            throw new NotImplementedException();
        }

        public Tender GetOneById(int id)
        {
            throw new NotImplementedException();
        }

        public void Remove(Tender entity)
        {
            throw new NotImplementedException();
        }
    }
}
