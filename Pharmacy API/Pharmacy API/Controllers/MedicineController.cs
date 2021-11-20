using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Pharmacy;
using Pharmacy.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Pharmacy.Service;
using System.Xml.Linq;

namespace Pharmacy_API.Controllers
{
    [ApiController]
    [Route("benu/[controller]")]
    public class MedicineController : Controller
    {
        private readonly IMedicineService medicineService;

        public MedicineController(IMedicineService medicineService)
        {
            this.medicineService = medicineService;
        }

        [HttpGet]
        public IActionResult SearchMedicine()
        {
            try
            {
                string name = HttpContext.Request.Query["name"].ToString().ToLower();
                string manufacturer = HttpContext.Request.Query["manufacturer"].ToString().ToLower();
                string weight = HttpContext.Request.Query["weight"].ToString().ToLower();
                int weightInt = 0;
                if(weight != "")
                {
                    weightInt = int.Parse(weight);
                }

                List<Medicine> medicines = medicineService.SearchMedicine(name, manufacturer, weightInt).ToList();

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
                int requestedQuantity = int.Parse(HttpContext.Request.Query["requestedQuantity"].ToString());
                bool result = medicineService.CheckMedicineQuantity(id, requestedQuantity);

                return Ok(result);
            }
            catch
            {
                return BadRequest();
            }
        }
    }
}
