using ClinicCore.Service;
using Hospital.Mapper;
using Hospital.Rooms_and_equipment.Model;
using Hospital.Rooms_and_equipment.Repository;
using System;
using System.Collections.Generic;
using System.Text;

namespace Hospital.Rooms_and_equipment.Service
{
    public class BuildingService : IBuildingService
    {
        private IBuildingRepository _buildingRepository;

        public BuildingService(IBuildingRepository buildingRepository)
        {
            this._buildingRepository = buildingRepository;
        }
        public void Add(Building entity)
        {
            _buildingRepository.Add(entity);
        }

        public IEnumerable<Building> GetAll()
        {
            return _buildingRepository.GetAll();
        }

        public Building GetOneById(int id)
        {
            return _buildingRepository.GetById(id);
        }

        public void Remove(Building entity)
        {
            _buildingRepository.Remove(entity);
        }
        public void Change(Building entity)
        {
            _buildingRepository.Change(entity);
        }
    }
}
