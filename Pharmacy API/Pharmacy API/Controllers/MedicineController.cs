using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Pharmacy;
using Pharmacy.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Pharmacy_API.Controllers
{
    [ApiController]
    [Route("benu/[controller]")]
    public class MedicineController : Controller
    {
        private readonly PharmacyDbContext _dbContext;

        public MedicineController(PharmacyDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        [HttpGet]
        public IActionResult SearchMedicine()
        {
            try
            {
                string name = HttpContext.Request.Query["name"].ToString().ToLower();
                string manufacturer = HttpContext.Request.Query["manufacturer"].ToString().ToLower();
                string weight = HttpContext.Request.Query["weight"].ToString().ToLower();
                int waightInt = 0;
                if (!weight.Equals(""))
                {
                    waightInt = int.Parse(weight);
                }
                string usage = HttpContext.Request.Query["usage"].ToString().ToLower();

                List<Medicine> medicines = _dbContext.Medicines.Where(medicine => medicine.Name.ToLower().Contains(name) && 
                                                                      medicine.Manufacturer.ToLower().Contains(manufacturer) &&
                                                                      medicine.Weight >= waightInt &&
                                                                      medicine.Usage.ToLower().Contains(usage)).ToList();


                return Ok(medicines);
            }
            catch
            {
                return BadRequest();
            }
        }


        [HttpGet("{id?}")]
        public IActionResult MedicineQuantityQuery(int id)
        {
            try
            {
                bool result = false;
                int requestedQuantity = int.Parse(HttpContext.Request.Query["requestedQuantity"].ToString());
                List<Medicine> medicines = _dbContext.Medicines.Where(medicine => medicine.Id == id &&
                                                                      medicine.Quantity >= requestedQuantity).ToList();

                if (medicines.Count() > 0)
                {
                    result = true;
                }

                return Ok(result);
            }
            catch
            {
                return BadRequest();
            }
        }
    }
}
