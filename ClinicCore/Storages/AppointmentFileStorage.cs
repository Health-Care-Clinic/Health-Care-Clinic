using ClinicCore.Storages;
using Model;

namespace Storages
{
    public class AppointmentFileStorage : GenericFileStorage<DoctorAppointment>
    {
        public AppointmentFileStorage()
        {
            this.fileLocation = "../../../FileStorage/appointments.json";
        }
    }
}