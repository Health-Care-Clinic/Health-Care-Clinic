using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using iTextSharp.text;
using Microsoft.AspNetCore.Mvc;
using Pharmacy.Model;
using Pharmacy.Service;
using RestSharp;

namespace Pharmacy_API.Controllers
{
    [Route("benu/[controller]")]
    [ApiController]
    public class PrescriptionController : ControllerBase
    {
        private readonly IMedicineService _medicineService;
        private readonly IApiKeyService _apiKeyService;

        public PrescriptionController(IMedicineService medicineService, IApiKeyService apiKeyService)
        {
            _medicineService = medicineService;
            _apiKeyService = apiKeyService;
        }

        [HttpGet("doesExist")]
        public IActionResult CheckIfExists(string medicineName, string quantity)
        {
            if (!Request.Headers.TryGetValue("ApiKey", out var headerApiKey))
            {
                return BadRequest("Api key was not provided!");
            }

            ApiKey apiKey = _apiKeyService.GetByKey(headerApiKey);

            if (apiKey.Name == null)
            {
                return BadRequest("Api key is not valid!");
            }

            string response = "";
            if (_medicineService.MedicineExistsInQuantity(medicineName, Int32.Parse(quantity)))
            {
                response = "yes";
            }
            else
            {
                response = "no";
            }

            var client = new RestSharp.RestClient(apiKey.BaseUrl);
            var request = new RestRequest("hospital/prescription/upload");
            request.AddQueryParameter("response", response);
            IRestResponse restResponse = client.Get(request);

            return Ok();
        }

        [HttpGet("doesExistQr")]
        public IActionResult CheckIfExistsQr(string medicineName, string quantity)
        {
            if (!Request.Headers.TryGetValue("ApiKey", out var headerApiKey))
            {
                return BadRequest("Api key was not provided!");
            }

            ApiKey apiKey = _apiKeyService.GetByKey(headerApiKey);

            if (apiKey.Name == null)
            {
                return BadRequest("Api key is not valid!");
            }

            string response = "";
            if (_medicineService.MedicineExistsInQuantity(medicineName, Int32.Parse(quantity)))
            {
                response = "yes";
            }
            else
            {
                response = "no";
            }

            var client = new RestSharp.RestClient(apiKey.BaseUrl);
            var request = new RestRequest("hospital/prescription/uploadQr");
            request.AddQueryParameter("response", response);
            IRestResponse restResponse = client.Get(request);

            return Ok();
        }

        [HttpPost("qrPdf")]
        public IActionResult UploadQrPdf(Bitmap qr)
        {
            qr.Save("image.bmp");
            System.Drawing.Image image = System.Drawing.Image.FromFile("image.bmp");
            Document doc = new Document(PageSize.A4);
            iTextSharp.text.pdf.PdfWriter.GetInstance(doc, new FileStream("image.pdf", FileMode.Create));
            doc.Open();
            iTextSharp.text.Image pdfImage = iTextSharp.text.Image.GetInstance(qr, System.Drawing.Imaging.ImageFormat.Bmp);
            doc.Add(pdfImage);
            doc.Close();

            return Ok();
        }

    }
}
