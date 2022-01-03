using Hospital.Shared_model.Model;
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

        [HttpGet("getFreeDatesForOnCallShift/{month?}")]
        public IActionResult GetFreeDaysForOnCallShifts(int month) 
        {
            List<DateTime> freeDates = onCallShiftService.GetFreeDates(month);
            return Ok(freeDates);
        }

        [HttpPost("addNewOnCallShift")]
        public IActionResult AddNewOnCallShift(OnCallShiftDTO onCallShiftDTO )
        {
            OnCallShift onCallShift = OnCallShiftAdapter.OnCallShiftDTOToOnCallShift(onCallShiftDTO);
            onCallShift.Id = onCallShiftService.returnKey();
            onCallShiftService.Add(onCallShift);
            return Ok();
        }

        [HttpGet("getNumOfOnCallShift/{id?}/{month?}/{year?}")]
        public IActionResult GetNumOfOnCallShift(int id, int month, int year)
        {
            return Ok(onCallShiftService.GetNumOfOnCallShift(id, month, year));
        }
    }
}
