
namespace Model
{
    public class Bed
    {

        public int BedId { get; set; }
        public int RoomId { get; set; }
        public bool Taken { get; set; }

        public Bed(int roomId, bool taken)
        {
            RoomId = roomId;
            Taken = taken;
        }
    }
}
