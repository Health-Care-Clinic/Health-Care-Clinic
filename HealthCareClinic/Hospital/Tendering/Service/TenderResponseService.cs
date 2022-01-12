using Hospital.Tendering.Model;
using Hospital.Tendering.Repository;
using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using Hospital_API.Tendering.Model;
using Microsoft.VisualBasic.CompilerServices;

namespace Hospital.Tendering.Service
{
    public class TenderResponseService : ITenderResponseService
    {

        private readonly ITenderResponseRepository _tenderResponseRepository;
        private readonly ITenderService _tenderService;

        public TenderResponseService(ITenderResponseRepository tenderResponseRepository, ITenderService tenderService)
        {
            _tenderResponseRepository = tenderResponseRepository;
            _tenderService = tenderService;
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
            return _tenderResponseRepository.GetAll().Where(x => x.TenderId == tenderId && !x.IsWinningBid).ToList();
        }

        public void Remove(TenderResponse entity)
        {
            throw new NotImplementedException();
        }

        public void Update(TenderResponse entity)
        {
            _tenderResponseRepository.Update(entity);
        }

        public IEnumerable<string> GetPharmacyNames(string startDate, string endDate)
        {
            List<String> names = new List<String>();
            foreach (TenderResponse response in GetResponsesByDate(startDate, endDate))
            {
                names.Add(response.PharmacyName);
            }
            return names.Distinct();
        }

        public List<int> GetNumberOfWins(string startDate, string endDate)
        {
            List<int> wins = new List<int>();
            IEnumerable<String> pharmacyNames = GetPharmacyNames(startDate, endDate);

            foreach (String name in pharmacyNames)
            {
                int numberOfWins = 0;
                foreach (TenderResponse response in GetResponsesByDate(startDate, endDate))
                {
                    if (response.IsWinningBid && response.PharmacyName.Equals(name)) numberOfWins++;
                }
                wins.Add(numberOfWins);
            }
            return wins;
        }

        public int GetNumberOfOffers(int tenderId)
        {
            int offersNumber = 0;
            foreach (TenderResponse response in _tenderResponseRepository.GetAll())
            {
                if (response.TenderId == tenderId && !response.IsWinningBid) offersNumber++;
            }
            return offersNumber;
        }

        public List<int> GetNumberOfOffers(string startDate, string endDate)
        {
            List<int> offers = new List<int>();
            IEnumerable<String> pharmacyNames = GetPharmacyNames(startDate, endDate);

            foreach (String name in pharmacyNames)
            {
                int numberOfOffers = GetResponsesByDate(startDate, endDate).Count(response => response.PharmacyName.Equals(name));
                offers.Add(numberOfOffers);
            }
            return offers;
        }

        public List<double> GetBestOffers(string startDate, string endDate)
        {
            List<double> bestOffers = new List<double>();
            foreach (String name in GetPharmacyNames(startDate, endDate))
            {
                double bestOffer = 0.0;
                foreach (BestOfferDto dto in GetAllOffers(name))
                {
                    bestOffer = dto.Offer;
                    bestOffers.Add(bestOffer);
                }
                
            }
            return bestOffers;
        }
        private List<BestOfferDto> GetAllOffers(String pharmacyName)
        {
            List<BestOfferDto> allOffers = new List<BestOfferDto>();
            foreach (int id in GetTenderIds())
            {
                BestOfferDto offer = new BestOfferDto();
                foreach (TenderResponse response in _tenderResponseRepository.GetAll())
                {
                    if (response.PharmacyName.Equals(pharmacyName) && response.TenderId == id)
                    {
                        offer.TenderId = id;
                        offer.PharmacyName = pharmacyName;
                        offer.Offer = GetBestOffer(response.PharmacyName, response.TenderId);
                    }
                }
                allOffers.Add(offer);
            }
            return allOffers;
        }

        public int GetTendersNumberParticipatedByPharmacy(string pharmacyName)
        {
            List<int> tenders = new List<int>();
            foreach (TenderResponse response in _tenderResponseRepository.GetAll().Where(x => x.PharmacyName.Equals(pharmacyName)))
            {
                tenders.Add(response.TenderId);
            }
            tenders = tenders.Distinct().ToList();
            return tenders.Count;
        }
        public int GetTendersNumberWonByPharmacy(string pharmacyName)
        {
            List<int> tenders = new List<int>();
            foreach (TenderResponse response in _tenderResponseRepository.GetAll())
            {
                if (response.PharmacyName.Equals(pharmacyName) && response.IsWinningBid)
                    tenders.Add(response.TenderId);
            }
            tenders = tenders.Distinct().ToList();
            return tenders.Count;
        }

        public int GetOffersNumberByTender(int tenderId)
        {
            int offers = 0;
            foreach (TenderResponse response in _tenderResponseRepository.GetAll())
            {
                if (response.TenderId == tenderId) offers++;
            }
            return offers;
        }

        public List<double> GetOfferByTender(int tenderId, string pharmacyName)
        {
            List<double> offers = new List<double>();
            foreach (TenderResponse response in _tenderResponseRepository.GetAll())
            {
                if (response.PharmacyName.Equals(pharmacyName) && response.TenderId == tenderId) offers.Add(response.TotalPrice.Amount);
            }
            return offers;
        }

        private double GetBestOffer(String pharmacyName, int id)
        {
            return GetOfferByTender(id, pharmacyName).Min(x => x);
        }

        private IEnumerable<int> GetTenderIds()
        {
            List<int> ids = new List<int>();
            foreach (TenderResponse response in _tenderResponseRepository.GetAll())
            {
                ids.Add(response.TenderId);
            }
            return ids.Distinct();
        }

        private DateTime StringToDate(string date)
        {
            string[] parts = date.Split("-");
            DateTime newDate = new DateTime(int.Parse(parts[0]), int.Parse(parts[1]), int.Parse(parts[2]));
            return newDate;
        }

        private List<TenderResponse> GetResponsesByDate(string startDate, string endDate)
        {
            List<TenderResponse> responses = new List<TenderResponse>();
            Tender tender = new Tender();
            foreach (TenderResponse r in _tenderResponseRepository.GetAll())
            {
                tender = _tenderService.GetOneById(r.TenderId);
                if (StringToDate(startDate) >= tender.DateRange.Start &&
                    StringToDate(endDate) <= tender.DateRange.End)
                {
                    responses.Add(r);
                }
            }

            return responses;
        }

    }
}
