using System;
using System.IO;
using Integration.DTO;
using Integration.Interface.Service;
using Renci.SshNet;
using SautinSoft.Document;

namespace Integration.Service
{
    public class FileTransferService
    {

        private readonly INotificationService _notificationService;
        public void UploadFile(String fileName)
        {
            var credentials = ServerCredentialsDTO.GetInstance();
            using SftpClient client =
                new SftpClient(new PasswordConnectionInfo(credentials.Ip, credentials.Username, credentials.Password));
            client.Connect();
            String sourceFile = ServerCredentialsDTO.GetInstance().SourceFolder + Path.DirectorySeparatorChar +
                                fileName + ".pdf";

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

            using (Stream fileStream = File.OpenWrite("../../ManagerApplication/ManagerApp/src/assets" + Path.DirectorySeparatorChar + fileName + ".pdf"))
            {
                 client.DownloadFile(fileName + ".pdf", fileStream);
            }

            client.Disconnect();
        }

        public void CreatePdfDocument(string content, string fileName)
        {
            DocumentCore document = new DocumentCore();
            document.Content.End.Insert(content, new CharacterFormat()
            {
                FontName = "Verdana",
                Size = 10.5f
            });
            document.Save(fileName + ".pdf");

            System.Diagnostics.Process.Start(new System.Diagnostics.ProcessStartInfo(fileName + ".pdf")
            {
                UseShellExecute = true
            });
        }
    }
}
