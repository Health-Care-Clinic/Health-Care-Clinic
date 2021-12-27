using Hospital.Shared_model.Service;
using Hospital_API.Adapter;
using Hospital_API.DTO;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Hospital_API.Controller
{
    [Route("api/[controller]")]
    [ApiController]
    public class OnCallShiftController : ControllerBase
    {
        private readonly IOnCallShiftService onCallShiftService;
        public OnCallShiftController(IOnCallShiftService onCallShiftService)
        {
            this.onCallShiftService = onCallShiftService;
        }

        [HttpGet("getOnCallShiftByDoctorId/{id?}")]
        public IActionResult GetOnCallShiftByDoctorId(int id)
        {
            List<OnCallShiftDTO> allOnCallShifts = new List<OnCallShiftDTO>();
            onCallShiftService.GetOnCallShiftByDoctorId(id).ForEach(OnCallShift
                => allOnCallShifts.Add(OnCallShiftAdapter.OnCallShiftToOnCallShiftDTO(OnCallShift)));
            return Ok(allOnCallShifts);
        }
    }
}
