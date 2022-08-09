using Model;

namespace ClinicCore.Storages
{
    public class PatientFileStorage : GenericFileStorage<Patient>
    {
        public PatientFileStorage()
        {
            this.fileLocation = "../../../FileStorage/patients.json";
        }

     
    }
}
