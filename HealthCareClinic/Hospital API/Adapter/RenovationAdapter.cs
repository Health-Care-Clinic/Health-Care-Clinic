using Hospital.Rooms_and_equipment.Model;
using Hospital_API.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Hospital_API.Adapter
{
    public class RenovationAdapter
    {
        public static Renovation RenovationDTOToRenovation(RenovationDTO dto)
        {
            Renovation renovation = new Renovation();

            renovation.Id = dto.Id;
            renovation.FirstRoomId = dto.FirstRoomId;
            renovation.SecondRoomId = dto.SecondRoomId;
            renovation.Type = dto.Type;
            renovation.Duration = dto.Duration;
            renovation.Date = dto.Date;
            

            return renovation;
        }

        public static RenovationDTO RenovationToRenovationDTO(Renovation renovation)
        {
            RenovationDTO dto = new RenovationDTO();

            dto.Id = renovation.Id;
            dto.FirstRoomId = renovation.FirstRoomId;
            dto.SecondRoomId = renovation.SecondRoomId;
            dto.Type = renovation.Type;
            dto.Duration = renovation.Duration;
            dto.Date = renovation.Date;

            return dto;
        }
    }
}
