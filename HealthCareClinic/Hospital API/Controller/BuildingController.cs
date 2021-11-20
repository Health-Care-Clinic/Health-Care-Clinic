using Hospital.Mapper;
using Hospital.Rooms_and_equipment.Model;
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
    public class BuildingController : ControllerBase
    {

        private BuildingService buildingService;
        public BuildingController(HospitalDbContext context)
        {
            BuildingRepository buildingRepository = new BuildingRepository(context);
            buildingService = new BuildingService(buildingRepository);
        }


        [HttpGet("getBuildings")]
        public IActionResult GetBuildings()
        {
            List<BuildingDTO> allBuildings = new List<BuildingDTO>();
            buildingService.GetAll().ToList().ForEach(Building
                => allBuildings.Add(BuildingAdapter.BuildingToBuildingDTO(Building)));
            return Ok(allBuildings);
        }

        [HttpGet("getBuildingById/{id?}")]
        public IActionResult GetBuildingById(int id)
        {
            return Ok(BuildingAdapter.BuildingToBuildingDTO(buildingService.GetOneById(id)));
        }

        [HttpPut("changeBuildingName")]
        public IActionResult ChangeBuildingName(BuildingDTO buildingDTO)
        {
            Building building = BuildingAdapter.BuildingDTOToBuilding(buildingDTO);
            buildingService.Change(building);
            return Ok();
        }

        [HttpGet("getSearchedBuildings/{searchText?}")]
        public IActionResult GetSearchedBuildings(String searchText)
        {
            List<BuildingDTO> result = new List<BuildingDTO>();
            if (searchText != null)
                buildingService.GetSearchedBuildings(searchText).ForEach(building
                    => result.Add(BuildingAdapter.BuildingToBuildingDTO(building)));
            return Ok(result);
        }
    }

}
