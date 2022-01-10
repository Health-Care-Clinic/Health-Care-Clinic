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

        public IEnumerable<string> GetPharmacyNames()
        {
            List<String> names = new List<String>();
            foreach (TenderResponse response in _tenderResponseRepository.GetAll())
            {
                names.Add(response.PharmacyName);
            }
            return names.Distinct();
        }

        public List<int> GetNumberOfWins()
        {
            List<int> wins = new List<int>();
            IEnumerable<String> pharmacyNames = GetPharmacyNames();

            foreach (String name in pharmacyNames)
            {
                int numberOfWins = 0;
                foreach (TenderResponse response in _tenderResponseRepository.GetAll())
                {
                    if (response.IsWinningBid && response.PharmacyName.Equals(name)) numberOfWins++;
                }
                wins.Add(numberOfWins);
            }
            return wins;
        }

        public List<int> GetNumberOfOffers()
        {
            List<int> offers = new List<int>();
            IEnumerable<String> pharmacyNames = GetPharmacyNames();

            foreach (String name in pharmacyNames)
            {
                int numberOfOffers = _tenderResponseRepository.GetAll().Count(response => response.PharmacyName.Equals(name));
                offers.Add(numberOfOffers);
            }
            return offers;
        }

        public List<double> GetBestOffers()
        {
            List<double> bestOffers = new List<double>();
            foreach (String name in GetPharmacyNames())
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
        public int GetNumberOfOffers(int tenderId)
        {
            int offersNumber = 0;
            foreach (TenderResponse response in _tenderResponseRepository.GetAll())
            {
                if (response.TenderId == tenderId) offersNumber++;
            }
            return offersNumber;
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

        private List<double> GetOfferByTender(int tenderId, string pharmacyName)
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

    }
}
