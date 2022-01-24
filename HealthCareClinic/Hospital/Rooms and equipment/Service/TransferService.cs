using Hospital.Rooms_and_equipment.Model;
using System;
using System.Collections.Generic;
using System.Text;
using Hospital.Rooms_and_equipment.Repository;
using System.Linq;

namespace Hospital.Rooms_and_equipment.Service
{
    public class TransferService : ITransferService
    {
        private readonly ITransferRepository _transferRepository;

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

        public List<DateTime> checkFreeTransfers(Transfer transfer)
        {
            List<Transfer> allTransfersOfSourceAndDestinationRoom = transfer.GetTransfersOfSourceAndDestination(GetAll().ToList());
            List<DateTime> allAvailableDates = new List<DateTime>();        
            DateTime today = transfer.RoundMinutes(DateTime.Now);
            DateTime todayAndDuration = today.AddHours((double) (Convert.ToInt32(transfer.DateAndDuration.Duration) / 60));
            todayAndDuration = transfer.AddDuration(todayAndDuration);
            while (todayAndDuration < transfer.DateAndDuration.Date)
            {
                foreach (Transfer t in allTransfersOfSourceAndDestinationRoom)
                {
                    DateTime transferAndDuration = t.DateAndDuration.Date.AddHours((double) (Convert.ToInt32(t.DateAndDuration.Duration) / 60));
                    transferAndDuration = t.AddDuration(transferAndDuration);
                    if (!(t.DateAndDuration.Date <= today && today <= transferAndDuration
                        || t.DateAndDuration.Date <= todayAndDuration && todayAndDuration <= transferAndDuration
                        || today <= t.DateAndDuration.Date && t.DateAndDuration.Date <= todayAndDuration))
                    {
                        allAvailableDates.Add(today);
                    }
                }
                todayAndDuration = transfer.AddTime(today).AddHours((double) (Convert.ToInt32(transfer.DateAndDuration.Duration) / 60));
                todayAndDuration = transfer.AddDuration(todayAndDuration);
            }

            return allAvailableDates;
        }

        public List<Transfer> GetRoomTransfers(int id)
        {
            List<Transfer> roomTransfers = new List<Transfer>();
            foreach (Transfer transfer in GetAll()) 
            {
                if (transfer.RoomsForTransfer.SourceRoomId == id || transfer.RoomsForTransfer.DestinationRoomId == id)
                    roomTransfers.Add(transfer);
            }

            return roomTransfers;
        }

        public bool CheckIfTransferCancellable(int id)
        {
            foreach (Transfer transfer in GetAll())
            {
                if (transfer.Id == id && DateTime.Now.AddHours(24) <= transfer.DateAndDuration.Date)
                    return true;
            }

            return false;
        }
    }
}
