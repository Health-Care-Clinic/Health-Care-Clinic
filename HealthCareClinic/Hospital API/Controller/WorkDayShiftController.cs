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
    public class WorkDayShiftController : ControllerBase
    {
        private readonly IWorkDayShiftService workDayShiftService;
        public WorkDayShiftController(IWorkDayShiftService workDayShiftService)
        {
            this.workDayShiftService = workDayShiftService;
        }

        [HttpGet("getWorkDayShifts")]
        public IActionResult GetWorkDayShifts()
        {
            List<WorkDayShiftDTO> allWorkDayShifts = new List<WorkDayShiftDTO>();
            workDayShiftService.GetAll().ToList().ForEach(WorkDayShift
                => allWorkDayShifts.Add(WorkDayShiftAdapter.WorkDayShiftToWorkDayShiftDTO(WorkDayShift)));
            return Ok(allWorkDayShifts);
        }
    }
}
