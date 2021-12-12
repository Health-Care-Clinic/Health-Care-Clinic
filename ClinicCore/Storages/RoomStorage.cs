using ClinicCore.Storages;
using Model;

namespace Storages
{
    public class RoomStorage: GenericFileStorage<Room>
    {
       
        public RoomStorage()
        {
            this.fileLocation = "../../../FileStorage/rooms.json";
        }

       

    }
}