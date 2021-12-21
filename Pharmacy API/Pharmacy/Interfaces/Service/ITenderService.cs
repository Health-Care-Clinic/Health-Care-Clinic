using Pharmacy.Tendering.Model;

namespace Pharmacy.Interfaces.Service
{
    public interface ITenderService: IService<Tender>
    {
        public Tender GetDataForTender(Tender tender);
    }
}
