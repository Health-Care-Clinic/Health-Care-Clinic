using Integration;
using Integration.Interface.Service;
using Microsoft.AspNetCore.Mvc;

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
            _medicineService.AddMedicine(medicineName, quantity);
            return Ok("successfully sent");
        }
    }
}
