using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Pharmacy_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MedicineController : ControllerBase
    {
        [HttpPost("medicineExistsInQuantity")]
        public IActionResult MedicineExistsInQuantity(int medicineId, int quantity)
        {
            //call to service
            return Ok(true);
        }
    }
}
