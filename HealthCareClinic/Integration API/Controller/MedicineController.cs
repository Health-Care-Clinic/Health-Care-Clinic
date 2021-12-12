using Integration;
using Integration.Interface.Service;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using RestSharp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Integration_API.Controller
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

        [HttpGet("addMedicine")]
        public IActionResult AddMedicine(string medicineName, int quantity)
        {
            var client = new RestClient("http://localhost:52844");
            var request = new RestRequest("api/medicine/add");
            request.AddQueryParameter("medicineName", medicineName);
            request.AddQueryParameter("quantity", quantity.ToString());
            IRestResponse response = client.Post(request);

            return Ok("successfully sent");
        }
    }
}
