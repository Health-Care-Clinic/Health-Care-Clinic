using Microsoft.AspNetCore.Mvc;
using Pharmacy.Service;
using Pharmacy_API.Adapter;
using Pharmacy_API.DTO;


namespace Pharmacy_API.Controllers
{
    [ApiController]
    [Route("benu/[controller]")]
    public class TenderController: ControllerBase
    {
        private readonly ITenderService _tenderService;
       
        public TenderController(ITenderService tenderService)
        {
            _tenderService = tenderService;
          
        }

        [HttpPost]
        public IActionResult HospitalTenderRequest(TenderRequestDTO tenderRequestDTO)
        {
            TenderResponseDTO tenderResponseDTO = TenderAdapter.TenderToTenderResponse(_tenderService.GetDataForTender(TenderAdapter.TenderRequestDTOToTender(tenderRequestDTO)));
            return Ok(tenderResponseDTO);
        }
    }
}
