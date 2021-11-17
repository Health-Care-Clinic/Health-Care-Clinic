using ClinicCore.Model;

using Hospital.Mapper;
using Hospital.Rooms_and_equipment.Model;
using Hospital_API.Adapter;
using Hospital_API.DTO;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Hospital_API.Controller.HospitalMapController
{
    [Route("api/[controller]")]
    [ApiController]
    public class HospitalMapController : ControllerBase
    {
        private readonly HospitalDbContext dbContext;

        public HospitalMapController(HospitalDbContext context)
        {
            dbContext = context;
        }

        [HttpGet("getBuildings")]       
        public IActionResult GetBuildings()
        {
            List<BuildingDTO> result = new List<BuildingDTO>();
            dbContext.Buildings.ToList().ForEach(Building
                => result.Add(BuildingAdapter.BuildingToBuildingDTO(Building)));
            return Ok(result);
        }

        [HttpGet("getBuildingById/{id?}")]
        public IActionResult GetBuildingById(int id)
        {
            List<BuildingDTO> allBuildings = new List<BuildingDTO>();
            BuildingDTO result = new BuildingDTO();
            dbContext.Buildings.ToList().ForEach(Building
                => allBuildings.Add(BuildingAdapter.BuildingToBuildingDTO(Building)));
            foreach(BuildingDTO building in  allBuildings)
            {
                if (building.Id.Equals(id))
                {
                    result = building;
                    break;
                }
            }
            return Ok(result);
        }

        [HttpPut("changeBuildingName")]
        public IActionResult ChangeBuildingName(BuildingDTO buildingDTO)
        {
            Building building = BuildingAdapter.BuildingDTOToBuilding(buildingDTO);
            Building buildingChange = dbContext.Buildings.SingleOrDefault(buildingChange => buildingChange.Id == building.Id);
            if (buildingChange == null)
            {
                return NotFound();
            }
            else
            {
                buildingChange.Name = building.Name;
                dbContext.SaveChanges();
                return Ok();
            }
        }

        [HttpGet("getFloorsByBuildingId/{id?}")]
        public IActionResult GetFloorsByBuildingId(int id)
        {
            List<FloorDTO> allFloors = new List<FloorDTO>();
            List<FloorDTO> result = new List<FloorDTO>();
            dbContext.Floors.ToList().ForEach(Floor
                => allFloors.Add(FloorAdapter.FloorToFloorDTO(Floor)));
            foreach (FloorDTO floor in allFloors)
            {
                if (floor.BuildingId.Equals(id))
                {
                    result.Add(floor);
                }
            }
            return Ok(result);
        }

        [HttpGet("getRoomsByFloorId/{id?}")]
        public IActionResult GetRoomsByFloorId(int id)
        {
            List<RoomDTO> allRooms = new List<RoomDTO>();
            List<RoomDTO> result = new List<RoomDTO>();
            dbContext.Rooms.ToList().ForEach(Room
                => allRooms.Add(RoomAdapter.RoomToRoomDTO(Room)));
            foreach (RoomDTO room in allRooms)
            {
                if (room.FloorId.Equals(id))
                {
                    result.Add(room);
                }
            }
            return Ok(result);
        }

        [HttpGet("getFloors")]
        public IActionResult GetFloors()
        {
            List<FloorDTO> result = new List<FloorDTO>();
            dbContext.Floors.ToList().ForEach(Floor
                => result.Add(FloorAdapter.FloorToFloorDTO(Floor)));
            return Ok(result);
        }
        
        [HttpGet("getRooms")]
        public IActionResult GetRooms()
        {
            List<RoomDTO> result = new List<RoomDTO>();
            dbContext.Rooms.ToList().ForEach(Room
                => result.Add(RoomAdapter.RoomToRoomDTO(Room)));
            return Ok(result);
        }

    }
}
