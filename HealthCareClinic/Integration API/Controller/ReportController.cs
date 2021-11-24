using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Integration.DTO;
using Integration.Interface.Service;
using Integration.Service;
using Microsoft.AspNetCore.Mvc;

namespace Integration_API.Controller
{
    [Route("hospital/[controller]")]
    public class ReportController : ControllerBase
    {
        private readonly FileTransferService _fileTransferService;
        private readonly IMedConsumptionService _medConsumptionService;

        public ReportController(IMedConsumptionService medConsumptionService)
        {
            _medConsumptionService = medConsumptionService;
            this._fileTransferService = new FileTransferService();
        }

        [HttpPost("ftp/{fileName}")]
        public IActionResult UploadFile(String fileName)
        {
            _fileTransferService.UploadFile(fileName);
            return Ok();
        }

        [HttpGet("ftp/{fileName}")]
        public IActionResult DownloadFile(String fileName)
        {
            _fileTransferService.DownloadFile(fileName);
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
