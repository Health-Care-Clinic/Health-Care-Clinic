using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using Integration.DTO;
using Integration.Service.TestServices;
using Moq;
using Shouldly;
using Xunit;

namespace IntegrationTests.UnitTests
{
    public class MedicamentConsumptionTests
    {
        [Fact]
        public void Upload_report_successfully()
        {
            Mock<IConsumptionReport> consumptionReport = new Mock<IConsumptionReport>();
            consumptionReport.Setup(r => r.UploadFile()).Returns("ftpsettings.json");

            var uploadedFile = consumptionReport.Object.UploadFile();

            File.Exists(uploadedFile).ShouldBeTrue();
        }

        [Fact]
        public void Upload_report_unsuccessfully()
        {
            Mock<IConsumptionReport> consumptionReport = new Mock<IConsumptionReport>();
            consumptionReport.Setup(r => r.UploadFile())
                .Returns(ServerCredentialsDTO.GetInstance().ServerFolder + Path.DirectorySeparatorChar + "medicaments.html");

            var uploadedFile = consumptionReport.Object.UploadFile();

            File.Exists(uploadedFile).ShouldBeFalse();
        }
    }
}
