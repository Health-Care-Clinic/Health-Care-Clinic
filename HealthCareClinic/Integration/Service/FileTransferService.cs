using System;
using System.IO;
using Integration.DTO;
using Renci.SshNet;

namespace Integration.Service
{
    public class FileTransferService
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

        public void CreateTxtFile(string path, string content)
        {
            if (!File.Exists(path))
            {
                File.Create(path).Dispose();
                using (TextWriter textWriter = new StreamWriter(path))
                {
                    textWriter.WriteLine(content);
                }
            }
            else
            {
                using (TextWriter textWriter = new StreamWriter(path))
                {
                    textWriter.WriteLine(content);
                }
            }
        }
    }
}
