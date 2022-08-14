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

            ConsumptionReportServiceTest serviceTest = new ConsumptionReportServiceTest();

            serviceTest.DoesFileExist(consumptionReport.Object).ShouldNotBe(false);
            // Resenje testa
            // File.Exists(consumptionReport.Object.UploadFile()).ShouldNotBe(false);
        }

        [Fact]
        public void Upload_report_unsuccessfully()
        {
            Mock<IConsumptionReport> consumptionReport = new Mock<IConsumptionReport>();
            consumptionReport.Setup(r => r.UploadFile())
                .Returns(ServerCredentialsDTO.GetInstance().ServerFolder + Path.DirectorySeparatorChar + "medicaments.html");

            ConsumptionReportServiceTest serviceTest = new ConsumptionReportServiceTest();

            serviceTest.DoesFileExist(consumptionReport.Object).ShouldNotBe(true);
            // Resenje testa
            // File.Exists(consumptionReport.Object.UploadFile()).ShouldNotBe(false);
        }
    }
}
