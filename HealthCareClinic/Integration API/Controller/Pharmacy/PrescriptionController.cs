using Integration.ApiKeys.Model;
using Integration.DTO;
using Integration.Interface.Service;
using Integration.Service;
using Microsoft.AspNetCore.Mvc;
using RestSharp;

namespace Integration_API.Controller.Pharmacy
{
    [Route("hospital/[controller]")]
    [ApiController]
    public class PrescriptionController : ControllerBase
    {
        private readonly IApiKeyService _apiKeyService;
        private readonly IPrescriptionService _prescriptionService;
        private FileTransferService fileTransferService;

        public PrescriptionController(IApiKeyService apiKeyService, IPrescriptionService prescriptionService)
        {
            _apiKeyService = apiKeyService;
            _prescriptionService = prescriptionService;
            fileTransferService = new FileTransferService();
        }

        [HttpPost]
        public IActionResult CheckIfMedicineExists(PrescriptionDTO prescriptionDto)
        {
            ApiKey apiKey = _apiKeyService.GetApiKeyByName(prescriptionDto.Pharmacy);
            string url = $"{this.Request.Scheme}://{this.Request.Host}{this.Request.PathBase}";
            ApiKey myApiKey = _apiKeyService.GetMyApiKey(url);

            _prescriptionService.CreatePrescriptionFile(prescriptionDto);

            var client = new RestClient(apiKey.BaseUrl);
            var request = new RestRequest("benu/prescription/doesExist");
            request.AddQueryParameter("medicineName", prescriptionDto.Medicine);
            request.AddQueryParameter("quantity", prescriptionDto.Amount.ToString());
            request.AddHeader("ApiKey", myApiKey.Key);
            IRestResponse response = client.Get(request);
            
            return Ok("Successfully sent");
        }

        [HttpPost("qr")]
        public IActionResult CheckIfMedicineExistsQr(PrescriptionDTO prescriptionDto)
        {
            ApiKey apiKey = _apiKeyService.GetApiKeyByName(prescriptionDto.Pharmacy);
            string url = $"{this.Request.Scheme}://{this.Request.Host}{this.Request.PathBase}";
            ApiKey myApiKey = _apiKeyService.GetMyApiKey(url);

            _prescriptionService.GetPrescriptionQr(prescriptionDto);

            var client = new RestClient(apiKey.BaseUrl);
            var request = new RestRequest("benu/prescription/doesExistQr");
            request.AddQueryParameter("medicineName", prescriptionDto.Medicine);
            request.AddQueryParameter("quantity", prescriptionDto.Amount.ToString());
            request.AddHeader("ApiKey", myApiKey.Key);
            IRestResponse response = client.Get(request);

            return Ok("Successfully sent");
        }



        [HttpGet("upload")]
        public IActionResult UploadPrescription(string response)
        {
            if (response.Equals("yes"))
            {
                fileTransferService.UploadFile("prescription");
            }

            return Ok();
        }

        [HttpGet("uploadQr")]
        public IActionResult UploadPrescriptionQr(string response)
        {
            if (response.Equals("yes"))
            {
                _prescriptionService.GetPrescriptionPdf();
            }

            return Ok();
        }
    }
}
