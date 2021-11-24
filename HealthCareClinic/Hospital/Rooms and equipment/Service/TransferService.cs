using Hospital.Rooms_and_equipment.Model;
using System;
using System.Collections.Generic;
using System.Text;
using Hospital.Rooms_and_equipment.Repository;

namespace Hospital.Rooms_and_equipment.Service
{
    public class TransferService : ITransferService
    {
        private ITransferRepository _transferRepository;

        public TransferService(ITransferRepository transferRepository)
        {
            this._transferRepository = transferRepository;
        }

        public void Add(Transfer entity)
        {
            _transferRepository.Add(entity);
        }

        public IEnumerable<Transfer> GetAll()
        {
            return _transferRepository.GetAll();
        }

        public Transfer GetOneById(int id)
        {
            return _transferRepository.GetById(id);
        }

        public void Remove(Transfer entity)
        {
            _transferRepository.Remove(entity);
        }

        public void RemoveById(int id) 
        {
            _transferRepository.RemoveById(id);
        }
    }
}
