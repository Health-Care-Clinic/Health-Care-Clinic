using Hospital.Rooms_and_equipment.Model;
using Hospital.Rooms_and_equipment.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Hospital.Rooms_and_equipment.Service
{
    public class RenovationService : IRenovationService
    {
        private IRenovationRepository _renovationRepository;
        private ITransferRepository _transferRepository;

        public RenovationService(IRenovationRepository renovationRepository, ITransferRepository transferRepository)
        {
            this._renovationRepository = renovationRepository;
            this._transferRepository = transferRepository;
        }

        public void Add(Renovation entity)
        {
            _renovationRepository.Add(entity);
        }

        public void Remove(Renovation entity)
        {
            _renovationRepository.Remove(entity);
        }

        public Renovation GetOneById(int id)
        {
            return _renovationRepository.GetById(id);
        }

        public IEnumerable<Renovation> GetAll()
        {
            return _renovationRepository.GetAll();
        }
        public List<DateTime> getFreeTermsForMerge(Renovation renovation)
        {

            List<Transfer> allTransfersOfSourceAndDestinationRoom = getTransfersOfFirstAndSecond(renovation.FirstRoomId, renovation.SecondRoomId);
            List<Renovation> allRenovationsOfFirstAndSecond = getRenovationsOfFirstAndSecond(renovation.FirstRoomId, renovation.SecondRoomId);
            List<DateTime> allAvailableDates = new List<DateTime>();
            DateTime today = DateTime.Now;
            today = roundMinutes(today);
            DateTime todayAndDuration = today.AddDays(Convert.ToInt32(renovation.Duration));
            while (todayAndDuration < renovation.Date)
            {
                Boolean isFree = true;

                foreach (Transfer t in allTransfersOfSourceAndDestinationRoom)
                {
                    DateTime transferAndDuration = t.Date.AddHours(Convert.ToInt32(t.Duration) / 60);
                    transferAndDuration = addDuration(transferAndDuration, t.Duration);
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
                foreach (Renovation r in allRenovationsOfFirstAndSecond)
                {
                    DateTime renovationAndDuration = r.Date.AddDays(Convert.ToInt32(r.Duration));
                    if (r.Date <= today && today <= renovationAndDuration)
                    {
                        isFree = false;
                    }
                    if (r.Date <= todayAndDuration && todayAndDuration <= renovationAndDuration)
                    {
                        isFree = false;
                    }
                    if (today <= r.Date && r.Date <= todayAndDuration)
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
                todayAndDuration = today.AddDays(Convert.ToInt32(renovation.Duration));

            }
            return allAvailableDates;

        }


        public List<DateTime> getFreeTermsForDivide(Renovation renovation)
        {

            List<Transfer> allTransfersOfSourceAndDestinationRoom = getTransfersOfFirstRoom(renovation.FirstRoomId);
            List<Renovation> allRenovationsOfFirstAndSecond = getRenovationsOfFirstRoom(renovation.FirstRoomId);
            List<DateTime> allAvailableDates = new List<DateTime>();
            DateTime today = DateTime.Now;
            today = roundMinutes(today);
            DateTime todayAndDuration = today.AddDays(Convert.ToInt32(renovation.Duration));
            while (todayAndDuration < renovation.Date)
            {
                Boolean isFree = true;

                foreach (Transfer t in allTransfersOfSourceAndDestinationRoom)
                {
                    DateTime transferAndDuration = t.Date.AddHours(Convert.ToInt32(t.Duration) / 60);
                    transferAndDuration = addDuration(transferAndDuration, t.Duration);
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
                foreach (Renovation r in allRenovationsOfFirstAndSecond)
                {
                    DateTime renovationAndDuration = r.Date.AddDays(Convert.ToInt32(r.Duration));
                    if (r.Date <= today && today <= renovationAndDuration)
                    {
                        isFree = false;
                    }
                    if (r.Date <= todayAndDuration && todayAndDuration <= renovationAndDuration)
                    {
                        isFree = false;
                    }
                    if (today <= r.Date && r.Date <= todayAndDuration)
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
                todayAndDuration = today.AddDays(Convert.ToInt32(renovation.Duration));

            }
            return allAvailableDates;

        }
        private List<Transfer> getTransfersOfFirstAndSecond(int firstRoomId, int secondRoomId)
        {
            List<Transfer> existingTransfers = _transferRepository.GetAll().ToList();
            List<Transfer> allTransfersOfSourceAndDestinationRoom = new List<Transfer>();
            foreach (Transfer tran in existingTransfers)
            {
                if (tran.SourceRoomId == firstRoomId || tran.DestinationRoomId == secondRoomId || tran.SourceRoomId == secondRoomId || tran.DestinationRoomId == firstRoomId)
                {
                    allTransfersOfSourceAndDestinationRoom.Add(tran);
                }
            }
            return allTransfersOfSourceAndDestinationRoom;
        }

        private List<Transfer> getTransfersOfFirstRoom(int firstRoomId)
        {
            List<Transfer> existingTransfers = _transferRepository.GetAll().ToList();
            List<Transfer> allTransfersOfFirst = new List<Transfer>();
            foreach (Transfer tran in existingTransfers)
            {
                if (tran.SourceRoomId == firstRoomId || tran.DestinationRoomId == firstRoomId)
                {
                    allTransfersOfFirst.Add(tran);
                }
            }
            return allTransfersOfFirst;
        }

        private List<Renovation> getRenovationsOfFirstAndSecond(int firstRoomId, int secondRoomId)
        {
            List<Renovation> existingRenovations = GetAll().ToList();
            List<Renovation> allRenovationsOfFirstAndSecondRoom = new List<Renovation>();
            foreach (Renovation ren in existingRenovations)
            {
                if (ren.FirstRoomId == firstRoomId || ren.SecondRoomId == secondRoomId || ren.FirstRoomId == secondRoomId || ren.SecondRoomId == firstRoomId)
                {
                    allRenovationsOfFirstAndSecondRoom.Add(ren);
                }
            }
            return allRenovationsOfFirstAndSecondRoom;
        }

        private List<Renovation> getRenovationsOfFirstRoom(int firstRoomId)
        {
            List<Renovation> existingRenovations = GetAll().ToList();
            List<Renovation> allRenovationsOfFirst = new List<Renovation>();
            foreach (Renovation ren in existingRenovations)
            {
                if (ren.FirstRoomId == firstRoomId || ren.SecondRoomId == firstRoomId)
                {
                    allRenovationsOfFirst.Add(ren);
                }
            }
            return allRenovationsOfFirst;
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
        private DateTime addDuration(DateTime now, int duration)
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

        public List<Renovation> GetRoomRenovations(int id)
        {
            List<Renovation> roomRenovations = new List<Renovation>();
            foreach (Renovation renovation in GetAll())
            {
                if (renovation.SecondRoomId == id || renovation.FirstRoomId == id)
                    roomRenovations.Add(renovation);
            }
            return roomRenovations;
        }

        public bool CheckIfRenovationCancellable(int id)
        {
            foreach (Renovation renovation in GetAll())
            {
                if (renovation.Id == id && DateTime.Now.AddHours(24) <= renovation.Date)
                    return true;
            }
            return false;
        }

        public void RemoveById(int id)
        {
            _renovationRepository.RemoveById(id);
        }
    }
}
