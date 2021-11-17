using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Integration_API.DTO;
using Renci.SshNet;

namespace Integration_API.Service
{
    public class ReportService
    {
        public void UploadFile(String fileName)
        {
            var credentials = ServerCredentialsDTO.GetInstance();
            using SftpClient client =
                new SftpClient(new PasswordConnectionInfo(credentials.Ip, credentials.Username, credentials.Password));
            client.Connect();
            String sourceFile = ServerCredentialsDTO.GetInstance().SourceFolder + Path.DirectorySeparatorChar +
                                fileName + ".txt";

            using (Stream stream = File.OpenRead(sourceFile))
            {
                client.UploadFile(stream, Path.GetFileName(sourceFile), x => { Console.WriteLine(x); });
            }

            client.Disconnect();
        }

        public void DownloadFile(String fileName)
        {
            var credentials = ServerCredentialsDTO.GetInstance();
            using SftpClient client =
                new SftpClient(new PasswordConnectionInfo(credentials.Ip, credentials.Username, credentials.Password));
            client.Connect();
            String sourceFile = ServerCredentialsDTO.GetInstance().ServerFolder + Path.DirectorySeparatorChar + fileName;

            using (Stream fileStream = File.OpenWrite("MedSpecifications" + Path.DirectorySeparatorChar + fileName + ".txt"))
            {
                client.DownloadFile(fileName + ".txt", fileStream);
            }
            client.Disconnect();
        }
    }
}
