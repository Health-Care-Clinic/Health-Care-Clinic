
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
    public class RoomController : ControllerBase
    {
        private RoomService roomService;
        public RoomController(HospitalDbContext context)
        {
            RoomRepository roomRepository = new RoomRepository(context);
            roomService = new RoomService(roomRepository);
        }

        [HttpGet("getRoomsByFloorId/{id?}")]
        public IActionResult GetRoomsByFloorId(int id)
        {
            List<RoomDTO> allRooms = new List<RoomDTO>();
            roomService.GetRoomsByFloorId(id).ForEach(Room
                => allRooms.Add(RoomAdapter.RoomToRoomDTO(Room)));
            return Ok(allRooms);
        }

        [HttpGet("getRoomById/{id?}")]
        public IActionResult GetRoomById(int id)
        {
            return Ok(RoomAdapter.RoomToRoomDTO(roomService.GetOneById(id)));
        }

        [HttpGet("getRooms")]
        public IActionResult GetRooms()
        {
            List<RoomDTO> allRooms = new List<RoomDTO>();
            roomService.GetAll().ToList().ForEach(Room
                => allRooms.Add(RoomAdapter.RoomToRoomDTO(Room)));
            return Ok(allRooms);
        }
    }

}
