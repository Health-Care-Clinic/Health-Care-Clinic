using Integration;
using Integration.Interface.Service;
using Microsoft.AspNetCore.Mvc;
using RestSharp;

namespace Integration_API.Controller.Pharmacy
{
    [Route("api/[controller]")]
    [ApiController]
    public class MedicineController : ControllerBase
    {
        private readonly IntegrationDbContext _dbContext;
        private readonly IMedicineService _medicineService;

        public MedicineController(IntegrationDbContext integrationDbContext, IMedicineService medicineService)
        {
            _dbContext = integrationDbContext;
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
