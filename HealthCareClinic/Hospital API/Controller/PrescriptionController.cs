using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Hospital.Medical_records.Service;
using Hospital_API.Adapter;
using Hospital_API.DTO;
using Microsoft.AspNetCore.Mvc;
using RestSharp;

namespace Hospital_API.Controller
{
    [Route("api/[controller]")]
    [ApiController]
    public class PrescriptionController : ControllerBase
    {
        private readonly IPrescriptionService _prescriptionService;

        public PrescriptionController(IPrescriptionService prescriptionService)
        {
            _prescriptionService = prescriptionService;
        }

        [HttpPost]
        public IActionResult SendPrescription(PrescriptionDTO prescriptionDto)
        {
            _prescriptionService.Add(PrescriptionAdadpter.PrescriptionDTOToPrescription(prescriptionDto));

            var client = new RestClient("http://localhost:65508");
            var request = new RestRequest("hospital/prescription");
            request.AddJsonBody(prescriptionDto);
            IRestResponse response = client.Post(request);

            return Ok("Successfully sent!");
        }
    }
}
