using Hospital.Mapper;
using Hospital.Rooms_and_equipment.Model;
using Hospital.Rooms_and_equipment.Repository;
using System;
using System.Collections.Generic;
using System.Text;

namespace Hospital.Rooms_and_equipment.Service
{
    public class EquipmentService : IEquipmentService
    {
        private IEquipmentRepository _equipmentRepository;

        public EquipmentService(IEquipmentRepository equipmentRepository)
        {
            this._equipmentRepository = equipmentRepository;
        }
        public void Add(Equipment entity)
        {
            _equipmentRepository.Add(entity);
        }

        public IEnumerable<Equipment> GetAll()
        {
            return _equipmentRepository.GetAll();
        }

        public Equipment GetOneById(int id)
        {
            return _equipmentRepository.GetById(id);
        }

        public void Remove(Equipment entity)
        {
            _equipmentRepository.Remove(entity);
        }

        public List<Equipment> GetEquipmentByRoomId(int id)
        {
           return _equipmentRepository.GetEquipmentByRoomId(id);
        }

        public List<Equipment> GetEquipmentByName(string name)
        {
           return _equipmentRepository.GetEquipmentByName(name);
        }

        public void Change(String equipment, int sourceRoomId, int destinationRoomId, int quantity) {
            _equipmentRepository.Change(equipment, sourceRoomId, destinationRoomId, quantity);
        }

        public List<Equipment> TransferEquipmentFromOneRoomToAnother(int roomId1, int roomId2)
        {
            List<Equipment> newEquipment = new List<Equipment>();

            List<Equipment> equipmentRoom1 = GetEquipmentByRoomId(roomId1);
            List<Equipment> equipmentRoom2 = GetEquipmentByRoomId(roomId2);

            foreach (Equipment eq1 in equipmentRoom1)
            {
                Equipment eq = new Equipment(eq1.Id, eq1.Name, eq1.Type, eq1.Quantity + GetQuantityOfEquipmentInOtherRoom(eq1.Name, equipmentRoom2), eq1.RoomId);
                newEquipment.Add(eq);
            }
            foreach (Equipment eq2 in equipmentRoom2)
            {
                if (!EquipmentExistsInRoom(eq2.Name, equipmentRoom1))
                {
                    Equipment eq = new Equipment(eq2.Id, eq2.Name, eq2.Type, eq2.Quantity, roomId1);
                    newEquipment.Add(eq);
                }
            }

            return newEquipment;
        }

        private bool EquipmentExistsInRoom(string equipmentName, List<Equipment> roomEquipment)
        {
            foreach (Equipment eq in roomEquipment)
            {
                if (eq.Name.Equals(equipmentName))
                {
                    return true;
                }
            }
            return false;
        }

        private int GetQuantityOfEquipmentInOtherRoom(string equipmentName, List<Equipment> roomEquipment)
        {
            foreach (Equipment eq in roomEquipment)
            {
                if (eq.Name.Equals(equipmentName))
                {
                    return eq.Quantity;
                }
            }
            return 0;
        }

        public int GetQuantityOfEquipmentWhenTransferedFromOneRoomToAnother(string equipmentName, int roomId1, int roomId2)
        {
            List<Equipment> equipmentRoom1 = GetEquipmentByRoomId(roomId1);
            List<Equipment> equipmentRoom2 = GetEquipmentByRoomId(roomId2);

            if (EquipmentExistsInRoom(equipmentName, equipmentRoom1))
            {
                foreach (Equipment eq1 in equipmentRoom1)
                {
                    if (eq1.Name.Equals(equipmentName))
                    {
                        return eq1.Quantity + GetQuantityOfEquipmentInOtherRoom(eq1.Name, equipmentRoom2);
                    }
                }
            }
            else
            {
                if (EquipmentExistsInRoom(equipmentName, equipmentRoom2))
                {
                    foreach (Equipment eq2 in equipmentRoom2)
                    {
                        if (eq2.Name.Equals(equipmentName))
                        {
                            return eq2.Quantity;
                        }
                    }
                }
            }

            return 0;
        }

        public void TransferEquipmentAfterReservation(int firstRoomId, int secondRoomId)
        {
            List<Equipment> equipmentRoom1 = GetEquipmentByRoomId(firstRoomId);
            List<Equipment> equipmentRoom2 = GetEquipmentByRoomId(secondRoomId);

            foreach (Equipment eq1 in equipmentRoom1)
            {
                int newQuantity = eq1.Quantity + GetQuantityOfEquipmentInOtherRoom(eq1.Name, equipmentRoom2);
                _equipmentRepository.ChangeQuantity(eq1.Id, newQuantity);
            }
            foreach (Equipment eq2 in equipmentRoom2)
            {
                if (!EquipmentExistsInRoom(eq2.Name, equipmentRoom1))
                {
                    _equipmentRepository.ChangeRoom(eq2.Id, firstRoomId);
                } 
                else
                {
                    Remove(eq2);
                }
            }
         
        }
    }
}
