using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Pharmacy.Service;
using Pharmacy;
using Pharmacy.Repository;

namespace Pharmacy_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MedicineController : ControllerBase
    {
        private readonly PharmacyDbContext _dbContext;
        private MedicineService medicineService;

        public MedicineController(PharmacyDbContext dbContext)
        {
            _dbContext = dbContext;
            medicineService = new MedicineService(new MedicineRepository(dbContext));
        }

        [HttpGet("medicineExistsInQuantity")]
        public IActionResult MedicineExistsInQuantity(string medicineName, int quantity)
        {
            if (medicineService.MedicineExistInQuantity(medicineName, quantity))
            {
                return Ok(true);
            }
            else
            {
                return Ok(false);
            }
        }

        [HttpGet("reduceMedicineQuantity")]
        public IActionResult ReduceMedicineQuantity(string medicineName, int quantity)
        {
            medicineService.ReduceMedicineQuantity(medicineName, quantity);
            return Ok("success");
        }


    }
}
