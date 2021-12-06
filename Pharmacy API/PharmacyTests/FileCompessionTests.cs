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
            string path = "..\\..\\..\\..\\Pharmacy API\\MedSpecifications\\";

            DirectoryInfo d = new DirectoryInfo(@path);

            Assert.True(d.Exists);
        }

        [Fact]
        public void Checks_if_directory_has_files()
        {
            string path = "..\\..\\..\\..\\Pharmacy API\\MedSpecifications\\";

            DirectoryInfo d = new DirectoryInfo(@path);

            FileInfo[] files = d.GetFiles();

            Assert.Equal(3, files.Length);
        }
    }
}
