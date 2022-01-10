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
        IEnumerable<String> GetPharmacyNames();
        List<int> GetNumberOfOffers();
        List<int> GetNumberOfWins();
        List<double> GetBestOffers();
    }
}
