using Hospital.Mapper;
using Hospital.Rooms_and_equipment.Model;
using Hospital.Rooms_and_equipment.Repository;
using System;
using System.Collections.Generic;
using System.Text;

namespace Hospital.Rooms_and_equipment.Service
{
    public class FloorService : IFloorService
    {
        private IFloorRepository _floorRepository;

        public FloorService(IFloorRepository floorRepository)
        {
            this._floorRepository = floorRepository;
        }
        public void Add(Floor entity)
        {
            _floorRepository.Add(entity);
        }

        public IEnumerable<Floor> GetAll()
        {
            return _floorRepository.GetAll();
        }

        public Floor GetOneById(int id)
        {
            return _floorRepository.GetById(id);
        }

        public void Remove(Floor entity)
        {
            _floorRepository.Remove(entity);
        }

        public List<Floor> GetFloorsByBuildingId(int id)
        {
            return _floorRepository.GetFloorsByBuildingId(id);
        }
    }
}
