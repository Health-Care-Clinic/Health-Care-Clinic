using Pharmacy.Tendering.Model;
using System;
using System.Collections.Generic;
using System.Text;

namespace Pharmacy.Interfaces.Service
{
    public interface ITenderResponseService : IService<TenderResponse>
    {
        TenderResponse CreateResponseFromTender(Tender tender);
        void UpdateByTenderId(TenderResponse tenderResponse);
    }
}
