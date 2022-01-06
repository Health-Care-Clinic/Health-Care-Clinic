using Pharmacy.Tendering.Model;

namespace Pharmacy.Interfaces.Service
{
    public interface ITenderService: IService<Tender>
    {
        public TenderResponse GetDataForTender(Tender tender);
    }
}
