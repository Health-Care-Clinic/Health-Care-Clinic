using Hospital.Mapper;
using Hospital.Shared_model.Model;
using Hospital.Shared_model.Repository;
using Hospital.Shared_model.Service;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Hospital_API.Controller
{
    [Route("api/[controller]")]
    [ApiController]
    public class PatientRegistrationController : ControllerBase
    {
        private AllergenService _allergenService;

        public PatientRegistrationController(HospitalDbContext context)
        {
            AllergenRepository allergenRepository = new AllergenRepository(context);
            _allergenService = new AllergenService(allergenRepository);
        }

        [HttpGet("getAllAllergens")]       // GET /api/allergen
        public IActionResult GetAllAllergens()
        {
            List<Allergen> result = (List<Allergen>) _allergenService.GetAll();

            return Ok(result);
        }
    }
}
