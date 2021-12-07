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

        public List<DateTime> checkFreeTransfers(Transfer transfer)
        {

            List<Transfer> allTransfersOfSourceAndDestinationRoom = getTransfersOfSourceAndDestination(transfer.SourceRoomId, transfer.DestinationRoomId);
            List<DateTime> allAvailableDates = new List<DateTime>();        
            DateTime today = DateTime.Now;
            today = roundMinutes(today);
            DateTime todayAndDuration = today.AddHours(Convert.ToInt32(transfer.Duration)/60);
            todayAndDuration = addDuration(todayAndDuration, transfer.Duration);
            while (todayAndDuration < transfer.Date)
            {
                Boolean isFree = true;
                
                foreach (Transfer t in allTransfersOfSourceAndDestinationRoom)
                {
                    DateTime transferAndDuration = t.Date.AddHours(Convert.ToInt32(t.Duration) / 60);
                    transferAndDuration = addDuration(transferAndDuration,t.Duration);
                    if (t.Date <= today && today <= transferAndDuration)
                    {
                        isFree = false;
                    }
                    if (t.Date <= todayAndDuration && todayAndDuration <= transferAndDuration)
                    {
                        isFree = false;
                    }
                    if (today <= t.Date && t.Date <= todayAndDuration)
                    {
                        isFree = false;
                    }

                }
                if (isFree)
                {
                    allAvailableDates.Add(today);
                }
                if (today.Minute < 45)
                {
                    today = today.AddMinutes(15);

                }
                else
                {
                    if (today.Hour < 23)
                    {
                        today = today.AddHours(1);
                        today = ChangeTime(today.Year, today.Month, today.Day, today.Hour, 0, 0);
                    }
                    else
                    {
                        if (today.Day < DateTime.DaysInMonth(today.Year, today.Month))
                        {
                            today = today.AddDays(1);
                            today = ChangeTime(today.Year, today.Month, today.Day, 0, 0, 0);
                        }
                        else
                        {
                            if (today.Month < 12)
                            {
                                today = today.AddMonths(1);
                                today = ChangeTime(today.Year, today.Month, 1, 0, 0, 0);
                            }
                            else
                            {
                                today = today.AddYears(1);
                            }
                        }
                    }

                }
                todayAndDuration = today.AddHours(Convert.ToInt32(transfer.Duration) / 60);
                todayAndDuration = addDuration(todayAndDuration, transfer.Duration);

            }
            return allAvailableDates;

        }
        private List<Transfer> getTransfersOfSourceAndDestination(int sourceRoomId, int destinationRoomId)
        {
            List<Transfer> existingTransfers = GetAll().ToList();
            List<Transfer> allTransfersOfSourceAndDestinationRoom = new List<Transfer>();
            foreach (Transfer tran in existingTransfers)
            {
                if (tran.SourceRoomId == sourceRoomId || tran.DestinationRoomId == destinationRoomId || tran.SourceRoomId == destinationRoomId || tran.DestinationRoomId == sourceRoomId)
                {
                    allTransfersOfSourceAndDestinationRoom.Add(tran);
                }
            }
            return allTransfersOfSourceAndDestinationRoom;
        }

        private DateTime roundMinutes(DateTime now)
        {
            if (now.Minute < 15)
            {
                now = ChangeTime(now.Year, now.Month, now.Day, now.Hour, 15, 0);
            }
            else if (now.Minute < 30)
            {
                now = ChangeTime(now.Year, now.Month, now.Day, now.Hour, 30, 0);
            }
            else if (now.Minute < 45)
            {
                now = ChangeTime(now.Year, now.Month, now.Day, now.Hour, 45, 0);
            }
            else if (now.Minute < 60)
            {
                now = ChangeTime(now.Year, now.Month, now.Day, now.Hour + 1, 0, 0);
            }
            return now;
        }
        private DateTime addDuration(DateTime now,int duration)
        {
            if ((now.Minute + (duration % 60)) < 60)
            {
                now = now.AddMinutes(duration % 60);
            }
            else
            {
                now = now.AddHours(1);
                now = ChangeTime(now.Year, now.Month, now.Day, now.Hour, (now.Minute + (duration % 60)) - 60, 0);
            }
            return now;
        }
        private DateTime ChangeTime(int year, int month, int day, int hours, int minutes, int seconds)
        {
            return new DateTime(
                year,
                month,
                day,
                hours,
                minutes,
                seconds);
        }

        public List<Transfer> GetRoomTransfers(int id)
        {
            List<Transfer> roomTransfers = new List<Transfer>();
            foreach (Transfer transfer in GetAll()) 
            {
                if (transfer.SourceRoomId == id || transfer.DestinationRoomId == id)
                    roomTransfers.Add(transfer);
            }
            return roomTransfers;
        }
    }
}
