namespace ClinicCore.Storages
{
    public interface IStorageFactory<T> where T:class
    {
        T GetStorage();
    }
}
