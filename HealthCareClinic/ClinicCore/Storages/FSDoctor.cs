using Model;

namespace ClinicCore.Storages
{
    public class FSDoctor : GenericFileStorage<Doctor>
    {
        public FSDoctor()
        {
            this.fileLocation = "../../../FileStorage/doctors.json";
        }

      
    }
}
