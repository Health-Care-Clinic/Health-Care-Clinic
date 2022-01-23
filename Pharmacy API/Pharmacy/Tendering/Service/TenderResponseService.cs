using Pharmacy.Interfaces.Repository;
using Pharmacy.Interfaces.Service;
using Pharmacy.Tendering.Model;
using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace Pharmacy.Tendering.Service
{
    public class TenderResponseService : ITenderResponseService
    {

        private readonly ITenderResponseRepository _tenderResponseRepository;
        private readonly IMedicineService _medicineService;

        public TenderResponseService(ITenderResponseRepository tenderResponseRepository, IMedicineService medicineService)
        {
            _tenderResponseRepository = tenderResponseRepository;
            _medicineService = medicineService;
        }
        public void Add(TenderResponse entity)
        {
            _tenderResponseRepository.Add(entity);
            _tenderResponseRepository.Save();
        }

        public TenderResponse CreateResponseFromTender(Tender tender)
        {
            TenderResponse tenderResponse = new TenderResponse();
            tenderResponse.TotalPrice = 0;
            tenderResponse.IsWinningBid = false;
            tenderResponse.TenderId = tender.Id;
            tenderResponse.PharmacyName = "Benu";
            tenderResponse.TenderItems = tender.TenderItems.Select(x => {
                int medicineQuantity = _medicineService.GetMedicineQuantity(x.Name);
                x.Quantity = medicineQuantity >= x.Quantity ? x.Quantity : medicineQuantity;
                tenderResponse.TotalPrice = tenderResponse.TotalPrice.Amount + x.Quantity * _medicineService.GetMedicinePrice(x.Name);
                return x;
                }).ToList();

            if (tenderResponse.TotalPrice.Amount == 0)
            {
                tenderResponse.Description = String.Format("Za tender sa ID-jem {0} ne postoji odgovarajuca ponuda.", tenderResponse.TenderId);
            }
            else
            {
                tenderResponse.Description = String.Format("Cena odgovora na tender sa ID-jem {0} je {1}.", tenderResponse.TenderId, tenderResponse.TotalPrice.Amount);
                if(tender.DateRange.Start > DateTime.Now || tender.DateRange.End < DateTime.Now)
                {
                    tenderResponse.TotalPrice = 0;
                    tenderResponse.Description = String.Format("Tender sa ID-jem {0} nije aktuelan.", tenderResponse.TenderId);
                }
            }

            return tenderResponse;
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

        public void UpdateByTenderId(TenderResponse tenderResponse)
        {
            TenderResponse tr = _tenderResponseRepository.GetAll().SingleOrDefault(x => x.TenderId == tenderResponse.TenderId);
            tr.IsWinningBid = tenderResponse.IsWinningBid;
            _tenderResponseRepository.Update(tr);
            _tenderResponseRepository.Save();

            foreach(TenderItem tenderItem in tenderResponse.TenderItems)
            {
                _medicineService.ReduceMedicineQuantity(tenderItem.Name, tenderItem.Quantity);
            }
            
        }
    }
}
