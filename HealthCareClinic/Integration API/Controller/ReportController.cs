using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Integration_API.Service;
using Microsoft.AspNetCore.Mvc;

namespace Integration_API.Controller
{
    [Route("hospital/[controller]")]
    public class ReportController : ControllerBase
    {
        private readonly ReportService reportService;

        public ReportController()
        {
            this.reportService = new ReportService();
        }

        [HttpPost("ftp/{fileName}")]
        public IActionResult UploadFile(String fileName)
        {
            reportService.UploadFile(fileName);
            return Ok();
        }

        [HttpGet("ftp/{fileName}")]
        public IActionResult DownloadFile(String fileName)
        {
            reportService.DownloadFile(fileName);
            return Ok();
        }
    }
}
