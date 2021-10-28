using Storages;

namespace ClinicCore.Storages
{
    public class AppointmentFileStorageFactory : IStorageFactory<AppointmentFileStorage>
    {
        public AppointmentFileStorageFactory()
        {
        }

        public AppointmentFileStorage GetStorage()
        {
            return new AppointmentFileStorage();
        }
    }
}
