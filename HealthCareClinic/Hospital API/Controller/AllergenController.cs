using Hospital.Mapper;
using Hospital.Shared_model.Model;
using Hospital.Shared_model.Repository;
using Hospital.Shared_model.Service;
using Hospital_API.Adapter;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Hospital_API.Controller
{
    [Authorize(Roles = "patient")]
    [Route("api/[controller]")]
    [ApiController]
    public class AllergenController : ControllerBase
    {
        private readonly IAllergenService _allergenService;

        public AllergenController(IAllergenService allergenService)
        {
            _allergenService = allergenService;
        }

        [HttpGet]       // GET /api/allergen
        public IActionResult GetAllAllergens()
        {
            List<Allergen> result = (List<Allergen>) _allergenService.GetAll();

            return Ok(AllergenAdapter.AllergenListToDtoList(result));
        }
    }
}
