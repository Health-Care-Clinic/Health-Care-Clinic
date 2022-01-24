using Microsoft.AspNetCore.Mvc;
using Pharmacy.Adapter;
using Pharmacy.Advertisements.Model;
using Pharmacy.DTO;
using Pharmacy.Interfaces.Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Pharmacy_API.Controllers.Advertisements
{
   
    [ApiController]
    [Route("benu/[controller]")]
    public class AdvertisementController : ControllerBase
    {
        private readonly IAdvertisementService _advertisementService;

        public AdvertisementController(IAdvertisementService advertisementService)
        {
            _advertisementService = advertisementService;
        }

        [HttpPost("add")]
        public IActionResult AddAdvertisememt(AdvertisementDTO dto)
        {
            Advertisement advertisement = AdvertisementAdapter.AdvertisementDTOToAdvertisement(dto);
            _advertisementService.AddEntitity(advertisement, (List<int>)dto.AdvertisementMedicines);

            return Ok("success");
        }

        [HttpDelete("delete/{id?}")]
        public IActionResult RemoveAdvertisementById(int id)
        {
            _advertisementService.RemoveEntity(id);
            return Ok("success");
        }
    }
}
