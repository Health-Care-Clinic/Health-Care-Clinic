using System.IO;

namespace Integration.Service.TestServices
{
    public class ConsumptionReportServiceTest
    {
        public bool DoesFileExist(IConsumptionReport consumptionReport)
        {
            return File.Exists(consumptionReport.UploadFile());
        }
    }
}
