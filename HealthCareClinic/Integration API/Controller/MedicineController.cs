using Integration;
using Integration.Interface.Service;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
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
