using System;
using Integration.Interface.Service;
using Integration.Service;
using Microsoft.AspNetCore.Mvc;

namespace Integration_API.Controller.Pharmacy
{
    [Route("hospital/[controller]")]
    public class ReportController : ControllerBase
    {
        private readonly FileTransferService _fileTransferService;
        private readonly IMedConsumptionService _medConsumptionService;
        private readonly INotificationService _notificationService;
        

        public ReportController(IMedConsumptionService medConsumptionService, INotificationService notificationService)
        {
            _medConsumptionService = medConsumptionService;
            _notificationService = notificationService;
            this._fileTransferService = new FileTransferService();
        }

        [HttpPost("ftp/{fileName}")]
        public IActionResult UploadFile(String fileName)
        {
            _fileTransferService.UploadFile(fileName);
            return Ok();
        }

        [HttpGet("ftp")]
        public IActionResult DownloadFile(String fileName)
        {
            _fileTransferService.DownloadFile(fileName);
            _notificationService.CreateNewFileNotification(fileName + ".pdf");
            return Ok();
        }

        [HttpGet("generate")]
        public IActionResult GenerateMedConsumptionReport(string start, string end)
        {
            _medConsumptionService.GenerateConsumptionReport(start, end);
            return Ok("Successfully generated!");
        }
    }
}
