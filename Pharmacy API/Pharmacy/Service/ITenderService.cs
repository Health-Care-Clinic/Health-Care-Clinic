using Pharmacy.Model;
using System;
using System.Collections.Generic;
using System.Text;

namespace Pharmacy.Service
{
    public interface ITenderService: IService<Tender>
    {
        public Tender GetDataForTender(Tender tender);
    }
}
