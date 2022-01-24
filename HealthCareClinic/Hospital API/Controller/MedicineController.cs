using Hospital.Medicines.Service;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using RestSharp;

namespace Hospital_API.Controller
{
    [Route("api/[controller]")]
    [ApiController]
    public class MedicineController : ControllerBase
    {
        private readonly IMedicineService _medicineService;
        public MedicineController(IMedicineService medicineService)
        {
            _medicineService = medicineService;
        }

        [HttpPost("add")]
        public IActionResult AddMedicine(string medicineName, string quantity)
        {
            _medicineService.AddMedicine(medicineName, quantity);
            return Ok();
        }

        [HttpPost("allPharmacyPromotions")]
        public IActionResult GetAllPharmacyPromotions()
        {
            var restClient = new RestClient("http://localhost:65508");
            var request = new RestRequest("hospital/pharmacyPromotion/active");
            IRestResponse restResponse = restClient.Get(request);

            


            return Ok(restResponse.Content);
        }

        
    }
}
