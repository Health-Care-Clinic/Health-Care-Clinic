using System;
using System.Collections.Generic;
using System.IO;
using System.Threading;
using Ionic.Zip;

namespace Pharmacy.Service
{
    public class FileCompressionService
    {
        private static readonly int sixMonthsInHours = 6 * 30 * 24;
        private static readonly int sixMonthsInDays = 6 * 30;

        public static void CompressFiles()
        {
            string path = "..\\..\\Pharmacy API\\Pharmacy API\\MedSpecifications\\";

            while(true)
            {
                DirectoryInfo d = new DirectoryInfo(@path);

                FileInfo[] files = d.GetFiles();
                List<FileInfo> filesToCompress = new List<FileInfo>();

                GetFilesToCompress(files, filesToCompress);

                AddFilesToArchive(path, filesToCompress);

                RemoveCompressedFiles(filesToCompress);

                TimeSpan oldFilesLimit = new TimeSpan(sixMonthsInHours, 0, 0);
                Thread.Sleep(oldFilesLimit);
            }
        }

        private static void RemoveCompressedFiles(List<FileInfo> filesToCompress)
        {
            foreach (FileInfo fi in filesToCompress)
            {
                File.Delete(fi.FullName);
            }
        }

        private static void AddFilesToArchive(string path, List<FileInfo> filesToCompress)
        {
            using (ZipFile zip = new ZipFile())
            {
                if (filesToCompress.Count == 0)
                {
                    return;
                }

                foreach (FileInfo fi in filesToCompress)
                {
                    zip.AddFile(fi.FullName, "Old data");
                }

                string zipPath = path + DateTime.Now.Year + "-" + DateTime.Now.Month + "-" + DateTime.Now.Day + "-" +
                    DateTime.Now.Hour + "-" + DateTime.Now.Minute + "-" + DateTime.Now.Second + "-" + DateTime.Now.Millisecond + ".zip";
                zip.Save(zipPath);
            }
        }

        private static void GetFilesToCompress(FileInfo[] files, List<FileInfo> filesToCompress)
        {
            foreach (FileInfo file in files)
            {
                if (file.CreationTime < DateTime.Now.AddDays(-sixMonthsInDays) && file.Extension != ".zip")
                {
                    filesToCompress.Add(file);
                }
            }
        }
    }
}
