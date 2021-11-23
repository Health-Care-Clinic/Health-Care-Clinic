using Hospital.Mapper;
using Hospital.Rooms_and_equipment.Repository;
using Hospital.Rooms_and_equipment.Service;
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
    public class EquipmentController : ControllerBase
    {


        private EquipmentService equipmentService;
        public EquipmentController(HospitalDbContext context)
        {
            EquipmentRepository equipmentRepository = new EquipmentRepository(context);
            equipmentService = new EquipmentService(equipmentRepository);
        }

        [HttpGet("getEquipmentByRoomId/{id?}")]
        public IActionResult GetEquipmentByRoomId(int id)
        {
            List<EquipmentDTO> allEquipment = new List<EquipmentDTO>();
            equipmentService.GetEquipmentByRoomId(id).ForEach(Equipment
                => allEquipment.Add(EquipmentAdapter.EquipmentToEquipmentDTO(Equipment)));
            return Ok(allEquipment);
        }

        [HttpGet("getEquipmentByName/{name?}")]
        public IActionResult GetEquipmentByName(string name)
        {
            List<EquipmentDTO> allEquipment = new List<EquipmentDTO>();
            equipmentService.GetEquipmentByName(name).ForEach(Equipment
                => allEquipment.Add(EquipmentAdapter.EquipmentToEquipmentDTO(Equipment)));
            return Ok(allEquipment);
        }
    }

}
