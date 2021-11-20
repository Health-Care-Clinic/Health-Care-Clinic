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
    public class FloorController : ControllerBase
    {
        private FloorService floorService;
        public FloorController(HospitalDbContext context)
        {
            FloorRepository floorRepository = new FloorRepository(context);
            floorService = new FloorService(floorRepository);
        }

        [HttpGet("getFloorsByBuildingId/{id?}")]
        public IActionResult GetFloorsByBuildingId(int id)
        {
            List<FloorDTO> allFloors = new List<FloorDTO>();
            floorService.GetFloorsByBuildingId(id).ForEach(Floor
                => allFloors.Add(FloorAdapter.FloorToFloorDTO(Floor)));
            return Ok(allFloors);
        }

        [HttpGet("getFloorById/{id?}")]
        public IActionResult GetFloorById(int id)
        {
            return Ok(FloorAdapter.FloorToFloorDTO(floorService.GetOneById(id)));
        }

        [HttpGet("getFloors")]
        public IActionResult GetFloors()
        {
            List<FloorDTO> allFloors = new List<FloorDTO>();
            floorService.GetAll().ToList().ForEach(Floor
                => allFloors.Add(FloorAdapter.FloorToFloorDTO(Floor)));
            return Ok(allFloors);
        }

    }

}