using ClinicCore.Service;
using Hospital.Tendering.Model;
using System;
using System.Collections.Generic;
using System.Text;
using Hospital_API.Tendering.Model;

namespace Hospital.Tendering.Service
{
    public interface ITenderResponseService : IService<TenderResponse>
    {
        ICollection<TenderResponse> GetTenderResponsesByTenderId(int tenderId);
        void Update(TenderResponse entity);
        IEnumerable<String> GetPharmacyNames(string startDate, string endDate);
        int GetNumberOfOffers(int tenderId);
        List<int> GetNumberOfOffers(string startDate, string endDate);
        List<int> GetNumberOfWins(string startDate, string endDate);
        List<double> GetBestOffers(string startDate, string endDate);
        int GetTendersNumberParticipatedByPharmacy(string pharmacyName);
        int GetTendersNumberWonByPharmacy(string pharmacyName);
        int GetOffersNumberByTender(int tenderId);
        List<double> GetOfferByTender(int tenderId, string pharmacyName);
    }
}
