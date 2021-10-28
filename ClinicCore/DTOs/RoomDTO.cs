using Enums;
using System.Collections.Generic;

namespace ClinicCore.DTOs
{
    public class RoomDTO
    {
        public int RoomNumber { get; set; }
        public int BedNumber { get; set; }
        public int RoomId { get; set; }
        public RoomType Type { get; set; }
        public List<EquipmentDTO> Equipment { get; set; }
        public int RoomFloor { get; set; }
        public bool IsUsable { get; set; }
        public string RoomTypeText { get; set; }
        public RoomDTO(int roomNumber, int bedNumber, int roomId, RoomType type)
        {
            RoomNumber = roomNumber;
            BedNumber = bedNumber;
            RoomId = roomId;
            Type = type;

            if (type.Equals(RoomType.ConsultingRoom))
                RoomTypeText = "Konsultacije";
            else if (type.Equals(RoomType.RecoveryRoom))
                RoomTypeText = "Za oporavak";
            else if (type.Equals(RoomType.OperationRoom))
                RoomTypeText = "Operaciona sala";
            else if (type.Equals(RoomType.StorageRoom))
                RoomTypeText = "Magacin";
        }

        public RoomDTO(int roomNumber, int bedNumber, int roomId, RoomType type, List<EquipmentDTO> equipment, 
            int roomFloor, bool isUsable) : this(roomNumber, bedNumber, roomId, type)
        {
            Equipment = equipment;
            RoomFloor = roomFloor;
            IsUsable = isUsable;

        }
    }
}
