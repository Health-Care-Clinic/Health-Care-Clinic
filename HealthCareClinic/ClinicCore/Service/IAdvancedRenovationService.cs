using Model;

namespace ClinicCore.Service
{
    public interface IAdvancedRenovationService
    {
        void ExecuteAdvancedRoomRenovation(AdvancedRenovation advancedRenovation);
        void MakeAdvancedRenovation(AdvancedRenovation advancedRenovation);
    }
}
