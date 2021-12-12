using Integration.Interface.Service;
using Integration.Pharmacy.Model;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Integration.Promotions.Model;

namespace Integration_API.Controller
{
    [Route("hospital/[controller]")]
    [ApiController]
    public class PharmacyPromotionController : ControllerBase
    {
        private readonly IPharmacyPromotionService _pharmacyPromotionService;
        public PharmacyPromotionController(IPharmacyPromotionService pharmacyPromotionService)
        {
            _pharmacyPromotionService = pharmacyPromotionService;
        }

        [HttpGet]
        public IActionResult Get()
        {
            List<PharmacyPromotion> pharmacyPromotions = (List<PharmacyPromotion>)_pharmacyPromotionService.GetAll();
            return Ok(pharmacyPromotions);
        }


        [HttpPut("{id?}")]
        public IActionResult PostOrRemovePromotion(int id)
        {
            PharmacyPromotion pharmacyPromotion = _pharmacyPromotionService.GetOneById(id);
            if (pharmacyPromotion == null)
            {
                return NotFound();
            }

            _pharmacyPromotionService.Remove(pharmacyPromotion);
            _pharmacyPromotionService.SaveChanges();

            pharmacyPromotion.Posted = !pharmacyPromotion.Posted;

            _pharmacyPromotionService.Add(pharmacyPromotion);
            _pharmacyPromotionService.SaveChanges();

            return Ok();
        }
    }
}
