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
    }
}
