using Integration;
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

        public MedicineController(IntegrationDbContext integrationDbContext)
        {
            _dbContext = integrationDbContext;
        }

        [HttpGet("addMedicine")]
        public IActionResult AddMedicine(string medicineName, int quantity)
        {
            foreach (var medicine in _dbContext.Medicines.ToList())
            {
                if(medicine.Name.Equals(medicineName))
                {
                    medicine.Quantity += quantity;
                    _dbContext.Medicines.Update(medicine);
                    _dbContext.SaveChanges();
                    return Ok("successfully sent");
                }
            }

            _dbContext.Medicines.Add(new Integration.Model.Medicine(medicineName, quantity));
            _dbContext.SaveChanges();
            return Ok("successfully sent");
        }
    }
}
