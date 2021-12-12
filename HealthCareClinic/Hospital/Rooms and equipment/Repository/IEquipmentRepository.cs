using ClinicCore.Storages;
using Hospital.Rooms_and_equipment.Model;
using System;
using System.Collections.Generic;
using System.Text;

namespace Hospital.Rooms_and_equipment.Repository
{
    public interface IEquipmentRepository : IRepository<Equipment>
    {
        public List<Equipment> GetEquipmentByRoomId(int id);
        public List<Equipment> GetEquipmentByName(string name);
        public void Change(String equipment, int sourceRoomId, int destinationRoomId, int quantity);
        public void ChangeQuantity(int eqId, int newQuantity);
        public void ChangeRoom(int eqId, int newRoomId);
    }
}
