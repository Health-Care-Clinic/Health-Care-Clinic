using Newtonsoft.Json;

namespace Pharmacy.DTO
{
    public class ServerCredentialsDTO
    {
        public string SourceFolder { get; set; }
        public string ServerFolder { get; set; }
        public string Ip { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }

        private static readonly ServerCredentialsDTO instance = JsonConvert.DeserializeObject<ServerCredentialsDTO>(
            System.IO.File.ReadAllText("ftpsettings.json"));

        public static ServerCredentialsDTO GetInstance()
        {
            return instance;
        }
    }
}
