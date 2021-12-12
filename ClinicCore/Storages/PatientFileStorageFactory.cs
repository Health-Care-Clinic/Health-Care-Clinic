namespace ClinicCore.Storages
{
    public class PatientFileStorageFactory : IStorageFactory<PatientFileStorage>
    {
        public PatientFileStorageFactory()
        {
        }

        public PatientFileStorage GetStorage()
        {
            return new PatientFileStorage(); 
        }
    }
}
