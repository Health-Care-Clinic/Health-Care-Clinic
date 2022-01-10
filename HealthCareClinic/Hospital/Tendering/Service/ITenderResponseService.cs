using ClinicCore.Service;
using Hospital.Tendering.Model;
using System;
using System.Collections.Generic;
using System.Text;

namespace Hospital.Tendering.Service
{
    public interface ITenderResponseService : IService<TenderResponse>
    {
        ICollection<TenderResponse> GetTenderResponsesByTenderId(int tenderId);
        void Update(TenderResponse entity);
        List<String> GetPharmacyNames();
        int GetNumberOfWins(String pharmacyName);
        int GetNumberOfOffers(String pharmacyName);
    }
}
