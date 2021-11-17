using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Pharmacy;
using Pharmacy.Model;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Pharmacy.Service;
using System.Xml.Linq;
using Pharmacy_API.DTO;
using Pharmacy_API.Adapter;
using System.Diagnostics;



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


        [HttpPut("update/{id?}")]
        public IActionResult UpdateMedicine(int id, MedicineDTO medicineDTO)
        {

            Medicine medicine = MedicineAdapter.MedicineDTOToMedicine(medicineDTO);
            bool isUpdated = this.medicineService.Update(id, medicine);
           
            return Ok(isUpdated);
          
        }

        [HttpPut("lowerQuantity/{id?}")]
        public IActionResult LowerMedicineQuantity(int id)
        {
            int quantity = int.Parse(HttpContext.Request.Query["quantity"].ToString());
            bool isLowered = this.medicineService.LowerMedicineQuantity(id, quantity);
            return Ok(isLowered);
        }

        [HttpPut("raiseQuantity/{id?}")]
        public IActionResult RaiseMedicineQuantity(int id)
        {
            int quantity = int.Parse(HttpContext.Request.Query["quantity"].ToString());
            bool isRaised = this.medicineService.RaiseMedicineQuantity(id, quantity);
            return Ok(isRaised);
        }


    }
}
