namespace Integration.Service.TestServices
{
    public class ApiKeyServiceTest
    {
        public int GetNumberOfApiKeys(IMyDbContext myDbContext)
        {
            return myDbContext.GetApiKeys().Count;
        }
    }
}
