using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using Xunit;

namespace PharmacyTests
{
    public class FileCompessionTests
    {
        [Fact]
        public void Checks_if_directory_exists()
        {
            string path = GetPath();

            DirectoryInfo d = new DirectoryInfo(@path);

            Assert.True(d.Exists);
        }

        [Fact]
        public void Checks_if_directory_has_files()
        {
            string path = GetPath();

            DirectoryInfo d = new DirectoryInfo(@path);

            FileInfo[] files = d.GetFiles();

            Assert.NotEmpty(files);
        }

        private string GetPath()
        {
            string folderName = Path.Combine("Pharmacy API");
            string rootDirectory = Directory.GetParent(Directory.GetParent(Directory.GetParent(Directory.GetParent(Directory.GetCurrentDirectory()).FullName).FullName).FullName).FullName;
            string path = Path.Combine(rootDirectory, folderName);

            return path;
        }
    }
}
